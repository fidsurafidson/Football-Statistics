using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PariFoot
{
    public partial class PlanDeRemboursement : System.Web.UI.Page
    {
        int nbrPayem = 0;
        int jetonInteret1 = 0;
        int jetonInteret2 = 0;
        int jetonInteret3 = 0;
        int jetonInteret4 = 0;
        DateTime dateDeblocage;
        int jetonDemande = 0;
        int idDemandePret = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            nbrPayem = int.Parse(Request.QueryString["nbrPayem"]);
            PlanRemboursementAvecInteretDAO planInteret = new PlanRemboursementAvecInteretDAO();
            DemandePretDAO demande = new DemandePretDAO();
            DemandePret[] demande1 = demande.findDemande();
            dateDeblocage = Convert.ToDateTime(demande1[0].getDateDeblocage());
            jetonDemande = demande1[0].getJeton();
            idDemandePret = demande1[0].getId();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int totalJetonApayer = 0;
            PlanRemboursementAvecInteretDAO planInteret = new PlanRemboursementAvecInteretDAO();
            /*DemandePretDAO demande = new DemandePretDAO();
            DemandePret[] demande1 = demande.findDemande();
            DateTime dateDeblocage = Convert.ToDateTime(demande1[0].getDateDeblocage());
            int jetonDemande = demande1[0].getJeton();
            int idDemandePret = demande1[0].getId();*/
            jetonInteret1 = planInteret.calculJetonInteret(dateDeblocage, Calendar1.SelectedDate, jetonDemande, int.Parse(TextBox1.Text));
            totalJetonApayer = totalJetonApayer + int.Parse(TextBox1.Text);
            Label1.Text = jetonInteret1.ToString();

            int resteJeton2 = 0;
            if (nbrPayem >= 2)
            {
                resteJeton2 = jetonDemande - int.Parse(TextBox1.Text);
                jetonInteret2 = planInteret.calculJetonInteret(Calendar1.SelectedDate, Calendar2.SelectedDate, resteJeton2, int.Parse(TextBox2.Text));
                totalJetonApayer = totalJetonApayer + int.Parse(TextBox2.Text);
                Label2.Text = jetonInteret2.ToString();
            }
            int resteJeton3 = 0;
            if (nbrPayem >=3)
            {
                resteJeton3 = resteJeton2 - int.Parse(TextBox2.Text);
                jetonInteret3 = planInteret.calculJetonInteret(Calendar2.SelectedDate, Calendar3.SelectedDate, resteJeton3, int.Parse(TextBox3.Text));
                totalJetonApayer = totalJetonApayer + int.Parse(TextBox3.Text);
                Label3.Text = jetonInteret3.ToString();
            }
            int resteJeton4 = 0;
            if (nbrPayem >= 4)
            {
                resteJeton4 = resteJeton3 - int.Parse(TextBox3.Text);
                jetonInteret4 = planInteret.calculJetonInteret(Calendar3.SelectedDate, Calendar4.SelectedDate, resteJeton4, int.Parse(TextBox4.Text));
                totalJetonApayer = totalJetonApayer + int.Parse(TextBox4.Text);
                Label4.Text = jetonInteret4.ToString();
            }

            if (totalJetonApayer > jetonDemande)
            {
                throw new Exception("Miotra eeeeeeeeeeh!!!");
            }
            else if (totalJetonApayer < jetonDemande)
            {
                throw new Exception("Tsy ampy eeeeeeeeeeh!!!");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int idUtil = int.Parse(Request.QueryString["idUtil"]);

            PlanRemboursementAvecInteretDAO planAvecInteret = new PlanRemboursementAvecInteretDAO();
            PlanRemboursementAvecInteret remboursement1 = new PlanRemboursementAvecInteret(idDemandePret, idUtil, Calendar1.SelectedDate, int.Parse(TextBox1.Text), int.Parse(Label1.Text), 0);
            planAvecInteret.insertPlanAvecInteret(remboursement1);

            if (nbrPayem >= 2)
            {
                PlanRemboursementAvecInteret remboursement2 = new PlanRemboursementAvecInteret(idDemandePret, idUtil, Calendar2.SelectedDate, int.Parse(TextBox2.Text), int.Parse(Label2.Text), 0);
                planAvecInteret.insertPlanAvecInteret(remboursement2);
            }
            if (nbrPayem >= 3)
            {
                PlanRemboursementAvecInteret remboursement3 = new PlanRemboursementAvecInteret(idDemandePret, idUtil, Calendar3.SelectedDate, int.Parse(TextBox3.Text), int.Parse(Label3.Text), 0);
                planAvecInteret.insertPlanAvecInteret(remboursement3);
            }
            if (nbrPayem >= 4)
            {
                PlanRemboursementAvecInteret remboursement4 = new PlanRemboursementAvecInteret(idDemandePret, idUtil, Calendar4.SelectedDate, int.Parse(TextBox4.Text), int.Parse(Label4.Text), 0);
                planAvecInteret.insertPlanAvecInteret(remboursement4);
            }
        }
    }
}