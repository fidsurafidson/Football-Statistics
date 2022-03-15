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
    public class JoueurDAO
    {
        public Joueur[] findJoueur()
        {
            Joueur[] resultat = null;
            ArrayList listeJoueur = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from Joueur");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    int numero = int.Parse(reader["numero"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    listeJoueur.Add(new Joueur(id, nom, numero, idEquipe));
                }
                resultat = new Joueur[listeJoueur.Count];
                for (int i = 0; i < listeJoueur.Count; i++)
                {
                    resultat[i] = (Joueur)listeJoueur[i];
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

        public Joueur[] findJoueurEquipe(int idMatch)
        {
            Joueur[] resultat = null;
            ArrayList listeJoueur = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select f.id,j.nom,e.nom as equipe from feuilleMatchJoueur f join Joueur j on f.idJoueur=j.id join equipe e on e.id=f.idEquipe where f.idMatch='"+idMatch+"'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    String equipe = reader["equipe"].ToString();
                    listeJoueur.Add(new Joueur(id, nom, equipe));
                }
                resultat = new Joueur[listeJoueur.Count];
                for (int i = 0; i < listeJoueur.Count; i++)
                {
                    resultat[i] = (Joueur)listeJoueur[i];
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

        public Joueur[] findJoueur(int idEquipes)
        {
            Joueur[] resultat = null;
            ArrayList listeJoueur = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from Joueur where idEquipe='"+idEquipes+"'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    int numero = int.Parse(reader["numero"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    listeJoueur.Add(new Joueur(id, nom, numero, idEquipe));
                }
                resultat = new Joueur[listeJoueur.Count];
                for (int i = 0; i < listeJoueur.Count; i++)
                {
                    resultat[i] = (Joueur)listeJoueur[i];
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

        public Joueur[] findJoueur(String equipe)
        {
            Joueur[] resultat = null;
            ArrayList listeJoueur = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select j.id,j.nom,j.numero,j.idEquipe,e.nom as nomEquipe from Joueur j join Equipe e on e.id=j.idEquipe where e.nom='"+equipe+"'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    int numero = int.Parse(reader["numero"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    String nomEquipe = reader["nomEquipe"].ToString();
                    listeJoueur.Add(new Joueur(id, nom, numero, idEquipe, nomEquipe));
                }
                resultat = new Joueur[listeJoueur.Count];
                for (int i = 0; i < listeJoueur.Count; i++)
                {
                    resultat[i] = (Joueur)listeJoueur[i];
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

        public Joueur[] findJoueur(String equipe, String joueur)
        {
            Joueur[] resultat = null;
            ArrayList listeJoueur = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select j.id,j.nom,j.numero,j.idEquipe,e.nom as nomEquipe from Joueur j join Equipe e on e.id=j.idEquipe where e.nom='" + equipe + "' and j.nom='"+joueur+"'");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    int numero = int.Parse(reader["numero"].ToString());
                    int idEquipe = int.Parse(reader["idEquipe"].ToString());
                    String nomEquipe = reader["nomEquipe"].ToString();
                    listeJoueur.Add(new Joueur(id, nom, numero, idEquipe, nomEquipe));
                }
                resultat = new Joueur[listeJoueur.Count];
                for (int i = 0; i < listeJoueur.Count; i++)
                {
                    resultat[i] = (Joueur)listeJoueur[i];
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

        public void ballonTouche(Possession possession, String joueur, String equipe) 
        {
            int idJoueur = 0;
            JoueurDAO joueur1 = new JoueurDAO();
            Joueur[] joueur2 = joueur1.findJoueur(equipe, joueur);
            for (int i=0; i< joueur2.Length; i++)
            {
                idJoueur = joueur2[i].getId();
            }
            //MessageBox.Show(""+idJoueur);
            for (int i=0; i<possession.getFeuilleMatchJoueur().Length; i++)
            {
                if (possession.getFeuilleMatchJoueur()[i].getIdJoueur() == idJoueur)
                {
                    //MessageBox.Show("indice FM :"+i);
                    int ballonTouche = possession.getFeuilleMatchJoueur()[i].getBallonTouche();
                    ballonTouche = ballonTouche + 1;
                    possession.getFeuilleMatchJoueur()[i].setBallonTouche(ballonTouche);
                    //MessageBox.Show("ballon touché :" + possession.getFeuilleMatchJoueur()[i].getBallonTouche());
                }
            }
        }

        public void minuteJoue(Possession possession, String titulaire, String remplacant, String equipe, int minute, int fin)
        {
            int idJoueurTitulaire = 0;
            int idJoueurRemplacant = 0;
            JoueurDAO joueur1 = new JoueurDAO();
            Joueur[] joueur2 = joueur1.findJoueur(equipe, titulaire);
            for (int i = 0; i < joueur2.Length; i++)
            {
                idJoueurTitulaire = joueur2[i].getId();
            }
            for (int i = 0; i < possession.getFeuilleMatchJoueur().Length; i++)
            {
                if (possession.getFeuilleMatchJoueur()[i].getIdJoueur() == idJoueurTitulaire)
                {
                    possession.getFeuilleMatchJoueur()[i].setMinuteJoue(minute);
                    //MessageBox.Show("minute joué titulaire :" + possession.getFeuilleMatchJoueur()[i].getMinuteJoue());
                }
            }

            Joueur[] joueur3 = joueur1.findJoueur(equipe, remplacant);
            for (int i = 0; i < joueur3.Length; i++)
            {
                idJoueurRemplacant = joueur3[i].getId();
            }
            for (int i = 0; i < possession.getFeuilleMatchJoueur().Length; i++)
            {
                if (possession.getFeuilleMatchJoueur()[i].getIdJoueur() == idJoueurRemplacant)
                {
                    int minuteJoue = fin - minute;
                    possession.getFeuilleMatchJoueur()[i].setMinuteJoue(minuteJoue);
                    //MessageBox.Show("minute joué remplacant :" + possession.getFeuilleMatchJoueur()[i].getMinuteJoue());
                }
            }
        }

        public void minuteJoueFin(Possession possession, int minuteFin)
        {
            for (int j = 0; j < possession.getTitulaireJoueurA().Length; j++)
            {
                int idJoueur = possession.getTitulaireJoueurA()[j].getId();
                for (int i = 0; i < possession.getFeuilleMatchJoueur().Length; i++)
                {
                    if (possession.getFeuilleMatchJoueur()[i].getIdJoueur() == idJoueur && possession.getFeuilleMatchJoueur()[i].getMinuteJoue() == 0)
                    {
                        possession.getFeuilleMatchJoueur()[i].setMinuteJoue(minuteFin);
                        //MessageBox.Show(""+possession.getFeuilleMatchJoueur()[i].getMinuteJoue());
                    }
                }
            }
        }

        public void but(Possession possession, String equipe, String joueur)
        {
            Joueur[] joueur1 = this.findJoueur(possession.getEquipePossess(), possession.getJoueurPossess());
            int idJoueur = 0;
            for (int i = 0; i < joueur1.Length; i++)
            {
                idJoueur = joueur1[i].getId();
            }
            for (int i = 0; i < possession.getFeuilleMatchJoueur().Length; i++)
            {
                if (possession.getFeuilleMatchJoueur()[i].getIdJoueur() == idJoueur)
                {
                    int nbBut = possession.getFeuilleMatchJoueur()[i].getBut();
                    nbBut = nbBut + 1;
                    possession.getFeuilleMatchJoueur()[i].setBut(nbBut);
                    int nbTirCadre = possession.getFeuilleMatchJoueur()[i].getTirCadre();
                    nbTirCadre = nbTirCadre + 1;
                    possession.getFeuilleMatchJoueur()[i].setTirCadre(nbTirCadre);
                    int nbTir = possession.getFeuilleMatchJoueur()[i].getTir();
                    nbTir = nbTir + 1;
                    possession.getFeuilleMatchJoueur()[i].setTir(nbTir);
                    //MessageBox.Show("but ="+ possession.getFeuilleMatchJoueur()[i].getBut());
                }
            }
        }

        public void tirCadre(Possession possession, String equipe, String joueur)
        {
            Joueur[] joueur1 = this.findJoueur(possession.getEquipePossess(), possession.getJoueurPossess());
            int idJoueur = 0;
            for (int i = 0; i < joueur1.Length; i++)
            {
                idJoueur = joueur1[i].getId();
            }
            for (int i = 0; i < possession.getFeuilleMatchJoueur().Length; i++)
            {
                if (possession.getFeuilleMatchJoueur()[i].getIdJoueur() == idJoueur)
                {
                    int nbTirCadre = possession.getFeuilleMatchJoueur()[i].getTirCadre();
                    nbTirCadre = nbTirCadre + 1;
                    possession.getFeuilleMatchJoueur()[i].setTirCadre(nbTirCadre);
                    int nbTir = possession.getFeuilleMatchJoueur()[i].getTir();
                    nbTir = nbTir + 1;
                    possession.getFeuilleMatchJoueur()[i].setTir(nbTir);
                    //MessageBox.Show("tir cadre =" + possession.getFeuilleMatchJoueur()[i].getTirCadre());
                }
            }
        }

        public void horsCadre(Possession possession, String equipe, String joueur)
        {
            Joueur[] joueur1 = this.findJoueur(possession.getEquipePossess(), possession.getJoueurPossess());
            int idJoueur = 0;
            for (int i = 0; i < joueur1.Length; i++)
            {
                idJoueur = joueur1[i].getId();
            }
            for (int i = 0; i < possession.getFeuilleMatchJoueur().Length; i++)
            {
                if (possession.getFeuilleMatchJoueur()[i].getIdJoueur() == idJoueur)
                {
                    int nbTir = possession.getFeuilleMatchJoueur()[i].getTir();
                    nbTir = nbTir + 1;
                    possession.getFeuilleMatchJoueur()[i].setTir(nbTir);
                    //MessageBox.Show("tir =" + possession.getFeuilleMatchJoueur()[i].getTir());
                }
            }
        }
    }
}
