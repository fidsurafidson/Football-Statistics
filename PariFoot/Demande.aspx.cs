using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PariFoot
{
    public partial class Demande : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idUtilisateur = int.Parse(Request.QueryString["idUtil"]);
            PlanRemboursementAvecInteretDAO plan = new PlanRemboursementAvecInteretDAO();
            PlanRemboursementAvecInteret[] plan1 = plan.findPretNonRembourse(idUtilisateur);
            if (plan1.Length != 0)
            {
                MessageBox.Show("Vous n'avez pas encore fini votre remboursement");
            }
            else
            {
                DemandePretDAO demandePret = new DemandePretDAO();
                DemandePret demandePret1 = new DemandePret(idUtilisateur, Calendar1.SelectedDate, int.Parse(TextBox1.Text), 0);
                demandePret.insertDemande(demandePret1);
                int nbrPayem = int.Parse(DropDownList1.Text);
                Response.Redirect("~/PlanDeRemboursement.aspx?idUtil=" + idUtilisateur + "&nbrPayem=" + nbrPayem);
            }
        }
    }
}