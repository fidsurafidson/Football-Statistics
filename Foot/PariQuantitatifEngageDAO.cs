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
    class PariQuantitatifEngageDAO
    {
        public PariQuantitatifEngage[] findPari()
        {
            PariQuantitatifEngage[] resultat = null;
            ArrayList listePari = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from pariQuantitatifEngage");
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
                    int jeton1 = int.Parse(reader["jeton1"].ToString());
                    int jeton2 = int.Parse(reader["jeton2"].ToString());
                    int forfait1 = int.Parse(reader["forfait1"].ToString());
                    int forfait2 = int.Parse(reader["forfait2"].ToString());
                    int matchNul = int.Parse(reader["matchNul"].ToString());
                    listePari.Add(new PariQuantitatifEngage(id, idMatch, idUtilisateur1, idUtilisateur2, idEquipe1, idEquipe2, categoriePari, compensation1, compensation2, jeton1, jeton2, forfait1, forfait2, matchNul));
                }
                resultat = new PariQuantitatifEngage[listePari.Count];
                for (int i = 0; i < listePari.Count; i++)
                {
                    resultat[i] = (PariQuantitatifEngage)listePari[i];
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

        public PariQuantitatifEngage[] findPari(int ids)
        {
            PariQuantitatifEngage[] resultat = null;
            ArrayList listePari = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from pariQuantitatifEngage where id='" + ids + "'");
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
                    int jeton1 = int.Parse(reader["jeton1"].ToString());
                    int jeton2 = int.Parse(reader["jeton2"].ToString());
                    int forfait1 = int.Parse(reader["forfait1"].ToString());
                    int forfait2 = int.Parse(reader["forfait2"].ToString());
                    int matchNul = int.Parse(reader["matchNul"].ToString());
                    listePari.Add(new PariQuantitatifEngage(id, idMatch, idUtilisateur1, idUtilisateur2, idEquipe1, idEquipe2, categoriePari, compensation1, compensation2, jeton1, jeton2, forfait1, forfait2, matchNul));
                }
                resultat = new PariQuantitatifEngage[listePari.Count];
                for (int i = 0; i < listePari.Count; i++)
                {
                    resultat[i] = (PariQuantitatifEngage)listePari[i];
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

        public void insertPariQuantitatifEngage(PariQuantitatifEngage pariQuantitatif)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into pariQuantitatifEngage values('" + pariQuantitatif.getIdMatch() + "','" + pariQuantitatif.getIdUtilisateur1() + "','" + pariQuantitatif.getIdUtilisateur2() + "','" + pariQuantitatif.getIdEquipe1() + "','" + pariQuantitatif.getIdEquipe2() + "','" + pariQuantitatif.getCategoriePari() + "','" + pariQuantitatif.getCompensation1() + "','" + pariQuantitatif.getCompensation2() + "','" + pariQuantitatif.getJeton1() + "','" + pariQuantitatif.getJeton2() + "','" + pariQuantitatif.getForfait1() + "','" + pariQuantitatif.getForfait2() + "','" + pariQuantitatif.getMatchNul() + "')";
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
