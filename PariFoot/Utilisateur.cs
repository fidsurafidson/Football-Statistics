using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PariFoot
{
    public class Utilisateur
    {
        int id;
        String nomUtilisateur;
        String motDePasse;
        int jeton;

        public Utilisateur() { }

        public Utilisateur(int ids, String noms, String mdps, int jetons)
        {
            this.setId(ids);
            this.setNomUtilisateur(noms);
            this.setMotDePasse(mdps);
            this.setJeton(jetons);
        }

        public Utilisateur(String noms, String mdps, int jetons)
        {
            this.setNomUtilisateur(noms);
            this.setMotDePasse(mdps);
            this.setJeton(jetons);
        }

        public int getId()
        {
            return id;
        }
        public String getNomUtilisateur()
        {
            return nomUtilisateur;
        }
        public String getMotDePasse()
        {
            return motDePasse;
        }
        public int getJeton()
        {
            return jeton;
        }
        public void setId(int ids)
        {
            this.id = ids;
        }
        public void setNomUtilisateur(String noms)
        {
            this.nomUtilisateur = noms;
        }
        public void setMotDePasse(String mdps)
        {
            this.motDePasse = mdps;
        }
        public void setJeton(int jetons)
        {
            if (jetons < 0)
            {
                throw new Exception("Erreur : Jeton negatif!!");
            }
            else
            {
                this.jeton = jetons;
            }
        }
    }
}