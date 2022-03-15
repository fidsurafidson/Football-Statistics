using Foot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PariFoot
{
    public partial class ConfigurationPari : System.Web.UI.Page
    {
        int idUtil = 0;
        int idMatch = 0;
        String typePari = null;
        String categorie = null;
        String equipe1 = null;
        String equipe2 = null;
        int idEquipe1 = 0;
        int idEquipe2 = 0;
        int compensation1 = 0;
        int compensation2 = 0;
        int jeton1 = 0;
        int jeton2 = 0;
        int forfait1 = 0;
        int forfait2 = 0;
        int matchNul = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            idUtil = int.Parse(Request.QueryString["idUtil"]);
            idMatch = int.Parse(Request.QueryString["idMatch"]);
            typePari = DropDownList1.Text;
            categorie = Request.QueryString["categorie"];
            ListeMatchDAO listeMatch = new ListeMatchDAO();
            ListeMatch[] listeMatch1 = listeMatch.findListeMatchById(idMatch);
            for (int i = 0; i < listeMatch1.Length; i++)
            {
                equipe1 = listeMatch1[i].getNomEquipe1();
                equipe2 = listeMatch1[i].getNomEquipe2();
            }
            EquipeDAO listeEquipe = new EquipeDAO();
            Equipe[] listeEquipe1 = listeEquipe.findEquipe(equipe1);
            for (int i = 0; i < listeEquipe1.Length; i++)
            {
                idEquipe1 = listeEquipe1[i].getId();
            }
            Equipe[] listeEquipe2 = listeEquipe.findEquipe(equipe2);
            for (int i = 0; i < listeEquipe2.Length; i++)
            {
                idEquipe2 = listeEquipe2[i].getId();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            compensation1 = int.Parse(TextBox1.Text);
            compensation2 = int.Parse(TextBox2.Text);
            jeton1 = int.Parse(TextBox3.Text);
            jeton2 = int.Parse(TextBox4.Text);
            if (typePari=="Quantitatif")
            {
                forfait1 = int.Parse(TextBox5.Text);
                forfait2 = int.Parse(TextBox6.Text);
            }
            int egalite = 0;
            foreach (ListItem list in CheckBoxList1.Items)
            {
                if (list.Selected)
                {
                    egalite = int.Parse(list.Value);
                }
            }
            if (egalite == 1)
            {
                matchNul = idEquipe1;
            }
            else if (egalite == 2)
            {
                matchNul = idEquipe2;
            }
            PariDAO pari = new PariDAO();
            Pari pari1 = new Pari(idMatch, idUtil, idEquipe1, typePari, categorie, compensation1, jeton1, forfait1, matchNul, 0);
            pari.insertPari(pari1);
            /*Pari[] dernierPari = pari.findDernierPari();
            int idPariSource = dernierPari[0].getId();*/
            Pari pari2 = new Pari(idMatch, idUtil, idEquipe2, typePari, categorie, compensation2, jeton2, forfait2, matchNul, 1);
            pari.insertPari(pari2);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            compensation1 = int.Parse(TextBox1.Text);
            compensation2 = int.Parse(TextBox2.Text);
            jeton1 = int.Parse(TextBox3.Text);
            jeton2 = int.Parse(TextBox4.Text);
            if (typePari == "Quantitatif")
            {
                forfait1 = int.Parse(TextBox5.Text);
                forfait2 = int.Parse(TextBox6.Text);
            }
            int egalite = 0;
            foreach (ListItem list in CheckBoxList1.Items)
            {
                if (list.Selected)
                {
                    egalite = int.Parse(list.Value);
                }
            }
            if (egalite == 1)
            {
                matchNul = idEquipe1;
            }
            else if (egalite == 2)
            {
                matchNul = idEquipe2;
            }
            PariDAO pari = new PariDAO();
            Pari pari1 = new Pari(idMatch, idUtil, idEquipe2, typePari, categorie, compensation2, jeton2, forfait2, matchNul, 0);
            pari.insertPari(pari1);
            Pari[] dernierPari = pari.findDernierPari();
            int idPariSource = dernierPari[0].getId();
            Pari pari2 = new Pari(idMatch, idUtil, idEquipe1, typePari, categorie, compensation1, jeton1, forfait1, matchNul, idPariSource);
            pari.insertPari(pari2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListeProposition.aspx?idUtil=" + idUtil + "&idMatch="+ idMatch +"&categorie="+ categorie);
        }
    }
}