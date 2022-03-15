using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PariFoot
{
    public partial class SimulationRetard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idUtil = int.Parse(Request.QueryString["idUtil"]);
            int idDemande = int.Parse(Request.QueryString["idDemande"]);
            DemandePretDAO demande = new DemandePretDAO();
            DemandePret[] demande1 = demande.findDemandeById(idDemande);
            int jetonDemande = demande1[0].getJeton();
            DateTime calendar = Calendar1.SelectedDate;
            String dateRetard = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", calendar.Year, calendar.Month, calendar.Day, calendar.Hour, calendar.Minute, calendar.Second, calendar.Millisecond);
            //MessageBox.Show(dateRetard);
            PlanRemboursementAvecInteretDAO plan = new PlanRemboursementAvecInteretDAO();
            PlanRemboursementAvecInteret[] plan1 = plan.findPlanInferieurDesc(idDemande, dateRetard);
            int idPlan = plan1[0].getId();
            DateTime dateRemboursement = Convert.ToDateTime(plan1[0].getDateRemboursement());
            int jetonAvecInteret = plan1[0].getJetonAvecInteret();
            int jetonRemboursement = 0;
            for (int i=0; i<plan1.Length; i++)
            {
                jetonRemboursement = jetonRemboursement + plan1[i].getJetonSansInteret();
            }
            //jetonRemboursement = jetonRemboursement - plan1[0].getJetonSansInteret();
            /*int jetonReste = jetonDemande - jetonRemboursement - plan1[0].getJetonSansInteret();
            int jetonInteretTotal = plan.calculJetonInteret(dateRemboursement, Convert.ToDateTime(dateRetard), jetonReste, jetonAvecInteret);*/
            int jetonAvecPenalite = plan.calculJetonAvecPenalite(dateRemboursement, Convert.ToDateTime(dateRetard), jetonAvecInteret, 0.05, 24);

            Label1.Text = dateRetard;
            Label2.Text = jetonAvecPenalite.ToString();

            PlanRemboursementAvecInteret[] plan2 = plan.findDemande(idDemande, dateRetard);
            int idPlan2 = plan2[0].getId();
            DateTime dateRemboursement2 = Convert.ToDateTime(plan2[0].getDateRemboursement());
            int jetonApayer = plan2[0].getJetonSansInteret();
            int jetonReste2 = jetonDemande - jetonRemboursement;
            int jetonAvecInteret2 = plan.calculJetonInteret(Convert.ToDateTime(dateRetard), dateRemboursement2, jetonReste2, jetonApayer);

            Label3.Text = plan2[0].getDateRemboursement();
            Label4.Text = jetonAvecInteret2.ToString();

            Label5.Text = idPlan.ToString();
            Label6.Text = idPlan2.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PlanRemboursementAvecInteretDAO plan = new PlanRemboursementAvecInteretDAO();
            plan.updatePlan(Label1.Text, int.Parse(Label2.Text), int.Parse(Label5.Text));
            plan.updatePlan(Label3.Text, int.Parse(Label4.Text), int.Parse(Label6.Text));
        }
    }
}