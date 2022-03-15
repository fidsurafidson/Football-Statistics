using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PariFoot
{
    public partial class ConnexionUtilisateur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UtilisateurDAO utilisateur = new UtilisateurDAO();
            Utilisateur[] utilisateur1 = utilisateur.findUtilisateur(TextBox1.Text, TextBox2.Text);
            if (utilisateur1.Length != 0)
            {
                if (utilisateur1[0].getNomUtilisateur() == "hanitra" && utilisateur1[0].getMotDePasse() == "rakoto")
                {
                    Response.Redirect("~/ListeDemande.aspx");
                }
                else
                {
                    int idUtilisateur = utilisateur1[0].getId();
                    Response.Redirect("~/MatchAVenir.aspx?idUtil=" + idUtilisateur);
                }
            }
            else
            {
                Response.Redirect("~/ConnexionUtilisateur.aspx");
            }
        }
    }
}