using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace PariFoot
{
    public class UtilisateurDAO
    {
        public Utilisateur[] findUtilisateur(String nom, String mdp)
        {
            Utilisateur[] resultat = null;
            ArrayList listeUtilisateur = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from utilisateur where nom='" + nom + "' and motDePasse='" + mdp + "'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nomUtilisateur = reader["nom"].ToString();
                    String motDePasse = reader["motDePasse"].ToString();
                    int jeton = int.Parse(reader["jeton"].ToString());
                    listeUtilisateur.Add(new Utilisateur(id, nomUtilisateur, motDePasse, jeton));
                }
                resultat = new Utilisateur[listeUtilisateur.Count];
                for (int i = 0; i < listeUtilisateur.Count; i++)
                {
                    resultat[i] = (Utilisateur)listeUtilisateur[i];
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return resultat;
        }

        public Utilisateur[] findUtilisateur(int ids)
        {
            Utilisateur[] resultat = null;
            ArrayList listeUtilisateur = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from utilisateur where id='" + ids + "'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nomUtilisateur = reader["nom"].ToString();
                    String motDePasse = reader["motDePasse"].ToString();
                    int jeton = int.Parse(reader["jeton"].ToString());
                    listeUtilisateur.Add(new Utilisateur(id, nomUtilisateur, motDePasse, jeton));
                }
                resultat = new Utilisateur[listeUtilisateur.Count];
                for (int i = 0; i < listeUtilisateur.Count; i++)
                {
                    resultat[i] = (Utilisateur)listeUtilisateur[i];
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return resultat;
        }

        public void insertUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into utilisateur values('" + utilisateur.getNomUtilisateur() + "','" + utilisateur.getMotDePasse() + "','" + utilisateur.getJeton() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }

        public void updateJetonUtil(int nouveauJeton, int id)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update utilisateur set jeton='" + nouveauJeton + "' where id='" + id + "'";
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