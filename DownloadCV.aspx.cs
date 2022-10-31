using PortFolio.CurriculumGenerator.Models;
using System;
using System.Web.UI;

namespace PortFolio.CurriculumGenerator
{
    public partial class DownloadCV : Page
    {
        Curriculum cv = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Prendo il cv dalla session
            cv = (Curriculum)Session["CV"];
            // Pulisco la session
            Session["CV"] = null;
        }
    }
}