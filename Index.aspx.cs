using System;
using System.IO;
using System.Net;
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
            // imposto le variabili

            // Anagrafica
            var nome = txtNome.Text;
            var cognome = txtCognome.Text;
            var eta = txtEta.Text;
            var nazionalita = txtNazionalita.Text;
            var lingua = txtLingue.Text;

            // Contatti
            var telefono = txtTelefono.Text;
            var email = txtEmail.Text;
            var indirizzo = txtIndirizzo.Text;
            var sitoweb = txtSitoWeb.Text;

            // Percorso di studi
            var percorso1 = txtPercorso1.Text;
            var percorsoLuogo1 = txtPercorsoLuogo1.Text;
            var percorso2 = txtPercorso2.Text;
            var percorsoLuogo2 = txtPercorsoLuogo2.Text;

            // Profilo
            var profilo = txtProfilo.Text;

            // Esperienza lavorativa
            var professione = txtProfessione.Text;
            var azienda = txtAzienda.Text;
            var inizio = txtDataInizio.Text;
            var fine = txtDataFine.Text;
            var descrizione = txtDescrizione.Text;

            // Progetti personali
            var progetto1 = txtProgetto1.Text;
            var progettoLinguaggio1 = txtProgettoLinguaggio1.Text;
            var progetto2 = txtProgetto2.Text;
            var progettoLinguaggio2 = txtProgettoLinguaggio2.Text;
            var progetto3 = txtProgetto3.Text;
            var progettoLinguaggio3 = txtProgettoLinguaggio3.Text;
            var progetto4 = txtProgetto4.Text;
            var progettoLinguaggio4 = txtProgettoLinguaggio4.Text;
            var progetto5 = txtProgetto5.Text;
            var progettoLinguaggio5 = txtProgettoLinguaggio5.Text;
            var progetto6 = txtProgetto6.Text;
            var progettoLinguaggio6 = txtProgettoLinguaggio6.Text;

            // Carico le coordinate dal file json
            string fullPath = new DirectoryInfo(
                string.Format("{0}\\CurriculumGenerator\\template.html",
                HttpContext.Current.Server.MapPath(@"\"))).ToString();

            var html = "";
            using (StreamReader sr = new StreamReader(fullPath))
            {
                html = sr.ReadToEnd();
            }

            html =
                html.Replace("{{Nome}}", nome)
                .Replace("{{Cognome}}", cognome)
                .Replace("{{Eta}}", eta)
                .Replace("{{Nazionalita}}", nazionalita)
                .Replace("{{telefono}}", telefono)
                .Replace("{{email}}", email)
                .Replace("{{indirizzo}}", indirizzo)
                .Replace("{{sitoweb}}", sitoweb)
                .Replace("{{percorso1}}", percorso1)
                .Replace("{{percorsoLuogo1}}", percorsoLuogo1)
                .Replace("{{percorso2}}", percorso2)
                .Replace("{{percorsoLuogo2}}", percorsoLuogo2)
                .Replace("{{profilo}}", profilo)
                .Replace("{{professione}}", professione)
                .Replace("{{azienda}}", azienda)
                .Replace("{{inizio}}", inizio)
                .Replace("{{fine}}", fine)
                .Replace("{{descrizione}}", descrizione)
                .Replace("{{progetto1}}", progetto1)
                .Replace("{{progettoLinguaggio1}}", progettoLinguaggio1)
                .Replace("{{progetto2}}", progetto2)
                .Replace("{{progettoLinguaggio2}}", progettoLinguaggio2)
                .Replace("{{progetto3}}", progetto3)
                .Replace("{{progettoLinguaggio3}}", progettoLinguaggio3)
                .Replace("{{progetto4}}", progetto4)
                .Replace("{{progettoLinguaggio4}}", progettoLinguaggio4)
                .Replace("{{progetto5}}", progetto5)
                .Replace("{{progettoLinguaggio5}}", progettoLinguaggio5)
                .Replace("{{progetto6}}", progetto6)
                .Replace("{{progettoLinguaggio6}}", progettoLinguaggio6);

            MemoryStream ms = new MemoryStream();
            TextWriter tw = new StreamWriter(ms);
            tw.Write(html);
            tw.Flush();
            byte[] bytes = ms.ToArray();
            ms.Close();

            Response.Clear();
            Response.ContentType = "text/html";
            Response.AddHeader("content-disposition", "attachment;    filename=file.html");
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }
}