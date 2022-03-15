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
    public partial class Tir : Form
    {
        Possession possession = null;
        public Tir(Possession fenetre)
        {
            InitializeComponent();
            possession = fenetre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(possession.getJoueurPossess());
            JoueurDAO joueur = new JoueurDAO();
            joueur.but(possession, possession.getEquipePossess(), possession.getJoueurPossess());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueur.but(possession, possession.getEquipePossess(), possession.getJoueurPossess());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueur.tirCadre(possession, possession.getEquipePossess(), possession.getJoueurPossess());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueur.tirCadre(possession, possession.getEquipePossess(), possession.getJoueurPossess());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueur.horsCadre(possession, possession.getEquipePossess(), possession.getJoueurPossess());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueur.horsCadre(possession, possession.getEquipePossess(), possession.getJoueurPossess());
        }

        private void Tir_Load(object sender, EventArgs e)
        {

        }
    }
}
