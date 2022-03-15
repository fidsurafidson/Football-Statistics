using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace PariFoot
{
    public class DemandePretDAO
    {
        public DemandePret[] findDemande()
        {
            DemandePret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from demandePret order by id desc");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateDeblocage = Convert.ToDateTime(reader["dateDeblocage"].ToString());
                    int jeton = int.Parse(reader["jeton"].ToString());
                    int etatValidation = int.Parse(reader["etatValidation"].ToString());
                    listeMatch.Add(new DemandePret(id, idUtilisateur, dateDeblocage, jeton, etatValidation));
                }
                resultat = new DemandePret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (DemandePret)listeMatch[i];
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

        public DemandePret[] findDemandeById(int idDemande)
        {
            DemandePret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from demandePret where id="+ idDemande);
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateDeblocage = Convert.ToDateTime(reader["dateDeblocage"].ToString());
                    int jeton = int.Parse(reader["jeton"].ToString());
                    int etatValidation = int.Parse(reader["etatValidation"].ToString());
                    listeMatch.Add(new DemandePret(id, idUtilisateur, dateDeblocage, jeton, etatValidation));
                }
                resultat = new DemandePret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (DemandePret)listeMatch[i];
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

        public DemandePret[] findDemandeByUtil(int idUtil)
        {
            DemandePret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from demandePret where idUtilisateur=" + idUtil);
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateDeblocage = Convert.ToDateTime(reader["dateDeblocage"].ToString());
                    int jeton = int.Parse(reader["jeton"].ToString());
                    int etatValidation = int.Parse(reader["etatValidation"].ToString());
                    listeMatch.Add(new DemandePret(id, idUtilisateur, dateDeblocage, jeton, etatValidation));
                }
                resultat = new DemandePret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (DemandePret)listeMatch[i];
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

        public DemandePret[] findDemandeNonValide()
        {
            DemandePret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from demandePret where etatValidation=0");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateDeblocage = Convert.ToDateTime(reader["dateDeblocage"].ToString());
                    int jeton = int.Parse(reader["jeton"].ToString());
                    int etatValidation = int.Parse(reader["etatValidation"].ToString());
                    listeMatch.Add(new DemandePret(id, idUtilisateur, dateDeblocage, jeton, etatValidation));
                }
                resultat = new DemandePret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (DemandePret)listeMatch[i];
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

        public DemandePret[] findDemandeValide()
        {
            DemandePret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from demandePret where etatValidation=1");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateDeblocage = Convert.ToDateTime(reader["dateDeblocage"].ToString());
                    int jeton = int.Parse(reader["jeton"].ToString());
                    int etatValidation = int.Parse(reader["etatValidation"].ToString());
                    listeMatch.Add(new DemandePret(id, idUtilisateur, dateDeblocage, jeton, etatValidation));
                }
                resultat = new DemandePret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (DemandePret)listeMatch[i];
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

        public void insertDemande(DemandePret demande)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into demandePret values('" + demande.getIdUtilisateur() + "','" + demande.getDateDeblocage() + "','" + demande.getJeton() + "','" + demande.getEtatValidation() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updateDemande(int id, int etat)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update demandePret set etatValidation='" + etat + "' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                // 	MessageBox.Show("Modification reussit");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updateDateDeblocage(int id, String daty)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update demandePret set dateDeblocage='" + daty + "' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                // 	MessageBox.Show("Modification reussit");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}