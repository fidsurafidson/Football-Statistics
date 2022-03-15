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
    public partial class FeuilleMatch1er : Form
    {
        public FeuilleMatch1er(String equipeA, String equipeB, int possessionA, int possessionB, int tirA, int tirB, int tirCadreA, int tirCadreB, int butA, int butB)
        {
            InitializeComponent();
            label6.Text = equipeA;
            label7.Text = equipeB;
            label8.Text = possessionA+" %";
            label12.Text = possessionB+" %";
            label9.Text = tirA.ToString();
            label13.Text = tirB.ToString();
            label10.Text = tirCadreA.ToString();
            label14.Text = tirCadreB.ToString();
            label11.Text = butA.ToString();
            label15.Text = butB.ToString();
        }

        private void FeuilleMatch1er_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
