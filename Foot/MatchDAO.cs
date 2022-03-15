using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foot
{
    class MatchDAO
    {
        public Match[] findDernierMatch()
        {
            Match[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from Match order by id desc");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    int equipe1 = int.Parse(reader["idEquipe1"].ToString());
                    int equipe2 = int.Parse(reader["idEquipe2"].ToString());
                    DateTime dateMatch = Convert.ToDateTime(reader["dateDebut"].ToString());
                    listeMatch.Add(new Match(id, idMatch, equipe1, equipe2, dateMatch));
                }
                resultat = new Match[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (Match)listeMatch[i];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return resultat;
        }

        public void insertMatch(Match match)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into Match values('" + match.getIdMatch() + "','" + match.getEquipe1() + "','" + match.getEquipe2() + "','" + match.getDateMatch() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void changement(Possession possession, int seconde, int miTemps, Joueur[] titulaireJoueurA, Joueur[] titulaireJoueurB)
        {
            if (seconde < miTemps)
            {
                possession.getLinkLabel1().Text = titulaireJoueurA[0].getNom();
                possession.getLinkLabel2().Text = titulaireJoueurA[1].getNom();
                possession.getLinkLabel3().Text = titulaireJoueurA[2].getNom();
                possession.getLinkLabel4().Text = titulaireJoueurA[3].getNom();
                possession.getLinkLabel5().Text = titulaireJoueurA[4].getNom();
                possession.getLinkLabel6().Text = titulaireJoueurA[5].getNom();
                possession.getLinkLabel7().Text = titulaireJoueurA[6].getNom();
                possession.getLinkLabel8().Text = titulaireJoueurA[7].getNom();
                possession.getLinkLabel9().Text = titulaireJoueurA[8].getNom();
                possession.getLinkLabel10().Text = titulaireJoueurA[9].getNom();
                possession.getLinkLabel11().Text = titulaireJoueurA[10].getNom();
                possession.getLinkLabel1().BackColor = Color.Blue;
                possession.getLinkLabel2().BackColor = Color.Blue;
                possession.getLinkLabel3().BackColor = Color.Blue;
                possession.getLinkLabel4().BackColor = Color.Blue;
                possession.getLinkLabel5().BackColor = Color.Blue;
                possession.getLinkLabel6().BackColor = Color.Blue;
                possession.getLinkLabel7().BackColor = Color.Blue;
                possession.getLinkLabel8().BackColor = Color.Blue;
                possession.getLinkLabel9().BackColor = Color.Blue;
                possession.getLinkLabel10().BackColor = Color.Blue;
                possession.getLinkLabel11().BackColor = Color.Blue;

                possession.getLinkLabel12().Text = titulaireJoueurB[0].getNom();
                possession.getLinkLabel13().Text = titulaireJoueurB[1].getNom();
                possession.getLinkLabel14().Text = titulaireJoueurB[2].getNom();
                possession.getLinkLabel15().Text = titulaireJoueurB[3].getNom();
                possession.getLinkLabel16().Text = titulaireJoueurB[4].getNom();
                possession.getLinkLabel17().Text = titulaireJoueurB[5].getNom();
                possession.getLinkLabel18().Text = titulaireJoueurB[6].getNom();
                possession.getLinkLabel19().Text = titulaireJoueurB[7].getNom();
                possession.getLinkLabel20().Text = titulaireJoueurB[8].getNom();
                possession.getLinkLabel21().Text = titulaireJoueurB[9].getNom();
                possession.getLinkLabel22().Text = titulaireJoueurB[10].getNom();
                possession.getLinkLabel12().BackColor = Color.Red;
                possession.getLinkLabel13().BackColor = Color.Red;
                possession.getLinkLabel14().BackColor = Color.Red;
                possession.getLinkLabel15().BackColor = Color.Red;
                possession.getLinkLabel16().BackColor = Color.Red;
                possession.getLinkLabel17().BackColor = Color.Red;
                possession.getLinkLabel18().BackColor = Color.Red;
                possession.getLinkLabel19().BackColor = Color.Red;
                possession.getLinkLabel20().BackColor = Color.Red;
                possession.getLinkLabel21().BackColor = Color.Red;
                possession.getLinkLabel22().BackColor = Color.Red;
            }
            else if (seconde >= miTemps)
            {
                possession.getLinkLabel1().Text = titulaireJoueurB[0].getNom();
                possession.getLinkLabel2().Text = titulaireJoueurB[1].getNom();
                possession.getLinkLabel3().Text = titulaireJoueurB[2].getNom();
                possession.getLinkLabel4().Text = titulaireJoueurB[3].getNom();
                possession.getLinkLabel5().Text = titulaireJoueurB[4].getNom();
                possession.getLinkLabel6().Text = titulaireJoueurB[5].getNom();
                possession.getLinkLabel7().Text = titulaireJoueurB[6].getNom();
                possession.getLinkLabel8().Text = titulaireJoueurB[7].getNom();
                possession.getLinkLabel9().Text = titulaireJoueurB[8].getNom();
                possession.getLinkLabel10().Text = titulaireJoueurB[9].getNom();
                possession.getLinkLabel11().Text = titulaireJoueurB[10].getNom();
                possession.getLinkLabel1().BackColor = Color.Red;
                possession.getLinkLabel2().BackColor = Color.Red;
                possession.getLinkLabel3().BackColor = Color.Red;
                possession.getLinkLabel4().BackColor = Color.Red;
                possession.getLinkLabel5().BackColor = Color.Red;
                possession.getLinkLabel6().BackColor = Color.Red;
                possession.getLinkLabel7().BackColor = Color.Red;
                possession.getLinkLabel8().BackColor = Color.Red;
                possession.getLinkLabel9().BackColor = Color.Red;
                possession.getLinkLabel10().BackColor = Color.Red;
                possession.getLinkLabel11().BackColor = Color.Red;

                possession.getLinkLabel12().Text = titulaireJoueurA[0].getNom();
                possession.getLinkLabel13().Text = titulaireJoueurA[1].getNom();
                possession.getLinkLabel14().Text = titulaireJoueurA[2].getNom();
                possession.getLinkLabel15().Text = titulaireJoueurA[3].getNom();
                possession.getLinkLabel16().Text = titulaireJoueurA[4].getNom();
                possession.getLinkLabel17().Text = titulaireJoueurA[5].getNom();
                possession.getLinkLabel18().Text = titulaireJoueurA[6].getNom();
                possession.getLinkLabel19().Text = titulaireJoueurA[7].getNom();
                possession.getLinkLabel20().Text = titulaireJoueurA[8].getNom();
                possession.getLinkLabel21().Text = titulaireJoueurA[9].getNom();
                possession.getLinkLabel22().Text = titulaireJoueurA[10].getNom();
                possession.getLinkLabel12().BackColor = Color.Blue;
                possession.getLinkLabel13().BackColor = Color.Blue;
                possession.getLinkLabel14().BackColor = Color.Blue;
                possession.getLinkLabel15().BackColor = Color.Blue;
                possession.getLinkLabel16().BackColor = Color.Blue;
                possession.getLinkLabel17().BackColor = Color.Blue;
                possession.getLinkLabel18().BackColor = Color.Blue;
                possession.getLinkLabel19().BackColor = Color.Blue;
                possession.getLinkLabel20().BackColor = Color.Blue;
                possession.getLinkLabel21().BackColor = Color.Blue;
                possession.getLinkLabel22().BackColor = Color.Blue;
            }
        }

        public void remplacementA(String nomTitulaire, String nomRemplacant, Possession possession)
        {
            Joueur titulaire = null;
            int indiceTitulaire = 0;
            for (int i=0; i<possession.getTitulaireJoueurA().Length; i++)
            {
                if(possession.getTitulaireJoueurA()[i].getNom() == nomTitulaire)
                {
                    titulaire = possession.getTitulaireJoueurA()[i];
                    //indiceTitulaire = possession.getTitulaireJoueurA()[i].getId();
                    indiceTitulaire = i;
                }
            }

            Joueur remplacant = null;
            int indiceRemplacant = 0;
            for (int i = 0; i < possession.getRemplacantJoueurA().Length; i++)
            {
                if (possession.getRemplacantJoueurA()[i].getNom() == nomRemplacant)
                {
                    remplacant = possession.getRemplacantJoueurA()[i];
                    //indiceRemplacant = possession.getRemplacantJoueurA()[i].getId();
                    indiceRemplacant = i;
                }
            }
            possession.getTitulaireJoueurA()[indiceTitulaire] = remplacant;
            possession.getRemplacantJoueurA()[indiceRemplacant] = titulaire;

            String[] titulaireA = new String[possession.getTitulaireJoueurA().Length];
            for (int i=0; i<possession.getTitulaireJoueurA().Length; i++)
            {
                titulaireA[i] = possession.getTitulaireJoueurA()[i].getNom();
            }
            possession.getComboBox1().DataSource = titulaireA;
            String[] remplacantA = new String[possession.getRemplacantJoueurA().Length];
            for (int i = 0; i < possession.getRemplacantJoueurA().Length; i++)
            {
                remplacantA[i] = possession.getRemplacantJoueurA()[i].getNom();
            }
            possession.getComboBox2().DataSource = remplacantA;
        }

        public void remplacementB(String nomTitulaire, String nomRemplacant, Possession possession)
        {
            Joueur titulaire = null;
            int indiceTitulaire = 0;
            for (int i = 0; i < possession.getTitulaireJoueurB().Length; i++)
            {
                if (possession.getTitulaireJoueurB()[i].getNom() == nomTitulaire)
                {
                    titulaire = possession.getTitulaireJoueurB()[i];
                    indiceTitulaire = i;
                }
            }

            Joueur remplacant = null;
            int indiceRemplacant = 0;
            for (int i = 0; i < possession.getRemplacantJoueurB().Length; i++)
            {
                if (possession.getRemplacantJoueurB()[i].getNom() == nomRemplacant)
                {
                    remplacant = possession.getRemplacantJoueurB()[i];
                    indiceRemplacant = i;
                }
            }
            possession.getTitulaireJoueurB()[indiceTitulaire] = remplacant;
            possession.getRemplacantJoueurB()[indiceRemplacant] = titulaire;

            try
            {
                String[] titulaireB = new String[possession.getTitulaireJoueurB().Length];
                for (int i = 0; i < possession.getTitulaireJoueurB().Length; i++)
                {
                    titulaireB[i] = possession.getTitulaireJoueurB()[i].getNom();
                }
                possession.getComboBox3().DataSource = titulaireB;
                String[] remplacantB = new String[possession.getRemplacantJoueurB().Length];
                for (int i = 0; i < possession.getRemplacantJoueurB().Length; i++)
                {
                    remplacantB[i] = possession.getRemplacantJoueurB()[i].getNom();
                }
                possession.getComboBox4().DataSource = remplacantB;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }

        public int getPossession1MTA(Possession possession)
        {
            int timerA = possession.getTimerA();
            int timerB = possession.getTimerB();
            int timerTotal = timerA + timerB;

            int possessionA = timerA * 100 / timerTotal;
            return possessionA;
        }

        public int getPossession1MTB(Possession possession)
        {
            int timerA = possession.getTimerA();
            int timerB = possession.getTimerB();
            int timerTotal = timerA + timerB;

            int possessionB = timerB * 100 / timerTotal;
            return possessionB;
        }
    }
}
