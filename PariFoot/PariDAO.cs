using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace PariFoot
{
    public class PariDAO
    {
        public Pari[] findPari()
        {
            Pari[] resultat = null;
            ArrayList listePari = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from pari");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    String typePari = reader["typePari"].ToString();
                    String categoriePari = reader["categoriePari"].ToString();
                    int compensation = int.Parse(reader["compensation"].ToString());
                    int montant = int.Parse(reader["montant"].ToString());
                    int forfait = int.Parse(reader["forfait"].ToString());
                    int matchNul = int.Parse(reader["matchNul"].ToString());
                    int etat = int.Parse(reader["etat"].ToString());
                    listePari.Add(new Pari(id, idMatch, idUtilisateur, idEquipe, typePari, categoriePari, compensation, montant, forfait, matchNul, etat));
                }
                resultat = new Pari[listePari.Count];
                for (int i = 0; i < listePari.Count; i++)
                {
                    resultat[i] = (Pari)listePari[i];
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

        public Pari[] findPariById(int idPari)
        {
            Pari[] resultat = null;
            ArrayList listePari = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from pari where id='"+idPari+"'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    String typePari = reader["typePari"].ToString();
                    String categoriePari = reader["categoriePari"].ToString();
                    int compensation = int.Parse(reader["compensation"].ToString());
                    int montant = int.Parse(reader["montant"].ToString());
                    int forfait = int.Parse(reader["forfait"].ToString());
                    int matchNul = int.Parse(reader["matchNul"].ToString());
                    int etat = int.Parse(reader["etat"].ToString());
                    listePari.Add(new Pari(id, idMatch, idUtilisateur, idEquipe, typePari, categoriePari, compensation, montant, forfait, matchNul, etat));
                }
                resultat = new Pari[listePari.Count];
                for (int i = 0; i < listePari.Count; i++)
                {
                    resultat[i] = (Pari)listePari[i];
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

        public Pari[] findDernierPari()
        {
            Pari[] resultat = null;
            ArrayList listePari = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from pari order by id desc");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    String typePari = reader["typePari"].ToString();
                    String categoriePari = reader["categoriePari"].ToString();
                    int compensation = int.Parse(reader["compensation"].ToString());
                    int montant = int.Parse(reader["montant"].ToString());
                    int forfait = int.Parse(reader["forfait"].ToString());
                    int matchNul = int.Parse(reader["matchNul"].ToString());
                    int etat = int.Parse(reader["etat"].ToString());
                    listePari.Add(new Pari(id, idMatch, idUtilisateur, idEquipe, typePari, categoriePari, compensation, montant, forfait, matchNul, etat));
                }
                resultat = new Pari[listePari.Count];
                for (int i = 0; i < listePari.Count; i++)
                {
                    resultat[i] = (Pari)listePari[i];
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

        public Pari[] findProposition(int idMatchs, String categorie)
        {
            Pari[] resultat = null;
            ArrayList listePari = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select p.id,p.idMatch,u.nom as nomUtilisateur,e.nom as nomEquipe,p.typePari,p.categoriePari,p.compensation,p.montant,p.forfait,p.matchNul,p.etat from pari p join utilisateur u on p.idUtilisateur=u.id join equipe e on p.idEquipe=e.id where p.idMatch='"+ idMatchs +"' and p.categoriePari='"+ categorie +"' and p.etat=0");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idMatch = int.Parse(reader["idMatch"].ToString());
                    String nomUtilisateur = reader["nomUtilisateur"].ToString();
                    String nomEquipe = reader["nomEquipe"].ToString();
                    String typePari = reader["typePari"].ToString();
                    String categoriePari = reader["categoriePari"].ToString();
                    int compensation = int.Parse(reader["compensation"].ToString());
                    int montant = int.Parse(reader["montant"].ToString());
                    int forfait = int.Parse(reader["forfait"].ToString());
                    int matchNul = int.Parse(reader["matchNul"].ToString());
                    int etat = int.Parse(reader["etat"].ToString());
                    listePari.Add(new Pari(id, idMatch, nomUtilisateur, nomEquipe, typePari, categoriePari, compensation, montant, forfait, matchNul, etat));
                }
                resultat = new Pari[listePari.Count];
                for (int i = 0; i < listePari.Count; i++)
                {
                    resultat[i] = (Pari)listePari[i];
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

        public void insertPari(Pari pari)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into pari values('" + pari.getIdMatch() + "','" + pari.getIdUtilisateur() + "','" + pari.getIdEquipe() + "','" + pari.getTypePari() + "','" + pari.getCategoriePari() + "','" + pari.getCompensation() + "','" + pari.getMontant() + "','" + pari.getForfait() + "','" + pari.getMatchNul() + "','" + pari.getEtat() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updatePari(int compensation, int montant, int forfait, int id)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update pari set compensation='" + compensation + "' , montant='"+montant+"' , forfait='"+forfait+"' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                // 	MessageBox.Show("Modification reussit");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updatePari(int montant, int id)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update pari set montant='" + montant + "' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                // 	MessageBox.Show("Modification reussit");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updateEtatPari(int etat, int id)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update pari set etat='" + etat + "' where id='" + id + "'";
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