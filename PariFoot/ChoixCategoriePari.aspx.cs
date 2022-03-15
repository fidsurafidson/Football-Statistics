using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PariFoot
{
    public partial class ChoixCategoriePari : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int idUtil = int.Parse(Request.QueryString["idUtil"]);
            int idMatch = int.Parse(Request.QueryString["idMatch"]);
            String categorie = "possession";
            Response.Redirect("~/ConfigurationPari.aspx?idUtil="+idUtil+"&idMatch="+idMatch+"&categorie=" + categorie);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idUtil = int.Parse(Request.QueryString["idUtil"]);
            int idMatch = int.Parse(Request.QueryString["idMatch"]);
            String categorie = "tir";
            Response.Redirect("~/ConfigurationPari.aspx?idUtil=" + idUtil + "&idMatch=" + idMatch + "&categorie=" + categorie);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int idUtil = int.Parse(Request.QueryString["idUtil"]);
            int idMatch = int.Parse(Request.QueryString["idMatch"]);
            String categorie = "tir cadre";
            Response.Redirect("~/ConfigurationPari.aspx?idUtil=" + idUtil + "&idMatch=" + idMatch + "&categorie=" + categorie);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int idUtil = int.Parse(Request.QueryString["idUtil"]);
            int idMatch = int.Parse(Request.QueryString["idMatch"]);
            String categorie = "but";
            Response.Redirect("~/ConfigurationPari.aspx?idUtil=" + idUtil + "&idMatch=" + idMatch + "&categorie=" + categorie);
        }
    }
}