using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Foot;

namespace PariFoot
{
    public class ListeMatchDAO
    {
        public ListeMatch[] findListeMatch()
        {
            ListeMatch[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from listeMatch where etat != 1");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nomEquipe1 = reader["nomEquipe1"].ToString();
                    String nomEquipe2 = reader["nomEquipe2"].ToString();
                    DateTime dateMatch = Convert.ToDateTime(reader["dateDebut"].ToString());
                    int etat = int.Parse(reader["etat"].ToString());
                    listeMatch.Add(new ListeMatch(id, nomEquipe1, nomEquipe2, dateMatch, etat));
                }
                resultat = new ListeMatch[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (ListeMatch)listeMatch[i];
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

        public ListeMatch[] findListeMatchById(int idMatch)
        {
            ListeMatch[] resultat = null;
            ArrayList listeMatch = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from listeMatch where etat != 1 and id="+ idMatch);
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            //MessageBox.Show("Affichage reussit");
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nomEquipe1 = reader["nomEquipe1"].ToString();
                    String nomEquipe2 = reader["nomEquipe2"].ToString();
                    DateTime dateMatch = Convert.ToDateTime(reader["dateDebut"].ToString());
                    int etat = int.Parse(reader["etat"].ToString());
                    listeMatch.Add(new ListeMatch(id, nomEquipe1, nomEquipe2, dateMatch, etat));
                }
                resultat = new ListeMatch[listeMatch.Count];
                for (int i = 0; i < listeMatch.Count; i++)
                {
                    resultat[i] = (ListeMatch)listeMatch[i];
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

        public void resultatPari(int idMatch)
        {
            StatistiqueDAO statistique = new StatistiqueDAO();
            Statistique[] statistique1 = statistique.findStatistiqueMatch(idMatch);
            int idUtilGagnant = 0;
            int idUtilPerdant = 0;

            UtilisateurDAO utilisateur = new UtilisateurDAO();
            PariTotalEngageDAO pariTotal = new PariTotalEngageDAO();
            PariTotalEngage[] pariTotal1 = pariTotal.findPari(idMatch);
            for (int i=0; i<pariTotal1.Length; i++)
            {
                int totalPossession1 = 0;
                int totalPossession2 = 0;
                if (pariTotal1[i].getCategoriePari() == "possession")
                {
                    if (pariTotal1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getPossession() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getPossession() + pariTotal1[i].getCompensation1();
                        /*if (totalPossession1 > totalPossession2)
                        {
                            //idEquipeGagnant = statistique1[0].getIdEquipe();
                            idEquipeGagnant = pariTotal1[i].getIdEquipe1();
                            idUtilGagnant = pariTotal1[i].getIdUtilisateur1();
                            idUtilPerdant = pariTotal1[i].getIdUtilisateur2();

                        }
                        else if (totalPossession1 < totalPossession2)
                        {
                            //idEquipeGagnant = statistique1[1].getIdEquipe();
                            idEquipeGagnant = pariTotal1[i].getIdEquipe2();
                            idUtilGagnant = pariTotal1[i].getIdUtilisateur2();
                            idUtilPerdant = pariTotal1[i].getIdUtilisateur1();
                        }*/
                    }
                    else if (pariTotal1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getPossession() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getPossession() + pariTotal1[i].getCompensation1();
                    }
                }
                if (pariTotal1[i].getCategoriePari() == "tir")
                {
                    if (pariTotal1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getTir() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getTir() + pariTotal1[i].getCompensation1();
                    }
                    else if (pariTotal1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getTir() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getTir() + pariTotal1[i].getCompensation1();
                    }
                }
                if (pariTotal1[i].getCategoriePari() == "tir cadre")
                {
                    if (pariTotal1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getTirCadre() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getTirCadre() + pariTotal1[i].getCompensation1();
                    }
                    else if (pariTotal1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getTirCadre() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getTirCadre() + pariTotal1[i].getCompensation1();
                    }
                }
                if (pariTotal1[i].getCategoriePari() == "but")
                {
                    if (pariTotal1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getBut() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getBut() + pariTotal1[i].getCompensation1();
                    }
                    else if (pariTotal1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getBut() + pariTotal1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getBut() + pariTotal1[i].getCompensation1();
                    }
                }


                // mijery oe iza utilisateur gagnant
                if (totalPossession1 > totalPossession2)
                {
                    idUtilGagnant = pariTotal1[i].getIdUtilisateur1();
                    idUtilPerdant = pariTotal1[i].getIdUtilisateur2();
                }
                else if (totalPossession1 < totalPossession2)
                {
                    idUtilGagnant = pariTotal1[i].getIdUtilisateur2();
                    idUtilPerdant = pariTotal1[i].getIdUtilisateur1();
                }
                else
                {
                    idUtilGagnant = pariTotal1[i].getMatchNul();
                    if (idUtilGagnant == pariTotal1[i].getIdEquipe1())
                    {
                        idUtilPerdant = pariTotal1[i].getIdEquipe2();
                    }
                    else if (idUtilGagnant == pariTotal1[i].getIdEquipe2())
                    {
                        idUtilPerdant = pariTotal1[i].getIdEquipe1();
                    }
                }

                // update jeton utilisateur gagnant et perdant
                if (idUtilGagnant != 0)
                {
                    Utilisateur[] utilisateur1 = utilisateur.findUtilisateur(idUtilGagnant);
                    int nouveauJeton1 = utilisateur1[0].getJeton() + pariTotal1[i].getJeton();
                    utilisateur.updateJetonUtil(nouveauJeton1, idUtilGagnant);
                    Utilisateur[] utilisateur2 = utilisateur.findUtilisateur(idUtilPerdant);
                    int nouveauJeton2 = utilisateur1[0].getJeton() - pariTotal1[i].getJeton();
                    utilisateur.updateJetonUtil(nouveauJeton2, idUtilPerdant);
                }
            }


            // pari quantitatif engage
            PariQuantitatifEngageDAO pariQuantitatif = new PariQuantitatifEngageDAO();
            PariQuantitatifEngage[] pariQuantitatif1 = pariQuantitatif.findPari(idMatch);
            int jetonGagne = 0;
            for (int i = 0; i < pariQuantitatif1.Length; i++)
            {
                int totalPossession1 = 0;
                int totalPossession2 = 0;
                if (pariQuantitatif1[i].getCategoriePari() == "possession")
                {
                    if (pariQuantitatif1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getPossession() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getPossession() + pariQuantitatif1[i].getCompensation1();
                    }
                    else if (pariQuantitatif1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getPossession() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getPossession() + pariQuantitatif1[i].getCompensation1();
                    }
                }
                if (pariQuantitatif1[i].getCategoriePari() == "tir")
                {
                    if (pariQuantitatif1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getTir() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getTir() + pariQuantitatif1[i].getCompensation1();
                    }
                    else if (pariQuantitatif1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getTir() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getTir() + pariQuantitatif1[i].getCompensation1();
                    }
                }
                if (pariQuantitatif1[i].getCategoriePari() == "tir cadre")
                {
                    if (pariQuantitatif1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getTirCadre() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getTirCadre() + pariQuantitatif1[i].getCompensation1();
                    }
                    else if (pariQuantitatif1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getTirCadre() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getTirCadre() + pariQuantitatif1[i].getCompensation1();
                    }
                }
                if (pariQuantitatif1[i].getCategoriePari() == "but")
                {
                    if (pariQuantitatif1[i].getIdEquipe1() == statistique1[0].getIdEquipe())
                    {
                        totalPossession1 = statistique1[0].getBut() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[1].getBut() + pariQuantitatif1[i].getCompensation1();
                    }
                    else if (pariQuantitatif1[i].getIdEquipe1() == statistique1[1].getIdEquipe())
                    {
                        totalPossession1 = statistique1[1].getBut() + pariQuantitatif1[i].getCompensation2();
                        totalPossession2 = statistique1[0].getBut() + pariQuantitatif1[i].getCompensation1();
                    }
                }

                // mijery oe iza utilisateur gagnant
                if (totalPossession1 > totalPossession2)
                {
                    idUtilGagnant = pariQuantitatif1[i].getIdUtilisateur1();
                    idUtilPerdant = pariQuantitatif1[i].getIdUtilisateur2();
                    int difference = totalPossession1 - totalPossession2;
                    jetonGagne = pariQuantitatif1[i].getJeton2() * difference;
                    if (jetonGagne > pariQuantitatif1[i].getForfait2())
                    {
                        jetonGagne = pariQuantitatif1[i].getForfait2();
                    }
                }
                else if (totalPossession1 < totalPossession2)
                {
                    idUtilGagnant = pariQuantitatif1[i].getIdUtilisateur2();
                    idUtilPerdant = pariQuantitatif1[i].getIdUtilisateur1();
                    int difference = totalPossession2 - totalPossession1;
                    jetonGagne = pariQuantitatif1[i].getJeton1() * difference;
                    if (jetonGagne > pariQuantitatif1[i].getForfait1())
                    {
                        jetonGagne = pariQuantitatif1[i].getForfait1();
                    }
                }
                else
                {
                    idUtilGagnant = pariQuantitatif1[i].getMatchNul();
                    if (idUtilGagnant == pariTotal1[i].getIdEquipe1())
                    {
                        idUtilPerdant = pariTotal1[i].getIdEquipe2();
                        jetonGagne = pariQuantitatif1[i].getJeton2();
                    }
                    else if (idUtilGagnant == pariTotal1[i].getIdEquipe2())
                    {
                        idUtilPerdant = pariTotal1[i].getIdEquipe1();
                        jetonGagne = pariQuantitatif1[i].getJeton1();
                    }
                }

                // update jeton utilisateur gagnant et perdant
                if (idUtilGagnant != 0) {
                    Utilisateur[] utilisateur1 = utilisateur.findUtilisateur(idUtilGagnant);
                    int nouveauJeton1 = utilisateur1[0].getJeton() + jetonGagne;
                    utilisateur.updateJetonUtil(nouveauJeton1, idUtilGagnant);
                    Utilisateur[] utilisateur2 = utilisateur.findUtilisateur(idUtilPerdant);
                    int nouveauJeton2 = utilisateur1[0].getJeton() - jetonGagne;
                    utilisateur.updateJetonUtil(nouveauJeton2, idUtilPerdant);
                }
            }
        }
    }
}