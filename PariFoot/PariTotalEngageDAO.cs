using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace PariFoot
{
    public class PariTotalEngageDAO
    {
        public PariTotalEngage[] findPari(int idMatchs)
        {
            PariTotalEngage[] resultat = null;
            ArrayList listePari = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from pariTotalEngage where idMatch='"+ idMatchs + "'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    int idUtilisateur1 = int.Parse(reader["idUtilisateur1"].ToString());
                    int idUtilisateur2 = int.Parse(reader["idUtilisateur2"].ToString());
                    int idEquipe1 = int.Parse(reader["idEquipe1"].ToString());
                    int idEquipe2 = int.Parse(reader["idEquipe2"].ToString());
                    String categoriePari = reader["categoriePari"].ToString();
                    int compensation1 = int.Parse(reader["compensation1"].ToString());
                    int compensation2 = int.Parse(reader["compensation2"].ToString());
                    int jeton = int.Parse(reader["jeton"].ToString());
                    int matchNul = int.Parse(reader["matchNul"].ToString());
                    listePari.Add(new PariTotalEngage(id, idMatch, idUtilisateur1, idUtilisateur2, idEquipe1, idEquipe2, categoriePari, compensation1, compensation2, jeton, matchNul));
                }
                resultat = new PariTotalEngage[listePari.Count];
                for (int i = 0; i < listePari.Count; i++)
                {
                    resultat[i] = (PariTotalEngage)listePari[i];
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

        public void insertPariTotalEngage(PariTotalEngage pariTotal)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into pariTotalEngage values('" + pariTotal.getIdMatch() + "','" + pariTotal.getIdUtilisateur1() + "','" + pariTotal.getIdUtilisateur2() + "','" + pariTotal.getIdEquipe1() + "','" + pariTotal.getIdEquipe2() + "','" + pariTotal.getCategoriePari() + "','" + pariTotal.getCompensation1() + "','" + pariTotal.getCompensation2() + "','" + pariTotal.getJeton() + "','" + pariTotal.getMatchNul() + "')";
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