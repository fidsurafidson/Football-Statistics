using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PariFoot
{
    public partial class Simulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                /*int idDemande = int.Parse(Request.QueryString["idDemande"]);
                PlanRemboursementAvecInteretDAO plan = new PlanRemboursementAvecInteretDAO();
                PlanRemboursementAvecInteret[] plan1 = plan.findPlanByIdDemande(idDemande);
                String dates = Request["inputDate"];
                String jetons = Request["inputText"];
                String ids = Request["inputId"];
                String[] listeDate = dates.Split(',');
                String[] listeJeton = dates.Split(',');
                String[] listeId = dates.Split(',');
                DateTime[] tabDate = new DateTime[listeDate.Length];
                int[] tabJeton = new int[listeJeton.Length];
                int[] tabId = new int[listeId.Length];
                for (int i = 0; i < plan1.Length; i++)
                {
                    tabDate[i] = Convert.ToDateTime(listeDate[i]);
                    tabJeton[i] = Int32.Parse(listeJeton[i]);
                    tabId[i] = Int32.Parse(listeId[i]);
                }
                Response.Write("tonga atreto <br/>");
                for (int i=0; i<plan1.Length; i++)
                {
                    int resteJeton = 0;
                    PlanRemboursementAvecInteret[] listePaye = plan.findPlanPayeByIdDemande(idDemande);
                    if (i==0)
                    {
                        DemandePretDAO demande = new DemandePretDAO();
                        DemandePret[] demande1 = demande.findDemandeById(idDemande);
                        DateTime dateDeblocage = Convert.ToDateTime(demande1[0].getDateDeblocage());
                        int jetonDemande = demande1[0].getJeton();
                        if (listePaye.Length == 0)
                        {
                            /*DemandePretDAO demande = new DemandePretDAO();
                            DemandePret[] demande1 = demande.findDemandeById(idDemande);
                            DateTime dateDeblocage = Convert.ToDateTime(demande1[0].getDateDeblocage());
                            int jetonDemande = demande1[0].getJeton();*/
                            /*resteJeton = jetonDemande;
                            int jetonInteret = plan.calculJetonInteret(dateDeblocage, tabDate[i], jetonDemande, tabJeton[i]);
                            Response.Write("Jeton avec interet : " + jetonInteret + "<br/>");
                        }
                        else
                        {
                            PlanRemboursementAvecInteret[] planPaye = plan.findDernierPaye(idDemande);
                            DateTime dateDernierRemboursement = Convert.ToDateTime(planPaye[0].getDateRemboursement());
                            int jetonDejaPaye = 0;
                            for (int j=0; j<listePaye.Length; j++)
                            {
                                jetonDejaPaye = jetonDejaPaye + listePaye[j].getJetonSansInteret();
                            }
                            resteJeton = jetonDemande - jetonDejaPaye;
                            int jetonInteret = plan.calculJetonInteret(dateDernierRemboursement, tabDate[i], resteJeton, tabJeton[i]);
                            Response.Write("Jeton avec interet : " + jetonInteret + "<br/>");
                        }
                    }
                    else
                    {
                        resteJeton = resteJeton - tabJeton[i];
                        int jetonInteret = plan.calculJetonInteret(tabDate[i - 1], tabDate[i], resteJeton, tabJeton[i]);
                        Response.Write("Jeton avec interet : " + jetonInteret + "<br/>");
                    }
                }*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int idDemande = int.Parse(Request.QueryString["idDemande"]);
            DateTime daty = Calendar1.SelectedDate;
            MessageBox.Show("" + daty);
            String nouveauDate = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", daty.Year, daty.Month, daty.Day, daty.Hour, daty.Minute, daty.Second, daty.Millisecond);
            DateTime dateNew = Convert.ToDateTime(nouveauDate);
            int QteNouveauJeton = int.Parse(TextBox1.Text);
            PlanRemboursementAvecInteretDAO plan = new PlanRemboursementAvecInteretDAO();
            try
            {
                PlanRemboursementAvecInteret[] listePlan = plan.findDemande(idDemande, nouveauDate);
                int sommeJeton = 0;
                for (int i=0; i<listePlan.Length; i++)
                {
                    sommeJeton = sommeJeton + listePlan[i].getJetonSansInteret();
                }
                ArrayList nouveauPlan = new ArrayList();
                if (QteNouveauJeton <= sommeJeton)
                {
                    DemandePretDAO demande = new DemandePretDAO();
                    DemandePret[] demande1 = demande.findDemandeById(idDemande);
                    DateTime dateDeblocage = Convert.ToDateTime(demande1[0].getDateDeblocage());
                    int jetonDemande = demande1[0].getJeton();
                    int j = 0;
                    while (QteNouveauJeton > 0 && j != listePlan.Length)
                    {
                        int jetonBase = listePlan[j].getJetonSansInteret();
                        if (QteNouveauJeton >= jetonBase)
                        {
                            QteNouveauJeton = QteNouveauJeton - jetonBase;
                            listePlan[j].setJetonAvecInteret(0);
                            listePlan[j].setJetonSansInteret(0);
                            MessageBox.Show(""+ listePlan[j].getJetonSansInteret());

                        }
                        else
                        {
                            int qtBase = jetonBase - QteNouveauJeton;
                            listePlan[j].setJetonSansInteret(qtBase);
                            QteNouveauJeton = 0;


                            //int resteJeton = 0;
                            
                            PlanRemboursementAvecInteret[] listePlanInferieur = plan.findPlanInferieur(idDemande, nouveauDate);
                            if (j == 0)
                            {
                                
                                if (listePlanInferieur.Length == 0)
                                {
                                        /*DemandePretDAO demande = new DemandePretDAO();
                                        DemandePret[] demande1 = demande.findDemandeById(idDemande);
                                        DateTime dateDeblocage = Convert.ToDateTime(demande1[0].getDateDeblocage());
                                        int jetonDemande = demande1[0].getJeton();*/
                                        //resteJeton = jetonDemande;
                                        int reste = jetonDemande - int.Parse(TextBox1.Text);
                                        MessageBox.Show("JetonDemande ="+ jetonDemande + " - textBox ="+ int.Parse(TextBox1.Text));
                                        int jetonInteret = plan.calculJetonInteret(dateNew, Convert.ToDateTime(listePlan[j].getDateRemboursement()), reste, qtBase);
                                        //Response.Write("Jeton avec interet : " + jetonInteret + "<br/>");
                                        listePlan[j].setJetonAvecInteret(jetonInteret);
                                }
                                else
                                {
                                    try
                                    {
                                        int jetonDejaPaye = 0;
                                        for (int k = 0; k < listePlanInferieur.Length; k++)
                                        {
                                            jetonDejaPaye = jetonDejaPaye + listePlanInferieur[k].getJetonSansInteret();
                                        }
                                        int resteJeton = jetonDemande - jetonDejaPaye - int.Parse(TextBox1.Text);
                                        MessageBox.Show("reste ="+jetonDemande+" - "+ jetonDejaPaye + "-" + int.Parse(TextBox1.Text));
                                        int jetonInteret = plan.calculJetonInteret(dateNew, Convert.ToDateTime(listePlan[j].getDateRemboursement()), resteJeton, qtBase);
                                        //Response.Write("Jeton avec interet : " + jetonInteret + "<br/>");
                                        listePlan[j].setJetonAvecInteret(jetonInteret);
                                    }
                                    catch (Exception exce)
                                    {
                                        MessageBox.Show(exce.Message);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("tafiditra ato else i!=0");
                                try
                                {
                                    PlanRemboursementAvecInteret[] listePlanInferieur1 = plan.findPlanInferieur(idDemande, listePlan[j].getDateRemboursement());
                                    int jetonDejaPaye = 0;
                                    for (int k = 0; k < listePlanInferieur1.Length; k++)
                                    {
                                        jetonDejaPaye = jetonDejaPaye + listePlanInferieur1[k].getJetonSansInteret();
                                    }
                                    int resteJeton = jetonDemande - jetonDejaPaye - int.Parse(TextBox1.Text);
                                    MessageBox.Show("reste =" + jetonDemande + " - " + jetonDejaPaye + "-" + int.Parse(TextBox1.Text));
                                    //int jetonInteret = plan.calculJetonInteret(Convert.ToDateTime(listePlan[j - 1].getDateRemboursement()), Convert.ToDateTime(listePlan[j].getDateRemboursement()), resteJeton, qtBase);
                                    int jetonInteret = plan.calculJetonInteret(dateNew, Convert.ToDateTime(listePlan[j].getDateRemboursement()), resteJeton, qtBase);
                                    listePlan[j].setJetonAvecInteret(jetonInteret);
                                    Response.Write("Jeton avec interet : " + jetonInteret + "<br/>");
                                }
                                catch (Exception exce)
                                {
                                    MessageBox.Show(exce.Message);
                                }
                            }
                        }
                        nouveauPlan.Add(listePlan[j]);
                        j++;
                    }

                    PlanRemboursementAvecInteret[] listePlanInferieur2 = plan.findPlanInferieur(idDemande, nouveauDate);
                    int jetonInferieur = 0;
                    for (int k = 0; k < listePlanInferieur2.Length; k++)
                    {
                        jetonInferieur = jetonInferieur + listePlanInferieur2[k].getJetonSansInteret();
                    }
                    MessageBox.Show("totalReste =" + jetonDemande + " - " + jetonInferieur + "-" + int.Parse(TextBox1.Text));
                    int totalReste = jetonDemande - jetonInferieur - int.Parse(TextBox1.Text);
                    for (int i=j; i<listePlan.Length; i++)
                    {
                        MessageBox.Show("totalReste2 =" + totalReste + " - " + listePlan[i - 1].getJetonSansInteret());
                        totalReste = totalReste - listePlan[i-1].getJetonSansInteret();
                        int jetonInteret = 0;
                        if (listePlan[i - 1].getJetonSansInteret() == 0)
                        {
                            jetonInteret = plan.calculJetonInteret(dateNew, Convert.ToDateTime(listePlan[i].getDateRemboursement()), totalReste, listePlan[i].getJetonSansInteret());
                        }
                        else
                        {
                            jetonInteret = plan.calculJetonInteret(Convert.ToDateTime(listePlan[i - 1].getDateRemboursement()), Convert.ToDateTime(listePlan[i].getDateRemboursement()), totalReste, listePlan[i].getJetonSansInteret());
                        }
                        listePlan[i].setJetonAvecInteret(jetonInteret);
                        nouveauPlan.Add(listePlan[i]);
                    }
                }

                
                String dates = "";
                String jetons = "";
                PlanRemboursementAvecInteret[] nouveauPlanFinal = new PlanRemboursementAvecInteret[nouveauPlan.Count];
                MessageBox.Show("Count ArrayList="+nouveauPlan.Count);
                for (int i=0; i<nouveauPlan.Count; i++)
                {
                    MessageBox.Show("Tafiditra anatinle farany");
                    nouveauPlanFinal[i] = (PlanRemboursementAvecInteret)nouveauPlan[i];
                    dates = dates + "<br/>" + nouveauPlanFinal[i].getDateRemboursement();
                    Label3.Text = dates + "<br/>";
                    jetons = jetons + "<br/>" + nouveauPlanFinal[i].getJetonAvecInteret();
                    Label4.Text = jetons + "<br/>";
                    MessageBox.Show("date: " + nouveauPlanFinal[i].getDateRemboursement() + "/ jeton: " + nouveauPlanFinal[i].getDateRemboursement());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
 