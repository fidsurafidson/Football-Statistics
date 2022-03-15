using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PariFoot
{
    public partial class ValiderDemande : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idUtil = int.Parse(Request.QueryString["idUtil"]);
            int idDemande = int.Parse(Request.QueryString["idDemande"]);
            DemandePretDAO demande = new DemandePretDAO();
            DemandePret[] demande1 = demande.findDemandeById(idDemande);
            DateTime dateDemande = Convert.ToDateTime(demande1[0].getDateDeblocage());
            int jetonDemande = demande1[0].getJeton();
            demande.updateDemande(idDemande, 1);
            DateTime dateNow = DateTime.Today;
            MessageBox.Show("year =" + dateNow.Year + "/ month=" + dateNow.Month + "/ day=" + dateNow.Day);
            String datyy = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dateNow.Year, dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute, dateNow.Second, dateNow.Millisecond);
            DateTime dateToday = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day);
            MessageBox.Show("date now =" + dateToday + "/ date demande =" +dateDemande);
            if (dateDemande < dateToday)
            {
                demande.updateDateDeblocage(idDemande, datyy);
                UtilisateurDAO utilisateur = new UtilisateurDAO();
                Utilisateur[] utilisateur1 = utilisateur.findUtilisateur(idUtil);
                int jetonUtil = utilisateur1[0].getJeton();
                int nouveauJeton = jetonUtil + jetonDemande;
                utilisateur.updateJetonUtil(nouveauJeton, idUtil);
            }
            Response.Redirect("~/ListeDemande.aspx");
        }
    }
}