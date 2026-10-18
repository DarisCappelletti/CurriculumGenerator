using CurriculumGenerator.Api.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Xml.Serialization;

namespace CurriculumGenerator.Api.Services;

public class CurriculumGeneratorService
{
    private readonly IConverter _converter;
    private readonly string _templatePath;

    public CurriculumGeneratorService(IConverter converter, IWebHostEnvironment env)
    {
        _converter = converter;
        _templatePath = Path.Combine(env.ContentRootPath, "Assets", "Curriculumtemplate.html");
    }

    public CvZipFile GenerateCv(Curriculum1 cv)
    {
        var html = File.ReadAllText(_templatePath);
        html = ImpostaVariabiliSuHtml(html, cv);
        return GeneraZip(html, cv);
    }

    public Curriculum1? LeggiValoriDaFileXml(byte[] xmlBytes)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(XmlCurriculum));
            using var stream = new MemoryStream(xmlBytes);
            var result = (XmlCurriculum?)serializer.Deserialize(stream);
            return result?.curriculum;
        }
        catch
        {
            return null;
        }
    }

    private string ImpostaVariabiliSuHtml(string html, Curriculum1 cv)
    {
        var immagineProfilo = cv.hidImgBase64 ?? "";

        html = html
            .Replace("{{ImgBase64}}", immagineProfilo)
            .Replace("{{Nome}}", cv.anagrafica?.Nome ?? "")
            .Replace("{{Cognome}}", cv.anagrafica?.Cognome ?? "")
            .Replace("{{Eta}}", cv.anagrafica?.Eta ?? "")
            .Replace("{{Nazionalita}}", cv.anagrafica?.Nazionalita ?? "")
            .Replace("{{Lingua}}", cv.anagrafica?.Lingua ?? "")
            .Replace("{{Telefono}}", cv.contatti?.Telefono ?? "")
            .Replace("{{Email}}", cv.contatti?.Email ?? "")
            .Replace("{{Indirizzo}}", cv.contatti?.Indirizzo ?? "")
            .Replace("{{SitoWeb}}", cv.contatti?.SitoWeb ?? "")
            .Replace("{{Percorso1}}", cv.percorsoDiStudi?.Percorso1 ?? "")
            .Replace("{{PercorsoLuogo1}}", cv.percorsoDiStudi?.PercorsoLuogo1 ?? "")
            .Replace("{{Percorso2}}", cv.percorsoDiStudi?.Percorso2 ?? "")
            .Replace("{{PercorsoLuogo2}}", cv.percorsoDiStudi?.PercorsoLuogo2 ?? "")
            .Replace("{{Skills}}", cv.skills ?? "")
            .Replace("{{Profilo}}", cv.profilo ?? "")
            .Replace("{{Professione}}", cv.esperienzaLavorativa?.Professione ?? "")
            .Replace("{{Azienda}}", cv.esperienzaLavorativa?.Azienda ?? "")
            .Replace("{{Inizio}}", cv.esperienzaLavorativa?.DataInizio ?? "")
            .Replace("{{Fine}}", cv.esperienzaLavorativa?.DataFine ?? "")
            .Replace("{{Descrizione}}", cv.esperienzaLavorativa?.Descrizione ?? "");

        html = ReplaceSkills(html, cv);
        html = ReplaceProgettiPersonali(html, cv);

        return html;
    }

    private static string ReplaceSkills(string html, Curriculum1 cv)
    {
        var scheletro =
            "<div class=\"row border-left\">" +
                "<div class=\"column w-10 p-0\">" +
                    "<svg class=\"svg-inline--fa fa-arrow-right-long icona-width\" aria-hidden=\"true\" focusable=\"false\" data-prefix=\"fas\" data-icon=\"arrow-right-long\" role=\"img\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 512 512\" data-fa-i2svg=\"\"><path fill=\"currentColor\" d=\"M502.6 278.6c12.5-12.5 12.5-32.8 0-45.3l-128-128c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3L402.7 224 32 224c-17.7 0-32 14.3-32 32s14.3 32 32 32l370.7 0-73.4 73.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0l128-128z\"></path></svg>" +
                "</div>" +
                "<div class=\"column w-90 p-0\">" +
                    "<h3 class=\"m-0\">{{Skill}}</h3>" +
                "</div>" +
            "</div>";

        int i = 1;
        var skills = !string.IsNullOrEmpty(cv.skills) ? cv.skills.Split(',') : null;

        if (skills != null)
        {
            foreach (var skill in skills)
            {
                var anchor = "{{Skill-" + i + "}}";
                var scheletroConSkill = scheletro.Replace("{{Skill}}", skill.Trim());
                html = html.Replace(anchor, scheletroConSkill);
                i++;
            }

            for (int num = i; num <= 11; num++)
            {
                html = html.Replace("{{Skill-" + num + "}}", "");
            }
        }
        else
        {
            for (int num = 1; num <= 11; num++)
            {
                html = html.Replace("{{Skill-" + num + "}}", "");
            }
        }

        return html;
    }

    private static string ReplaceProgettiPersonali(string html, Curriculum1 cv)
    {
        if (cv.progettiPersonali != null)
        {
            int i = 1;
            foreach (var progetto in cv.progettiPersonali)
            {
                html = html
                    .Replace("{{Progetto" + i + "}}", progetto.Progetto ?? "")
                    .Replace("{{ProgettoLinguaggio" + i + "}}", progetto.Linguaggio ?? "");
                i++;
            }
        }

        return html;
    }

    private byte[] GeneraPDF(string html)
    {
        var doc = new HtmlToPdfDocument
        {
            GlobalSettings = new GlobalSettings
            {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait,
            },
            Objects =
            {
                new ObjectSettings
                {
                    HtmlContent = html,
                    WebSettings = new WebSettings
                    {
                        DefaultEncoding = "utf-8"
                    }
                }
            }
        };

        return _converter.Convert(doc);
    }

    private CvZipFile GeneraZip(string html, Curriculum1 cv)
    {
        var pdfBytes = GeneraPDF(html);
        var nomeDocumento = $"Curriculum - {cv.anagrafica?.Nome} {cv.anagrafica?.Cognome} {DateTime.Now:dd-MM-yyyy}";

        var xmlSerializer = new XmlSerializer(typeof(XmlCurriculum));
        var xmlCurriculum = new XmlCurriculum { curriculum = cv };
        byte[] xmlBytes;
        using (var xmlStream = new MemoryStream())
        {
            xmlSerializer.Serialize(xmlStream, xmlCurriculum);
            xmlBytes = xmlStream.ToArray();
        }

        using var outStream = new MemoryStream();
        using (var archive = new System.IO.Compression.ZipArchive(outStream, System.IO.Compression.ZipArchiveMode.Create, true))
        {
            var pdfEntry = archive.CreateEntry($"{nomeDocumento}.pdf", System.IO.Compression.CompressionLevel.Optimal);
            using (var pdfEntryStream = pdfEntry.Open())
            {
                pdfEntryStream.Write(pdfBytes, 0, pdfBytes.Length);
            }

            var xmlEntry = archive.CreateEntry($"{nomeDocumento}.xml", System.IO.Compression.CompressionLevel.Optimal);
            using (var xmlEntryStream = xmlEntry.Open())
            {
                xmlEntryStream.Write(xmlBytes, 0, xmlBytes.Length);
            }
        }

        return new CvZipFile
        {
            Content = outStream.ToArray(),
            ContentType = "application/zip",
            NomeConEstensione = $"{nomeDocumento}.zip"
        };
    }
}