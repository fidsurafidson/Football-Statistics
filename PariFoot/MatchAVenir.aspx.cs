using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PariFoot
{
    public partial class MatchAVenir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["idUtil"]);
            Response.Redirect("~/Demande.aspx?idUtil=" + id);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["idUtil"]);
            Response.Redirect("~/Pret.aspx?idUtil=" + id);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["idUtil"]);
            Response.Redirect("~/SimulationRetard.aspx?idUtil=" + id + "&idDemande=1");
        }
    }
}