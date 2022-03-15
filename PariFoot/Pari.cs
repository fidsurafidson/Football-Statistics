using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PariFoot
{
    public class Pari
    {
        int id;
        int idMatch;
        int idUtilisateur;
        String nomUtilisateur;
        int idEquipe;
        String nomEquipe;
        String typePari;
        String categoriePari;
        int compensation;
        int montant;
        int forfait;
        int matchNul;
        int etat;

        public Pari() { }

        public Pari(int ids, int idMatchs, int idUtilisateurs, int idEquipes, String typeParis, String categorieParis, int compensations, int montants, int forfaits, int matchNuls, int etats)
        {
            this.setId(ids);
            this.setIdMatch(idMatchs);
            this.setIdUtilisateur(idUtilisateurs);
            this.setIdEquipe(idEquipes);
            this.setTypePari(typeParis);
            this.setCategoriePari(categorieParis);
            this.setCompensation(compensations);
            this.setMontant(montants);
            this.setForfait(forfaits);
            this.setMatchNul(matchNuls);
            this.setEtat(etats);
        }

        public Pari(int ids, int idMatchs, String nomUtilisateurs, String nomEquipes, String typeParis, String categorieParis, int compensations, int montants, int forfaits, int matchNuls, int etats)
        {
            this.setId(ids);
            this.setIdMatch(idMatchs);
            this.setNomUtilisateur(nomUtilisateurs);
            this.setNomEquipe(nomEquipes);
            this.setTypePari(typeParis);
            this.setCategoriePari(categorieParis);
            this.setCompensation(compensations);
            this.setMontant(montants);
            this.setForfait(forfaits);
            this.setMatchNul(matchNuls);
            this.setEtat(etats);
        }

        public Pari(int idMatchs, int idUtilisateurs, int idEquipes, String typeParis, String categorieParis, int compensations, int montants, int forfaits, int matchNuls, int etats)
        {
            this.setIdMatch(idMatchs);
            this.setIdUtilisateur(idUtilisateurs);
            this.setIdEquipe(idEquipes);
            this.setTypePari(typeParis);
            this.setCategoriePari(categorieParis);
            this.setCompensation(compensations);
            this.setMontant(montants);
            this.setForfait(forfaits);
            this.setMatchNul(matchNuls);
            this.setEtat(etats);
        }

        public int getId()
        {
            return id;
        }
        public int getIdMatch()
        {
            return idMatch;
        }
        public int getIdUtilisateur()
        {
            return idUtilisateur;
        }
        public String getNomUtilisateur()
        {
            return nomUtilisateur;
        }
        public int getIdEquipe()
        {
            return idEquipe;
        }
        public String getNomEquipe()
        {
            return nomEquipe;
        }
        public String getTypePari()
        {
            return typePari;
        }
        public String getCategoriePari()
        {
            return categoriePari;
        }
        public int getCompensation()
        {
            return compensation;
        }
        public int getMontant()
        {
            return montant;
        }
        public int getForfait()
        {
            return forfait;
        }
        public int getMatchNul()
        {
            return matchNul;
        }
        public int getEtat()
        {
            return etat;
        }
        public void setId(int ids)
        {
            this.id = ids;
        }
        public void setIdMatch(int idMatchs)
        {
            this.idMatch = idMatchs;
        }
        public void setIdUtilisateur(int idUtilisateurs)
        {
            this.idUtilisateur = idUtilisateurs;
        }
        public void setNomUtilisateur(String nomUtilisateurs)
        {
            this.nomUtilisateur = nomUtilisateurs;
        }
        public void setIdEquipe(int idEquipes)
        {
            this.idEquipe = idEquipes;
        }
        public void setNomEquipe(String nomEquipes)
        {
            this.nomEquipe = nomEquipes;
        }
        public void setTypePari(String typeParis)
        {
            this.typePari = typeParis;
        }
        public void setCategoriePari(String categorieParis)
        {
            this.categoriePari = categorieParis;
        }
        public void setCompensation(int compensations)
        {
            if (compensations < 0)
            {
                throw new Exception("Compensation negative!!!");
            }
            else
            {
                this.compensation = compensations;
            }
        }
        public void setMontant(int montants)
        {
            if (montants <= 0)
            {
                throw new Exception("Montant negatif!!!");
            }
            else
            {
                this.montant = montants;
            }
        }
        public void setForfait(int forfaits)
        {
            if (forfaits < 0)
            {
                throw new Exception("Forfait negatif!!!");
            }
            else
            {
                this.forfait = forfaits;
            }
        }
        public void setMatchNul(int matchNuls)
        {
            this.matchNul = matchNuls;
        }
        public void setEtat(int etats)
        {
            this.etat = etats;
        }
    }
}