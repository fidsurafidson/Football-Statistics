using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PariFoot;

namespace PariConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*while (1 < 2)
            {
                // deblocage demande
                DateTime dateNow = DateTime.Today;
                DateTime dateToday = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day);
                UtilisateurDAO utilisateur = new UtilisateurDAO();
                DemandePretDAO demande = new DemandePretDAO();
                DemandePret[] demande1 = demande.findDemandeValide();
                for (int i=0; i<demande1.Length; i++)
                {
                    DateTime dateDeblocage = Convert.ToDateTime(demande1[i].getDateDeblocage());
                    if (dateDeblocage == dateToday)
                    {
                        int idUtil = demande1[i].getIdUtilisateur();
                        int jetonDemande = demande1[i].getJeton();
                        Utilisateur[] utilisateur1 = utilisateur.findUtilisateur(idUtil);
                        int jetonUtil = utilisateur1[0].getJeton();
                        int nouveauJeton = jetonUtil + jetonDemande;
                        utilisateur.updateJetonUtil(nouveauJeton, idUtil);
                    }
                }

                // paiement tranche
                PlanRemboursementAvecInteretDAO plan = new PlanRemboursementAvecInteretDAO();
                PlanRemboursementAvecInteret[] plan1 = plan.findDemande();
                for (int i=0; i<plan1.Length; i++)
                {
                    DateTime dateRemboursement = Convert.ToDateTime(plan1[i].getDateRemboursement());
                    int idUtil = plan1[i].getIdUtilisateur();
                    if (dateRemboursement == dateToday)
                    {
                        int jetonApayer = plan1[i].getJetonAvecInteret();
                        Utilisateur[] utilisateur1 = utilisateur.findUtilisateur(idUtil);
                        int jetonUtil = utilisateur1[0].getJeton();
                        if (jetonUtil >= jetonApayer)
                        {
                            int nouveauJeton = jetonUtil - jetonApayer;
                            utilisateur.updateJetonUtil(nouveauJeton, idUtil);
                        }
                        else if (jetonUtil < jetonApayer && jetonUtil != 0)
                        {
                            utilisateur.updateJetonUtil(0, idUtil);
                            int nouveauJetonApayer = jetonApayer - jetonUtil;
                            int idPlan = plan1[i].getId();
                            plan.updateJetonPlan(nouveauJetonApayer, idPlan);
                        }
                    }
                }
            }*/
        }
    }
}
