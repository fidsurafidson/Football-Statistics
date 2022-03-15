using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foot
{
    class Match
    {
        int id;
        int idMatch;
        int equipe1;
        int equipe2;
        DateTime dateMatch;

        public Match() { }

        public Match(int ids, int idMatchs, int equipee1, int equipee2, DateTime dateMatchs)
        {
            this.setId(ids);
            this.setIdMatch(idMatchs);
            this.setEquipe1(equipee1);
            this.setEquipe2(equipee2);
            this.setDateMatch(dateMatchs);
        }

        public Match(int idMatchs, int equipee1, int equipee2, String dateMatchs)
        {
            this.setIdMatch(idMatchs);
            this.setEquipe1(equipee1);
            this.setEquipe2(equipee2);
            this.setDateMatch(dateMatchs);
        }

        public int getId()
        {
            return id;
        }
        public int getIdMatch()
        {
            return idMatch;
        }
        public int getEquipe1()
        {
            return equipe1;
        }
        public int getEquipe2()
        {
            return equipe2;
        }
        public String getDateMatch()
        {
            String datyy = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dateMatch.Year, dateMatch.Month, dateMatch.Day, dateMatch.Hour, dateMatch.Minute, dateMatch.Second, dateMatch.Millisecond);
            return datyy;
        }
        public void setId(int ids)
        {
            this.id = ids;
        }
        public void setId(String ids)
        {
            int idd = int.Parse(ids);
            setId(idd);
        }
        public void setIdMatch(int idMatchs)
        {
            this.idMatch = idMatchs;
        }
        public void setIdMatch(String idMatchs)
        {
            int idd = int.Parse(idMatchs);
            setIdMatch(idd);
        }
        public void setEquipe1(int equ1)
        {
            this.equipe1 = equ1;
        }
        public void setEquipe1(String equ1)
        {
            int equipee = int.Parse(equ1);
            setEquipe1(equipee);
        }
        public void setEquipe2(int equ2)
        {
            this.equipe2 = equ2;
        }
        public void setEquipe2(String equ2)
        {
            int equipee = int.Parse(equ2);
            setEquipe2(equipee);
        }
        public void setDateMatch(DateTime daty)
        {
            this.dateMatch = daty;
        }
        public void setDateMatch(String daty)
        {
            DateTime datee = Convert.ToDateTime(daty);
            setDateMatch(datee);
        }
    }
}
