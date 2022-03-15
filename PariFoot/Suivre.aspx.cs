using Foot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PariFoot
{
    public partial class Suivre : System.Web.UI.Page
    {
        int idUtil1 = 0;
        int idMatch = 0;
        int idPari = 0;
        int idEquipe1 = 0;
        String typePari = null;
        String categoriePari = null;
        int compensation1 = 0;
        int jeton1 = 0;
        int forfait1 = 0;
        int matchNul = 0;
        int idEquipe2 = 0;
        int compensation2 = 0;
        int jeton2 = 0;
        int forfait2 = 0;
        int idPari2 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            PariDAO pari = new PariDAO();
            /*idPari2 = int.Parse(Request.QueryString["idPari"]) + 1;
            Pari[] pari2 = pari.findPariById(idPari2);
            
            for (int i = 0; i < pari2.Length; i++)
            {
                idEquipe2 = pari2[i].getIdEquipe();
                compensation2 = pari2[i].getCompensation();
                jeton2 = pari2[i].getMontant();
                forfait2 = pari2[i].getForfait();
                TextBox2.Text = pari2[i].getCompensation().ToString();
                TextBox4.Text = pari2[i].getMontant().ToString();
                TextBox6.Text = pari2[i].getForfait().ToString();
            }*/

            idPari = int.Parse(Request.QueryString["idPari"]);
            Pari[] pari1 = pari.findPariById(idPari);
            
            for (int i = 0; i < pari1.Length; i++)
            {
                idUtil1 = pari1[i].getIdUtilisateur();
                idMatch = pari1[i].getIdMatch();
                idEquipe1 = pari1[i].getIdEquipe();
                typePari = pari1[i].getTypePari();
                categoriePari = pari1[i].getCategoriePari();
                compensation1 = pari1[i].getCompensation();
                jeton1 = pari1[i].getMontant();
                forfait1 = pari1[i].getForfait();
                matchNul = pari1[i].getMatchNul();
            }
            String equipe1 = null;
            EquipeDAO liste = new EquipeDAO();
            Equipe[] liste1 = liste.findEquipe(idEquipe1);
            for (int i = 0; i < liste1.Length; i++)
            {
                equipe1 = liste1[i].getNom();
            }

            ListeMatchDAO listeMatch = new ListeMatchDAO();
            ListeMatch[] listeMatch1 = listeMatch.findListeMatchById(idMatch);
            String equipe2 = null;
            for (int i=0; i<listeMatch1.Length; i++)
            {
                if (listeMatch1[i].getNomEquipe1() == equipe1)
                {
                    equipe2 = listeMatch1[i].getNomEquipe2();
                }
                else if (listeMatch1[i].getNomEquipe2() == equipe1)
                {
                    equipe2 = listeMatch1[i].getNomEquipe1();
                }
            }
            Equipe[] liste2 = liste.findEquipe(equipe2);
            for (int i = 0; i < liste2.Length; i++)
            {
                idEquipe2 = liste2[i].getId();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // insert table Pari
            PariDAO listePari = new PariDAO();
            PariTotalEngageDAO pariTotalEngage = new PariTotalEngageDAO();
            PariQuantitatifEngageDAO pariQuantitatifEngage = new PariQuantitatifEngageDAO();
            int idUtilAdv = int.Parse(Request.QueryString["idUtil"]);
            int compensationAdv = int.Parse(TextBox2.Text);
            int jetonAdv = int.Parse(TextBox4.Text);
            int forfaitAdv = 0;
            // Pari Quantitatif
            if (typePari == "Quantitatif")
            {
                forfaitAdv = int.Parse(TextBox6.Text);
                Pari nouveau = new Pari(idMatch, idUtilAdv, idEquipe2, typePari, categoriePari, compensationAdv, jetonAdv, forfaitAdv, matchNul, 1);
                listePari.insertPari(nouveau);
                listePari.updateEtatPari(1, idPari);
                // insert table PariTotalEngage
                PariQuantitatifEngage pariQuantitatifEngage1 = new PariQuantitatifEngage(idMatch, idUtil1, idUtilAdv, idEquipe1, idEquipe2, categoriePari, compensation1, compensationAdv, jeton1, jetonAdv, forfait1, forfaitAdv, matchNul);
                pariQuantitatifEngage.insertPariQuantitatifEngage(pariQuantitatifEngage1);
            }
            // Pari Total
            else
            {
                if (jeton1 > jetonAdv)
                {
                    Pari nouveau = new Pari(idMatch, idUtilAdv, idEquipe2, typePari, categoriePari, compensationAdv, jetonAdv, forfaitAdv, matchNul, 1);
                    listePari.insertPari(nouveau);
                    int resteJeton = jeton1 - jetonAdv;
                    listePari.updatePari(resteJeton, idPari);
                    // insert table PariTotalEngage
                    PariTotalEngage pariTotalEngage1 = new PariTotalEngage(idMatch, idUtil1, idUtilAdv, idEquipe1, idEquipe2, categoriePari, compensation1, compensationAdv, jetonAdv, matchNul);
                    pariTotalEngage.insertPariTotalEngage(pariTotalEngage1);
                }
                else if (jeton1 < jetonAdv)
                {
                    int resteJeton = jetonAdv - jeton1;
                    Pari nouveau = new Pari(idMatch, idUtilAdv, idEquipe2, typePari, categoriePari, compensationAdv, resteJeton, forfaitAdv, matchNul, 0);
                    listePari.insertPari(nouveau);
                    listePari.updateEtatPari(1, idPari);
                    // insert table PariTotalEngage
                    PariTotalEngage pariTotalEngage1 = new PariTotalEngage(idMatch, idUtil1, idUtilAdv, idEquipe1, idEquipe2, categoriePari, compensation1, compensationAdv, jeton1, matchNul);
                    pariTotalEngage.insertPariTotalEngage(pariTotalEngage1);
                }
                else
                {
                    Pari nouveau = new Pari(idMatch, idUtilAdv, idEquipe2, typePari, categoriePari, compensationAdv, jetonAdv, forfaitAdv, matchNul, 1);
                    listePari.insertPari(nouveau);
                    listePari.updateEtatPari(1, idPari);
                    // insert table PariTotalEngage
                    PariTotalEngage pariTotalEngage1 = new PariTotalEngage(idMatch, idUtil1, idUtilAdv, idEquipe1, idEquipe2, categoriePari, compensation1, compensationAdv, jetonAdv, matchNul);
                    pariTotalEngage.insertPariTotalEngage(pariTotalEngage1);
                }
            }

            
        }
    }
}