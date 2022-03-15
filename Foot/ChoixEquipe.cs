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
    public partial class ChoixEquipe : Form
    {
        int idMatch = 0;
        String dateMatch = null;
        String nomEquipe1 = null;
        String nomEquipe2 = null;
        public ChoixEquipe()
        {
            InitializeComponent();
            /*EquipeDAO equipe = new EquipeDAO();
            Equipe[] equipe1 = equipe.findEquipe();
            String[] nom = new String[equipe1.Length];
            for (int i=0; i<equipe1.Length; i++)
            {
                nom[i] = equipe1[i].getNom();
            }
            comboBox1.DataSource = nom;
            Equipe[] equipe2 = equipe.findEquipe();
            String[] nom2 = new String[equipe2.Length];
            for (int i = 0; i < equipe2.Length; i++)
            {
                nom2[i] = equipe2[i].getNom();
            }
            comboBox2.DataSource = nom2;*/

            ListeMatchDAO listeMatch = new ListeMatchDAO();
            try
            {
                ListeMatch[] listeMatch1 = listeMatch.findListeMatch();
                for (int i = 0; i < listeMatch1.Length; i++)
                {
                    this.dataGridView1.Rows.Add(listeMatch1[i].getId().ToString(), listeMatch1[i].getDateMatch().ToString(), listeMatch1[i].getNomEquipe1().ToString(), listeMatch1[i].getNomEquipe2().ToString());
                }
            }
            catch (Exception e)
            {
                Console.Out.Write(e.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChoixEquipe_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*EquipeDAO equipe = new EquipeDAO();
            Equipe[] equipe1 = equipe.findEquipe(comboBox1.Text);
            int idEquipe1 = 0;
            for (int i=0; i<equipe1.Length; i++)
            {
                idEquipe1 = equipe1[i].getId();
            }
            Equipe[] equipe2 = equipe.findEquipe(comboBox2.Text);
            int idEquipe2 = 0;
            for (int i = 0; i < equipe2.Length; i++)
            {
                idEquipe2 = equipe2[i].getId();
            }
            MatchDAO match = new MatchDAO();
            Match match1 = new Match(idEquipe1, idEquipe2, dateTimePicker1.Value.ToString());
            //match.insertMatch(match1);
            int minute = int.Parse(textBox1.Text);
            Possession fenetre = new Possession(comboBox1.Text, comboBox2.Text, minute);
            fenetre.Show();
            //Tir tir = new Tir();
            //tir.Show();
            this.Hide();*/

            EquipeDAO equipe = new EquipeDAO();
            Equipe[] equipe1 = equipe.findEquipe(nomEquipe1);
            int idEquipe1 = 0;
            for (int i = 0; i < equipe1.Length; i++)
            {
                idEquipe1 = equipe1[i].getId();
            }
            Equipe[] equipe2 = equipe.findEquipe(nomEquipe2);
            int idEquipe2 = 0;
            for (int i = 0; i < equipe2.Length; i++)
            {
                idEquipe2 = equipe2[i].getId();
            }
            MatchDAO match = new MatchDAO();
            Match match1 = new Match(idMatch, idEquipe1, idEquipe2, dateMatch);
            match.insertMatch(match1);
            int minute = int.Parse(textBox1.Text);
            Possession fenetre = new Possession(nomEquipe1, nomEquipe2, minute);
            fenetre.Show();
            //Tir tir = new Tir();
            //tir.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idMatch = int.Parse(dataGridView1.CurrentRow.Cells["Column1"].Value.ToString());
            dateMatch = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
            nomEquipe1 = dataGridView1.CurrentRow.Cells["Column3"].Value.ToString();
            nomEquipe2 = dataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
            MessageBox.Show(""+idMatch+"_"+dateMatch+"_"+nomEquipe1+"_"+nomEquipe2);
        }
    }
}
