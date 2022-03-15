using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foot
{
    public partial class FeuilleMatch : Form
    {
        String equipeA = null;
        String equipeB = null;
        public FeuilleMatch(String eqA, String eqB, int possessionA, int possessionB, int idEquipeA, int idEquipeB)
        {
            InitializeComponent();
            equipeA = eqA;
            equipeB = eqB;
            label6.Text = eqA;
            label7.Text = eqB;

            label8.Text = possessionA+" %";
            label12.Text = possessionB+" %";
            MatchDAO match = new MatchDAO();
            Match[] match1 = match.findDernierMatch();
            int idMatch = 0;
            String dateMatch = null;
            for (int i=0; i<match1.Length; i++)
            {
                idMatch = match1[i].getIdMatch();
                dateMatch = match1[i].getDateMatch();
            }
            StatistiqueDAO statistique = new StatistiqueDAO();
            FeuilleMatchJoueurDAO feuilleMJ = new FeuilleMatchJoueurDAO();
            FeuilleMatchJoueur[] feuilleMFinalA = feuilleMJ.findFMFinal(equipeA, idMatch);
            for (int i=0; i<feuilleMFinalA.Length; i++)
            {
                label9.Text = feuilleMFinalA[i].getTir().ToString();
                label10.Text = feuilleMFinalA[i].getTirCadre().ToString();
                label11.Text = feuilleMFinalA[i].getBut().ToString();
                //MessageBox.Show(""+idEquipeA);
                try
                {
                    Statistique statistiqueA = new Statistique(idMatch, dateMatch, idEquipeA, possessionA, feuilleMFinalA[i].getTir(), feuilleMFinalA[i].getTirCadre(), feuilleMFinalA[i].getBut());
                    statistique.insertStatistique(statistiqueA);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            FeuilleMatchJoueur[] feuilleMFinalB = feuilleMJ.findFMFinal(equipeB, idMatch);
            for (int i = 0; i < feuilleMFinalB.Length; i++)
            {
                label13.Text = feuilleMFinalB[i].getTir().ToString();
                label14.Text = feuilleMFinalB[i].getTirCadre().ToString();
                label15.Text = feuilleMFinalB[i].getBut().ToString();
                //MessageBox.Show("" + idEquipeB);
                try
                {
                    Statistique statistiqueB = new Statistique(idMatch, dateMatch, idEquipeB, possessionB, feuilleMFinalB[i].getTir(), feuilleMFinalB[i].getTirCadre(), feuilleMFinalB[i].getBut());
                    statistique.insertStatistique(statistiqueB);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            // resultatPari
            ListeMatchDAO liste = new ListeMatchDAO();
            try
            {
                liste.resultatPari(idMatch);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FeuilleMatch_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FMIndividuel individuel = new FMIndividuel(equipeA, equipeB);
            individuel.Show();
        }
    }
}
