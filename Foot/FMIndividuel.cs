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
    public partial class FMIndividuel : Form
    {
        public FMIndividuel(String equipeA, String equipeB)
        {
            InitializeComponent();
            MatchDAO match = new MatchDAO();
            Match[] match1 = match.findDernierMatch();
            int idMatch = 0;
            for(int i=0; i<match1.Length; i++)
            {
                idMatch = match1[i].getIdMatch();
            }
            JoueurDAO joueur = new JoueurDAO();
            Joueur[] joueur1 = joueur.findJoueurEquipe(idMatch);
            for(int i=0; i<joueur1.Length; i++)
            {
                this.dataGridView1.Rows.Add(joueur1[i].getId(), joueur1[i].getNom(), joueur1[i].getNomEquipe());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idJoueur = int.Parse(dataGridView1.CurrentRow.Cells["Column1"].Value.ToString());
            String nomJoueur = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
            //MessageBox.Show(idJoueur+"");
            FeuilleMatchJoueurDAO statistique = new FeuilleMatchJoueurDAO();
            FeuilleMatchJoueur[] statistique1 = statistique.findFMJoueur(idJoueur);
            //MessageBox.Show(""+statistique1.Length);
            for (int i=0; i<statistique1.Length; i++)
            {
                label7.Text = nomJoueur;
                label10.Text = statistique1[i].getMinuteJoue().ToString();
                label12.Text = statistique1[i].getBallonTouche().ToString();
                label11.Text = statistique1[i].getTir().ToString();
                label15.Text = statistique1[i].getTirCadre().ToString();
                label14.Text = statistique1[i].getBut().ToString();
                label13.Text = statistique1[i].getPasseDecisive().ToString();
            }
        }

        private void FMIndividuel_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
