using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foot
{
    class FeuilleMatchJoueurDAO
    {
        public FeuilleMatchJoueur[] findFMJoueur()
        {
            FeuilleMatchJoueur[] resultat = null;
            ArrayList listeFM = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from FeuilleMatchJoueur");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    int idJoueur = int.Parse(reader["idJoueur"].ToString());
                    int minuteJoue = int.Parse(reader["minuteJoue"].ToString());
                    int ballonJoue = int.Parse(reader["ballonTouche"].ToString());
                    int tir = int.Parse(reader["tir"].ToString());
                    int tirCadre = int.Parse(reader["tirCadre"].ToString());
                    int but = int.Parse(reader["but"].ToString());
                    int passeDecisive = int.Parse(reader["passeDecisive"].ToString());
                    listeFM.Add(new FeuilleMatchJoueur(id, idMatch, idEquipe, idJoueur, minuteJoue, ballonJoue, tir, tirCadre, but, passeDecisive));
                }
                resultat = new FeuilleMatchJoueur[listeFM.Count];
                for (int i = 0; i < listeFM.Count; i++)
                {
                    resultat[i] = (FeuilleMatchJoueur)listeFM[i];
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

        public FeuilleMatchJoueur[] findFMJoueur(int idJ)
        {
            FeuilleMatchJoueur[] resultat = null;
            ArrayList listeFM = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from FeuilleMatchJoueur where id=" + idJ);
            //MessageBox.Show(requete);
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    int idJoueur = int.Parse(reader["idJoueur"].ToString());
                    int minuteJoue = int.Parse(reader["minuteJoue"].ToString());
                    int ballonJoue = int.Parse(reader["ballonTouche"].ToString());
                    int tir = int.Parse(reader["tir"].ToString());
                    int tirCadre = int.Parse(reader["tirCadre"].ToString());
                    int but = int.Parse(reader["but"].ToString());
                    int passeDecisive = int.Parse(reader["passeDecisive"].ToString());
                    listeFM.Add(new FeuilleMatchJoueur(id, idMatch, idEquipe, idJoueur, minuteJoue, ballonJoue, tir, tirCadre, but, passeDecisive));
                }
                resultat = new FeuilleMatchJoueur[listeFM.Count];
                for (int i = 0; i < listeFM.Count; i++)
                {
                    resultat[i] = (FeuilleMatchJoueur)listeFM[i];
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

        public FeuilleMatchJoueur[] findFMFinal(String equipe, int idMatch)
        {
            FeuilleMatchJoueur[] resultat = null;
            ArrayList listeFM = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select sum(f.tir) as tir,sum(f.tirCadre) as tirCadre,sum(f.but) as but from feuilleMatchJoueur f join equipe e on e.id=f.idEquipe where e.nom='" + equipe+"' and f.idMatch='"+idMatch+"'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int tir = int.Parse(reader["tir"].ToString());
                    int tirCadre = int.Parse(reader["tirCadre"].ToString());
                    int but = int.Parse(reader["but"].ToString());
                    listeFM.Add(new FeuilleMatchJoueur(tir, tirCadre, but));
                }
                resultat = new FeuilleMatchJoueur[listeFM.Count];
                for (int i = 0; i < listeFM.Count; i++)
                {
                    resultat[i] = (FeuilleMatchJoueur)listeFM[i];
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

        public void insertFeuilleMatchJoueur(FeuilleMatchJoueur feuilleMatchJ)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into FeuilleMatchJoueur values('" + feuilleMatchJ.getIdMatch() + "','" + feuilleMatchJ.getIdEquipe() + "','" + feuilleMatchJ.getIdJoueur() + "','" + feuilleMatchJ.getMinuteJoue() + "','" + feuilleMatchJ.getBallonTouche() + "','" + feuilleMatchJ.getTir() + "','" + feuilleMatchJ.getTirCadre() + "','" + feuilleMatchJ.getBut() + "','" + feuilleMatchJ.getPasseDecisive() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
