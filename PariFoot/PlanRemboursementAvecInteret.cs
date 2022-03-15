using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PariFoot
{
    public class PlanRemboursementAvecInteret
    {
        int id;
        int idDemandePret;
        int idUtilisateur;
        DateTime dateRemboursement;
        int jetonSansInteret;
        int jetonAvecInteret;
        int etatPaiement;

        public PlanRemboursementAvecInteret() { }

        public PlanRemboursementAvecInteret(int ids, int idDemandePrets, int idUtils, DateTime dateRemboursements, int jetonSansInterets, int jetonAvecInterets, int etatPaiements)
        {
            this.setId(ids);
            this.setIdDemandePret(idDemandePrets);
            this.setIdUtilisateur(idUtils);
            this.setDateRemboursement(dateRemboursements);
            this.setJetonSansInteret(jetonSansInterets);
            this.setJetonAvecInteret(jetonAvecInterets);
            this.setEtatPaiement(etatPaiements);
        }

        public PlanRemboursementAvecInteret(int idDemandePrets, int idUtils, DateTime dateRemboursements, int jetonSansInterets, int jetonAvecInterets, int etatPaiements)
        {
            this.setIdDemandePret(idDemandePrets);
            this.setIdUtilisateur(idUtils);
            this.setDateRemboursement(dateRemboursements);
            this.setJetonSansInteret(jetonSansInterets);
            this.setJetonAvecInteret(jetonAvecInterets);
            this.setEtatPaiement(etatPaiements);
        }

        public int getId()
        {
            return id;
        }
        public int getIdDemandePret()
        {
            return idDemandePret;
        }
        public int getIdUtilisateur()
        {
            return idUtilisateur;
        }
        public String getDateRemboursement()
        {
            String datyy = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dateRemboursement.Year, dateRemboursement.Month, dateRemboursement.Day, dateRemboursement.Hour, dateRemboursement.Minute, dateRemboursement.Second, dateRemboursement.Millisecond);
            return datyy;
        }
        public int getJetonSansInteret()
        {
            return jetonSansInteret;
        }
        public int getJetonAvecInteret()
        {
            return jetonAvecInteret;
        }
        public int getEtatPaiement()
        {
            return etatPaiement;
        }
        public void setId(int ids)
        {
            this.id = ids;
        }
        public void setIdDemandePret(int idDemandePrets)
        {
            this.idDemandePret = idDemandePrets;
        }
        public void setIdDemandePret(String idDemandePrets)
        {
            int idDemandeP = int.Parse(idDemandePrets);
            setIdDemandePret(idDemandeP);
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
        public void setDateRemboursement(DateTime dateRemboursements)
        {
            this.dateRemboursement = dateRemboursements;
        }
        public void setDateRemboursement(String dateRemboursements)
        {
            DateTime dateR = Convert.ToDateTime(dateRemboursements);
            setDateRemboursement(dateR);
        }
        public void setJetonSansInteret(int jetonSansInterets)
        {
            if (jetonSansInterets >= 0) {
                this.jetonSansInteret = jetonSansInterets;
            }
            else
            {
                throw new Exception("Erreur : Jeton sans interet negatif!!");
            }
        }
        public void setJetonAvecInteret(int jetonAvecInterets)
        {
            if (jetonAvecInterets >= 0)
            {
                this.jetonAvecInteret = jetonAvecInterets;
            }
            else
            {
                throw new Exception("Erreur : Jeton avec interet negatif!!");
            }
        }
        public void setEtatPaiement(int etatPaiements)
        {
            this.etatPaiement = etatPaiements;
        }
    }
}