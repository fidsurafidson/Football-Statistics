using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foot
{
    public class Statistique
    {
        int id;
        int idMatch;
        DateTime dateMatch;
        int idEquipe;
        int possession;
        int tir;
        int tirCadre;
        int but;

        public Statistique() { }

        public Statistique(int ids, int idMatchs, String dateMatchs, int idEquipes, int possessions, int tirs, int tirCadres, int buts)
        {
            this.setId(ids);
            this.setIdMatch(idMatchs);
            this.setDateMatch(dateMatchs);
            this.setIdEquipe(idEquipes);
            this.setPossession(possessions);
            this.setTir(tirs);
            this.setTirCadre(tirCadres);
            this.setBut(buts);
        }

        public Statistique(int idMatchs, String dateMatchs, int idEquipes, int possessions, int tirs, int tirCadres, int buts)
        {
            this.setIdMatch(idMatchs);
            this.setDateMatch(dateMatchs);
            this.setIdEquipe(idEquipes);
            this.setPossession(possessions);
            this.setTir(tirs);
            this.setTirCadre(tirCadres);
            this.setBut(buts);
        }

        public int getId()
        {
            return id;
        }
        public int getIdMatch()
        {
            return idMatch;
        }
        public String getDateMatch()
        {
            String datyy = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dateMatch.Year, dateMatch.Month, dateMatch.Day, dateMatch.Hour, dateMatch.Minute, dateMatch.Second, dateMatch.Millisecond);
            return datyy;
        }
        public int getIdEquipe()
        {
            return idEquipe;
        }
        public int getPossession()
        {
            return possession;
        }
        public int getTir()
        {
            return tir;
        }
        public int getTirCadre()
        {
            return tirCadre;
        }
        public int getBut()
        {
            return but;
        }
        public void setId(int ids)
        {
            this.id = ids;
        }
        public void setIdMatch(int idMatchs)
        {
            this.idMatch = idMatchs;
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
        public void setIdEquipe(int idEquipes)
        {
            this.idEquipe = idEquipes;
        }
        public void setPossession(int possessions)
        {
            this.possession = possessions;
        }
        public void setTir(int tirs)
        {
            this.tir = tirs;
        }
        public void setTirCadre(int tirCadres)
        {
            this.tirCadre = tirCadres;
        }
        public void setBut(int buts)
        {
            this.but = buts;
        }
    }
}
