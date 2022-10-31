using PortFolio.CurriculumGenerator.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;

namespace PortFolio.CurriculumGenerator
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreaCurriculum_Click(object sender, EventArgs e)
        {
            // Creo l'oggetto CV
            ImpostaOggettoCV();
        }

        public void ImpostaOggettoCV()
        {
            // imposto le variabili
            // Skills
            var skill = txtSkills.Text;

            // Profilo
            var profilo = txtProfilo.Text;

            var anagrafica = SetAnagrafica();

            var contatti = SetContatti();
            var percorsoDiStudi = SetPercorsoDiStudi();
            var esperienzaLavorativa = SetEsperienzaLavorativa();
            var progetti = SetProgettiPersonali();

            var cv = new Curriculum();
            cv.anagrafica = anagrafica;
            cv.contatti = contatti;
            cv.percorsoDiStudi = percorsoDiStudi;
            cv.esperienzaLavorativa = esperienzaLavorativa;
            cv.progettiPersonali = progetti;
            cv.profilo = profilo;
            cv.skills = skill;

            Session["CV"] = cv;
            //Response.Redirect("~bills/create");

            using (WebClient client = new WebClient())
            {
                var url = ConfigurationManager.AppSettings["SiteUrl"].ToString() + "CurriculumGenerator/template.html";

                // Or you can get html source code as a string
                string htmlCode = client.DownloadString(url);
            }

            // Carico le coordinate dal file json
            string fullPath = new DirectoryInfo(
                string.Format("{0}\\CurriculumGenerator\\template.html",
                HttpContext.Current.Server.MapPath(@"\"))).ToString();

            var html = "";
            using (StreamReader sr = new StreamReader(fullPath))
            {
                html = sr.ReadToEnd();
            }

            html = ImpostaVariabiliSuHtml(html, cv);

            //MemoryStream ms = new MemoryStream();
            //TextWriter tw = new StreamWriter(ms);
            //tw.Write(html);
            //tw.Flush();
            //byte[] bytes = ms.ToArray();
            //ms.Close();

            //Response.Clear();
            //Response.ContentType = "text/html";
            //Response.AddHeader("content-disposition", "attachment;    filename=file.html");
            //Response.BinaryWrite(bytes);
            //Response.End();
            GeneraPDF(html);
        }

        public Anagrafica SetAnagrafica()
        {
            // Anagrafica
            var nome = txtNome.Text;
            var cognome = txtCognome.Text;
            var eta = txtEta.Text;
            var nazionalita = txtNazionalita.Text;
            var lingua = txtLingue.Text;

            var anagrafica = new Anagrafica() { 
                Nome = nome,
                Cognome = cognome,
                Eta = eta,
                Nazionalita = nazionalita,
                Lingua = lingua
            };

            return anagrafica;
        }

        public Contatti SetContatti()
        {
            // Contatti
            var telefono = txtTelefono.Text;
            var email = txtEmail.Text;
            var indirizzo = txtIndirizzo.Text;
            var sitoweb = txtSitoWeb.Text;

            var contatti = new Contatti()
            {
                Telefono = telefono,
                Email = email,
                Indirizzo = indirizzo,
                SitoWeb = sitoweb
            };

            return contatti;
        }

        public PercorsoDiStudi SetPercorsoDiStudi()
        {
            // Percorso di studi
            var percorso1 = txtPercorso1.Text;
            var percorsoLuogo1 = txtPercorsoLuogo1.Text;
            var percorso2 = txtPercorso2.Text;
            var percorsoLuogo2 = txtPercorsoLuogo2.Text;

            var percorsoDiStudi = new PercorsoDiStudi()
            {
                Percorso1 = percorso1,
                PercorsoLuogo1 = percorsoLuogo1,
                Percorso2 = percorso2,
                PercorsoLuogo2 = percorsoLuogo2
            };

            return percorsoDiStudi;
        }

        public EsperienzaLavorativa SetEsperienzaLavorativa()
        {
            // Esperienza lavorativa
            var professione = txtProfessione.Text;
            var azienda = txtAzienda.Text;
            var inizio = txtDataInizio.Text;
            var fine = txtDataFine.Text;
            var descrizione = txtDescrizione.Text;

            var esperienzaLavorativa = new EsperienzaLavorativa()
            {
                Professione = professione,
                Azienda = azienda,
                Inizio = inizio,
                Fine = fine,
                Descrizione = descrizione
            };

            return esperienzaLavorativa;
        }

        public List<ProgettoPersonale> SetProgettiPersonali()
        {
            var progetti = new List<ProgettoPersonale>();

            // Progetti personali
            var progetto1 = txtProgetto1.Text;
            var progettoLinguaggio1 = txtProgettoLinguaggio1.Text;
            progetti.Add(new ProgettoPersonale()
            {
                Progetto = progetto1,
                Linguaggio = progettoLinguaggio1
            });

            var progetto2 = txtProgetto2.Text;
            var progettoLinguaggio2 = txtProgettoLinguaggio2.Text;
            progetti.Add(new ProgettoPersonale()
            {
                Progetto = progetto2,
                Linguaggio = progettoLinguaggio2
            });
            var progetto3 = txtProgetto3.Text;
            var progettoLinguaggio3 = txtProgettoLinguaggio3.Text;
            progetti.Add(new ProgettoPersonale()
            {
                Progetto = progetto3,
                Linguaggio = progettoLinguaggio3
            });
            var progetto4 = txtProgetto4.Text;
            var progettoLinguaggio4 = txtProgettoLinguaggio4.Text;
            progetti.Add(new ProgettoPersonale()
            {
                Progetto = progetto4,
                Linguaggio = progettoLinguaggio4
            });
            var progetto5 = txtProgetto5.Text;
            var progettoLinguaggio5 = txtProgettoLinguaggio5.Text;
            progetti.Add(new ProgettoPersonale()
            {
                Progetto = progetto5,
                Linguaggio = progettoLinguaggio5
            });
            var progetto6 = txtProgetto6.Text;
            var progettoLinguaggio6 = txtProgettoLinguaggio6.Text;
            progetti.Add(new ProgettoPersonale()
            {
                Progetto = progetto6,
                Linguaggio = progettoLinguaggio6
            });

            return progetti;
        }

        public string ImpostaVariabiliSuHtml(string html, Curriculum cv)
        {
            html =
                html
                .Replace("{{Nome}}", cv.anagrafica.Nome)
                .Replace("{{Cognome}}", cv.anagrafica.Cognome)
                .Replace("{{Eta}}", cv.anagrafica.Eta)
                .Replace("{{Nazionalita}}", cv.anagrafica.Nazionalita)
                .Replace("{{Lingua}}", cv.anagrafica.Lingua)
                .Replace("{{Telefono}}", cv.contatti.Telefono)
                .Replace("{{Email}}", cv.contatti.Email)
                .Replace("{{Indirizzo}}", cv.contatti.Indirizzo)
                .Replace("{{SitoWeb}}", cv.contatti.SitoWeb)
                .Replace("{{Percorso1}}", cv.percorsoDiStudi.Percorso1)
                .Replace("{{PercorsoLuogo1}}", cv.percorsoDiStudi.PercorsoLuogo1)
                .Replace("{{Percorso2}}", cv.percorsoDiStudi.Percorso2)
                .Replace("{{PercorsoLuogo2}}", cv.percorsoDiStudi.PercorsoLuogo2)
                .Replace("{{Skills}}", cv.skills)
                .Replace("{{Profilo}}", cv.profilo)
                .Replace("{{Professione}}", cv.esperienzaLavorativa.Professione)
                .Replace("{{Azienda}}", cv.esperienzaLavorativa.Azienda)
                .Replace("{{Inizio}}", cv.esperienzaLavorativa.Inizio)
                .Replace("{{Fine}}", cv.esperienzaLavorativa.Fine)
                .Replace("{{Descrizione}}", cv.esperienzaLavorativa.Descrizione);

            html = ReplaceImmagineProfilo(html);
            html = ReplaceSkills(html, cv);
            html = ReplaceProgettiPersonali(html, cv);

            return html;
        }

        public string ReplaceProgettiPersonali(string html, Curriculum cv)
        {
            int i = 1;
            foreach (var progetto in cv.progettiPersonali)
            {
                var pro = "{{Progetto" + i + "}}";
                var linguaggio = "{{ProgettoLinguaggio" + i + "}}";
                html =
                    html
                    .Replace(pro, progetto.Progetto)
                    .Replace(linguaggio, progetto.Linguaggio);
                i = i + 1;
            }

            return html;
        }

        public string ReplaceSkills(string html, Curriculum cv)
        {
            int i = 1;
            var skills = cv.skills.Split(',');
            foreach (var skill in skills)
            {
                var anchor = "{{Skill-" + i + "}}";
                html =
                    html
                    .Replace(anchor, skill);
                i = i + 1;
            }

            return html;
        }

        public string ReplaceImmagineProfilo(string html)
        {
            // Converto l'immagine in base64
            var bytes = fileImmagine.FileBytes;
            var img64 = Convert.ToBase64String(bytes);

            html = html.Replace("{{ImgBase64}}", img64);

            return html;
        }

        public void GeneraPDF(string html)
        {
            // Uso la libreria SelectPDF community edition

            // Imposto il foglio in formato A4
            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            // Imposto l'orientamento verticale
            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            // Imposto le dimensioni della pagina
            int webPageWidth = 840;
            int webPageHeight = 1188;

            // Instanzio l'oggetto HtmlToPdf
            HtmlToPdf converter = new HtmlToPdf();

            // Imposto i parametri
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // Converto l'html nel pdf
            PdfDocument doc = converter.ConvertHtmlString(html);

            // Imposto il nome del documento
            var nomeDocumento = $"Curriculum - {txtNome.Text} {txtCognome.Text} {DateTime.Now.ToShortDateString()}.pdf";

            // Salvo il documento
            doc.Save(Response, false, nomeDocumento);

            // Chiudo il documento
            doc.Close();
        }
    }
}