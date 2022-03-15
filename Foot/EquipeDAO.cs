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
    public class EquipeDAO
    {
        public Equipe[] findEquipe()
        {
            Equipe[] resultat = null;
            ArrayList listeEquipe = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from Equipe");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    listeEquipe.Add(new Equipe(id, nom));
                }
                resultat = new Equipe[listeEquipe.Count];
                for (int i = 0; i < listeEquipe.Count; i++)
                {
                    resultat[i] = (Equipe)listeEquipe[i];
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

        public Equipe[] findEquipe(String nomEquipe)
        {
            Equipe[] resultat = null;
            ArrayList listeEquipe = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from Equipe where nom='"+ nomEquipe + "'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    listeEquipe.Add(new Equipe(id, nom));
                }
                resultat = new Equipe[listeEquipe.Count];
                for (int i = 0; i < listeEquipe.Count; i++)
                {
                    resultat[i] = (Equipe)listeEquipe[i];
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

        public Equipe[] findEquipe(int idEquipe)
        {
            Equipe[] resultat = null;
            ArrayList listeEquipe = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from Equipe where id='" + idEquipe + "'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    listeEquipe.Add(new Equipe(id, nom));
                }
                resultat = new Equipe[listeEquipe.Count];
                for (int i = 0; i < listeEquipe.Count; i++)
                {
                    resultat[i] = (Equipe)listeEquipe[i];
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
    }
}
