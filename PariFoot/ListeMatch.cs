using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PariFoot
{
    public class ListeMatch
    {
        int id;
        String nomEquipe1;
        String nomEquipe2;
        DateTime dateMatch;
        int etat;

        public ListeMatch() { }

        public ListeMatch(int ids, String nomEquipee1, String nomEquipee2, DateTime dateMatchs, int etats)
        {
            this.setId(ids);
            this.setNomEquipe1(nomEquipee1);
            this.setNomEquipe2(nomEquipee2);
            this.setDateMatch(dateMatchs);
            this.setEtat(etats);
        }

        public ListeMatch(String nomEquipee1, String nomEquipee2, DateTime dateMatchs, int etats)
        {
            this.setNomEquipe1(nomEquipee1);
            this.setNomEquipe2(nomEquipee2);
            this.setDateMatch(dateMatchs);
            this.setEtat(etats);
        }

        public int getId()
        {
            return id;
        }
        public String getNomEquipe1()
        {
            return nomEquipe1;
        }
        public String getNomEquipe2()
        {
            return nomEquipe2;
        }
        public String getDateMatch()
        {
            String datyy = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dateMatch.Year, dateMatch.Month, dateMatch.Day, dateMatch.Hour, dateMatch.Minute, dateMatch.Second, dateMatch.Millisecond);
            return datyy;
        }
        public int getEtat()
        {
            return etat;
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
        public void setNomEquipe1(String nomEqu1)
        {
            this.nomEquipe1 = nomEqu1;
        }
        public void setNomEquipe2(String nomEqu2)
        {
            this.nomEquipe2 = nomEqu2;
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
        public void setEtat(int etats)
        {
            this.etat = etats;
        }
        public void setEtat(String etats)
        {
            int etatt = int.Parse(etats);
            setEtat(etatt);
        }
    }
}