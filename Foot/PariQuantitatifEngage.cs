using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foot
{
    class PariQuantitatifEngage
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
        int jeton1;
        int jeton2;
        int forfait1;
        int forfait2;
        int matchNul;

        public PariQuantitatifEngage() { }

        public PariQuantitatifEngage(int ids, int idMatchs, int idUtil1, int idUtil2, int idEq1, int idEq2, String categorieParis, int compens1, int compens2, int jetons1, int jetons2, int forfaits1, int forfaits2, int matchNuls)
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
            this.setJeton1(jetons1);
            this.setJeton2(jetons2);
            this.setForfait1(forfaits1);
            this.setForfait2(forfaits2);
            this.setMatchNul(matchNuls);
        }

        public PariQuantitatifEngage(int idMatchs, int idUtil1, int idUtil2, int idEq1, int idEq2, String categorieParis, int compens1, int compens2, int jetons1, int jetons2, int forfaits1, int forfaits2, int matchNuls)
        {
            this.setIdMatch(idMatchs);
            this.setIdUtilisateur1(idUtil1);
            this.setIdUtilisateur2(idUtil2);
            this.setIdEquipe1(idEq1);
            this.setIdEquipe2(idEq2);
            this.setCategoriePari(categorieParis);
            this.setCompensation1(compens1);
            this.setCompensation2(compens2);
            this.setJeton1(jetons1);
            this.setJeton2(jetons2);
            this.setForfait1(forfaits1);
            this.setForfait2(forfaits2);
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
        public int getJeton1()
        {
            return jeton1;
        }
        public int getJeton2()
        {
            return jeton2;
        }
        public int getForfait1()
        {
            return forfait1;
        }
        public int getForfait2()
        {
            return forfait2;
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
            this.compensation1 = compens1;
        }
        public void setCompensation2(int compens2)
        {
            this.compensation2 = compens2;
        }
        public void setJeton1(int jetons1)
        {
            //this.jeton1 = jetons1;
            if (jetons1 < 0)
            {
                throw new Exception("Erreur : Jeton negatif!!");
            }
            else
            {
                this.jeton1 = jetons1;
            }
        }
        public void setJeton2(int jetons2)
        {
            //this.jeton2 = jetons2;
            if (jetons2 < 0)
            {
                throw new Exception("Erreur : Jeton negatif!!");
            }
            else
            {
                this.jeton2 = jetons2;
            }
        }
        public void setForfait1(int forfaits1)
        {
            //this.forfait1 = forfaits1;
            if (forfaits1 < 0)
            {
                throw new Exception("Erreur : Forfait negatif!!");
            }
            else
            {
                this.forfait1 = forfaits1;
            }
        }
        public void setForfait2(int forfaits2)
        {
            //this.forfait2 = forfaits2;
            if (forfaits2 < 0)
            {
                throw new Exception("Erreur : Forfait negatif!!");
            }
            else
            {
                this.forfait2 = forfaits2;
            }
        }
        public void setMatchNul(int matchNuls)
        {
            this.matchNul = matchNuls;
        }
    }
}
