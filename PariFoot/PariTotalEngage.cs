using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PariFoot
{
    public class PariTotalEngage
    {
        int id;
        int idMatch;
        int idUtilisateur1;
        int idUtilisateur2;
        int idEquipe1;
        int idEquipe2;
        String categoriePari;
        int compensation1;
        int compensation2;
        int jeton;
        int matchNul;

        public PariTotalEngage() { }

        public PariTotalEngage(int ids, int idMatchs, int idUtil1, int idUtil2, int idEq1, int idEq2, String categorieParis, int compens1, int compens2, int jetons, int matchNuls)
        {
            this.setId(ids);
            this.setIdMatch(idMatchs);
            this.setIdUtilisateur1(idUtil1);
            this.setIdUtilisateur2(idUtil2);
            this.setIdEquipe1(idEq1);
            this.setIdEquipe2(idEq2);
            this.setCategoriePari(categorieParis);
            this.setCompensation1(compens1);
            this.setCompensation2(compens2);
            this.setJeton(jetons);
            this.setMatchNul(matchNuls);
        }

        public PariTotalEngage(int idMatchs, int idUtil1, int idUtil2, int idEq1, int idEq2, String categorieParis, int compens1, int compens2, int jetons, int matchNuls)
        {
            this.setIdMatch(idMatchs);
            this.setIdUtilisateur1(idUtil1);
            this.setIdUtilisateur2(idUtil2);
            this.setIdEquipe1(idEq1);
            this.setIdEquipe2(idEq2);
            this.setCategoriePari(categorieParis);
            this.setCompensation1(compens1);
            this.setCompensation2(compens2);
            this.setJeton(jetons);
            this.setMatchNul(matchNuls);
        }

        public int getId()
        {
            return id;
        }
        public int getIdMatch()
        {
            return idMatch;
        }
        public int getIdUtilisateur1()
        {
            return idUtilisateur1;
        }
        public int getIdUtilisateur2()
        {
            return idUtilisateur2;
        }
        public int getIdEquipe1()
        {
            return idEquipe1;
        }
        public int getIdEquipe2()
        {
            return idEquipe2;
        }
        public String getCategoriePari()
        {
            return categoriePari;
        }
        public int getCompensation1()
        {
            return compensation1;
        }
        public int getCompensation2()
        {
            return compensation2;
        }
        public int getJeton()
        {
            return jeton;
        }
        public int getMatchNul()
        {
            return matchNul;
        }
        public void setId(int ids)
        {
            this.id = ids;
        }
        public void setIdMatch(int idMatchs)
        {
            this.idMatch = idMatchs;
        }
        public void setIdUtilisateur1(int idUtil1)
        {
            this.idUtilisateur1 = idUtil1;
        }
        public void setIdUtilisateur2(int idUtil2)
        {
            this.idUtilisateur2 = idUtil2;
        }
        public void setIdEquipe1(int idEq1)
        {
            this.idEquipe1 = idEq1;
        }
        public void setIdEquipe2(int idEq2)
        {
            this.idEquipe2 = idEq2;
        }
        public void setCategoriePari(String categorieParis)
        {
            this.categoriePari = categorieParis;
        }
        public void setCompensation1(int compens1)
        {
            if (compens1 < 0)
            {
                throw new Exception("Erreur : Compensation 1 negatif!!");
            }
            else
            {
                this.compensation1 = compens1;
            }
        }
        public void setCompensation2(int compens2)
        {
            if (compens2 < 0)
            {
                throw new Exception("Erreur : Compensation 2 negatif!!");
            }
            else
            {
                this.compensation2 = compens2;
            }
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
        public void setMatchNul(int matchNuls)
        {
            this.matchNul = matchNuls;
        }
    }
}