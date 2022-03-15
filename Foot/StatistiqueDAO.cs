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
    public class StatistiqueDAO
    {
        public Statistique[] findStatistiqueMatch(int idMatchs)
        {
            Statistique[] resultat = null;
            ArrayList listeStatistique = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from statistique where idMatch='"+idMatchs+"'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    String dateMatch = reader["dateMatch"].ToString();
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    int possession = int.Parse(reader["possession"].ToString());
                    int tir = int.Parse(reader["tir"].ToString());
                    int tirCadre = int.Parse(reader["tirCadre"].ToString());
                    int but = int.Parse(reader["but"].ToString());
                    listeStatistique.Add(new Statistique(id, idMatch, dateMatch, idEquipe, possession, tir, tirCadre, but));
                }
                resultat = new Statistique[listeStatistique.Count];
                for (int i = 0; i < listeStatistique.Count; i++)
                {
                    resultat[i] = (Statistique)listeStatistique[i];
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

        public void insertStatistique(Statistique statistique)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into statistique values('" + statistique.getIdMatch() + "','" + statistique.getDateMatch() + "','" + statistique.getIdEquipe() + "','" + statistique.getPossession() + "','" + statistique.getTir() + "','" + statistique.getTirCadre() + "','" + statistique.getBut() + "')";
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
