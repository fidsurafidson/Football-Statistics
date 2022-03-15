using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace PariFoot
{
    public class DemandePret
    {
        int id;
        int idUtilisateur;
        DateTime dateDeblocage;
        int jeton;
        int etatValidation;

        public DemandePret() { }

        public DemandePret(int ids, int idUtils, DateTime dateDeblocages, int jetons, int etatValidations)
        {
            this.setId(ids);
            this.setIdUtilisateur(idUtils);
            this.setDateDeblocage(dateDeblocages);
            this.setJeton(jetons);
            this.setEtatValidation(etatValidations);
        }

        public DemandePret(int idUtils, DateTime dateDeblocages, int jetons, int etatValidations)
        {
            this.setIdUtilisateur(idUtils);
            this.setDateDeblocage(dateDeblocages);
            this.setJeton(jetons);
            this.setEtatValidation(etatValidations);
        }

        public DemandePret(String idUtils, String dateDeblocages, String jetons, String etatValidations)
        {
            this.setIdUtilisateur(idUtils);
            this.setDateDeblocage(dateDeblocages);
            this.setJeton(jetons);
            this.setEtatValidation(etatValidations);
        }

        public int getId()
        {
            return id;
        }
        public int getIdUtilisateur()
        {
            return idUtilisateur;
        }
        public String getDateDeblocage()
        {
            String datyy = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dateDeblocage.Year, dateDeblocage.Month, dateDeblocage.Day, dateDeblocage.Hour, dateDeblocage.Minute, dateDeblocage.Second, dateDeblocage.Millisecond);
            return datyy;
        }
        public int getJeton()
        {
            return jeton;
        }
        public int getEtatValidation()
        {
            return etatValidation;
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
        public void setIdUtilisateur(int idUtils)
        {
            this.idUtilisateur = idUtils;
        }
        public void setIdUtilisateur(String idUtils)
        {
            int idUtil = int.Parse(idUtils);
            setIdUtilisateur(idUtil);
        }
        public void setDateDeblocage(DateTime dateDeblocages)
        {
            this.dateDeblocage = dateDeblocages;
        }
        public void setDateDeblocage(String dateDeblocages)
        {
            DateTime dateB = Convert.ToDateTime(dateDeblocages);
            DateTime daty = new DateTime(dateB.Year, dateB.Month, dateB.Day, 12, 00, 00);
            setDateDeblocage(daty);
        }
        public void setJeton(int jetons)
        {
            if (jetons >= 0)
            {
                this.jeton = jetons;
            }
            else
            {
                throw new Exception("Erreur : Jeton negatif!!");
                //MessageBox.Show("Erreur : Jeton negatif!!");
            }
        }
        public void setJeton(String jetons)
        {
            int jetonss = int.Parse(jetons);
            setJeton(jetonss);
        }
        public void setEtatValidation(int etatValidations)
        {
            this.etatValidation = etatValidations;
        }
        public void setEtatValidation(String etatValidations)
        {
            int etatV = int.Parse(etatValidations);
            setEtatValidation(etatV);
        }
    }
}