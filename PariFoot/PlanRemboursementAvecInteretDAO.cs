using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace PariFoot
{
    public class PlanRemboursementAvecInteretDAO
    {
        public PlanRemboursementAvecInteret[] findDemande()
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from planRemboursementAvecInteret");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public PlanRemboursementAvecInteret[] findDemande(int idDemande, String nouveauDate)
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from planRemboursementAvecInteret where idDemandePret = '"+idDemande+ "' and dateRemboursement > '"+nouveauDate+ "' and etatPaiement=0 order by dateRemboursement asc");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public PlanRemboursementAvecInteret[] findPlanInferieur(int idDemande, String nouveauDate)
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from planRemboursementAvecInteret where idDemandePret = '" + idDemande + "' and dateRemboursement < '" + nouveauDate + "'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public PlanRemboursementAvecInteret[] findPlanInferieurDesc(int idDemande, String nouveauDate)
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from planRemboursementAvecInteret where idDemandePret = '" + idDemande + "' and dateRemboursement < '" + nouveauDate + "' order by dateRemboursement desc");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public PlanRemboursementAvecInteret[] findPlanByIdDemande(int idDemande)
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from planRemboursementAvecInteret where idDemandePret='" + idDemande + "' and etatPaiement=0");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public PlanRemboursementAvecInteret[] findPlanPayeByIdDemande(int idDemande)
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from planRemboursementAvecInteret where idDemandePret='" + idDemande + "' and etatPaiement=1");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public PlanRemboursementAvecInteret[] findDernierPaye(int idDemande)
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select top 1 * planRemboursementAvecInteret where idDemandePret='" + idDemande + "' and etatPaiement=1 order by dateRemboursement desc");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public PlanRemboursementAvecInteret[] findPretNonRembourse(int idUtil)
        {
            PlanRemboursementAvecInteret[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from planRemboursementAvecInteret where idUtilisateur = '" + idUtil + "' and etatPaiement = 0");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int idDemandePret = int.Parse(reader["idDemandePret"].ToString());
                    int idUtilisateur = int.Parse(reader["idUtilisateur"].ToString());
                    DateTime dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString());
                    int jetonSansInteret = int.Parse(reader["jetonSansInteret"].ToString());
                    int jetonAvecInteret = int.Parse(reader["jetonAvecInteret"].ToString());
                    int etatPaiement = int.Parse(reader["etatPaiement"].ToString());
                    listeMatch.Add(new PlanRemboursementAvecInteret(id, idDemandePret, idUtilisateur, dateRemboursement, jetonSansInteret, jetonAvecInteret, etatPaiement));
                }
                resultat = new PlanRemboursementAvecInteret[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (PlanRemboursementAvecInteret)listeMatch[i];
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

        public void insertPlanAvecInteret(PlanRemboursementAvecInteret plan)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into planRemboursementAvecInteret values('" + plan.getIdDemandePret() + "','" + plan.getIdUtilisateur() + "','" + plan.getDateRemboursement() + "','" + plan.getJetonSansInteret() + "','" + plan.getJetonAvecInteret() + "','" + plan.getEtatPaiement() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updatePlan(String dateRemboursement, int jetonSansInteret, int jetonAvecInteret, int id)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update planRemboursementAvecInteret set dateRemboursement='" + dateRemboursement + "', jetonSansInteret='"+ jetonSansInteret + "', jetonAvecInteret='"+ jetonAvecInteret + "' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                // 	MessageBox.Show("Modification reussit");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updatePlan(String dateRemboursement, int jetonAvecInteret, int id)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update planRemboursementAvecInteret set dateRemboursement='" + dateRemboursement + "', jetonAvecInteret='" + jetonAvecInteret + "' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                // 	MessageBox.Show("Modification reussit");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updateJetonPlan(int jetonAvecInteret, int id)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "update planRemboursementAvecInteret set jetonAvecInteret='" + jetonAvecInteret + "' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                // 	MessageBox.Show("Modification reussit");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int calculJetonInteret(DateTime date1, DateTime date2, int resteJetonApayer, int jetonApayer)
        {
            int jetonInteret = 0;
            try
            {
                double tauxJournalier = 0.000666; // 24/36000
                //MessageBox.Show("tauxJournalier =" + tauxJournalier);
                TimeSpan ts = date2 - date1;
                int differenceDay = Convert.ToInt32(ts.TotalDays);
                double taux = tauxJournalier * differenceDay;
                MessageBox.Show("difference jour =" + differenceDay);
                //MessageBox.Show("taux total =" + taux1);
                jetonInteret = Convert.ToInt32(jetonApayer + (taux * resteJetonApayer / 100));
                MessageBox.Show("jeton surplus =" + taux + "*" + resteJetonApayer +"/"+ 100);
                MessageBox.Show("jeton avec interet =" + jetonInteret);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return jetonInteret;
        }

        public int calculJetonAvecPenalite(DateTime date1, DateTime date2, int jetonApayer, double tauxPenalite, double tauxInteret)
        {
            int jetonAvecPenalite = 0;
            try
            {
                TimeSpan ts = date2 - date1;
                int differenceDay = Convert.ToInt32(ts.TotalDays);
                for (int i = 0; i < differenceDay; i++)
                {
                    jetonAvecPenalite = Convert.ToInt32(jetonApayer + (jetonApayer * tauxInteret / 36000) + (jetonApayer * tauxPenalite / 100));
                    jetonApayer = jetonAvecPenalite;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return jetonAvecPenalite;
        }
    }
}