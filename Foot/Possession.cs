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
    public partial class Possession : Form
    {
        String equipeA = null;
        String equipeB = null;
        Joueur[] titulaireJoueurA = new Joueur[11];
        Joueur[] titulaireJoueurB = new Joueur[11];
        Joueur[] remplacantJoueurA = new Joueur[7];
        Joueur[] remplacantJoueurB = new Joueur[7];

        FeuilleMatchJoueur[] feuilleMatchJoueur = null;

        String joueurPossess = null;
        String equipePossess = null;
        int duree = 0;
        int dernierMatch = 0;
        String dateMatch = null;
        public Possession(String equipe1, String equipe2, int durees)
        {
            InitializeComponent();
            equipeA = equipe1;
            equipeB = equipe2;
            label5.Text = equipe1;
            label6.Text = equipe2;
            duree = durees;

            // titulaire et remplacant
            JoueurDAO joueur = new JoueurDAO();
            Joueur[] joueur1 = joueur.findJoueur(equipe1);
            for (int i = 0; i < 11; i++)
            {
                titulaireJoueurA[i] = joueur1[i];
            }
            int j = 0;
            for (int i = 11; i < joueur1.Length; i++)
            {
                remplacantJoueurA[j] = joueur1[i];
                j++;
            }

            Joueur[] joueur2 = joueur.findJoueur(equipe2);
            //MessageBox.Show(""+joueur2.Length);
            for (int i = 0; i < 11; i++)
            {
                titulaireJoueurB[i] = joueur2[i];
                //MessageBox.Show(titulaireJoueurB[i].getNom());
            }
            int k = 0;
            for (int i = 11; i < joueur1.Length; i++)
            {
                remplacantJoueurB[k] = joueur2[i];
                //MessageBox.Show(remplacantJoueurB[k].getNom());
                k++;
            }

            // feuille de match
            feuilleMatchJoueur = new FeuilleMatchJoueur[joueur1.Length+joueur2.Length];
            MatchDAO match = new MatchDAO();
            Match[] match1 = match.findDernierMatch();
            //int dernierMatch = 0;
            for (int i=0; i<match1.Length; i++)
            {
                dernierMatch = match1[i].getIdMatch();
                dateMatch = match1[i].getDateMatch();
            }
            for (int i=0; i<joueur1.Length; i++)
            {
                feuilleMatchJoueur[i] = new FeuilleMatchJoueur(i, dernierMatch, joueur1[i].getIdEquipe(), joueur1[i].getId(), 0, 0, 0, 0, 0, 0);
            }
            int x = joueur1.Length;
            for (int i = 0; i < joueur2.Length; i++)
            {
                feuilleMatchJoueur[x] = new FeuilleMatchJoueur(x, dernierMatch, joueur2[i].getIdEquipe(), joueur2[i].getId(), 0, 0, 0, 0, 0, 0);
                x++;
            }

            // ComboBox remplacant
            String[] titulaireA = new String[titulaireJoueurA.Length];
            for(int i=0; i<titulaireJoueurA.Length; i++)
            {
                titulaireA[i] = titulaireJoueurA[i].getNom();
            }
            comboBox1.DataSource = titulaireA;
            String[] remplacantA = new String[remplacantJoueurA.Length];
            for (int i = 0; i < remplacantJoueurA.Length; i++)
            {
                remplacantA[i] = remplacantJoueurA[i].getNom();
            }
            comboBox2.DataSource = remplacantA;

            String[] titulaireB = new String[titulaireJoueurB.Length];
            for (int i = 0; i < titulaireJoueurB.Length; i++)
            {
                titulaireB[i] = titulaireJoueurB[i].getNom();
            }
            comboBox3.DataSource = titulaireB;
            String[] remplacantB = new String[remplacantJoueurB.Length];
            for (int i = 0; i < remplacantJoueurB.Length; i++)
            {
                remplacantB[i] = remplacantJoueurB[i].getNom();
            }
            comboBox4.DataSource = remplacantB;

            Tir tir = new Tir(this);
            tir.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Possession_Load(object sender, EventArgs e)
        {

        }

        int milliseconde = 0;
        int seconde = 0;
        int fin = 90;
        int miTemps = 45;
        JoueurDAO joueur = new JoueurDAO();
        MatchDAO match = new MatchDAO();
        int possessionA1 = 0;
        int possessionB1 = 0;
        int possessionA2 = 0;
        int possessionB2 = 0;
        int idEquipeA = 0;
        int idEquipeB = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = duree*1000/90;
            milliseconde++;
            if (milliseconde >= 60)
            {
                seconde++;
                milliseconde = 0;
            }

            
            if (seconde == miTemps && milliseconde == 0)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                possessionA1 = match.getPossession1MTA(this);
                possessionB1 = match.getPossession1MTB(this);
                MessageBox.Show("A ='"+possessionA1+"'% / B ='"+possessionB1+"'%");
                EquipeDAO equipe = new EquipeDAO();
                Equipe[] equipe1 = equipe.findEquipe(equipeA);
                //int idEquipeA = 0;
                int tirA = 0;
                int tirCadreA = 0;
                int butA = 0;
                for (int i=0; i<equipe1.Length; i++)
                {
                    idEquipeA = equipe1[i].getId();
                }
                Equipe[] equipe2 = equipe.findEquipe(equipeB);
                //int idEquipeB = 0;
                int tirB = 0;
                int tirCadreB = 0;
                int butB = 0;
                for (int i = 0; i < equipe2.Length; i++)
                {
                    idEquipeB = equipe2[i].getId();
                }
                for (int i=0; i<feuilleMatchJoueur.Length; i++)
                {
                    if (feuilleMatchJoueur[i].getIdEquipe() == idEquipeA)
                    {
                        tirA = tirA + feuilleMatchJoueur[i].getTir();
                        tirCadreA = tirCadreA + feuilleMatchJoueur[i].getTirCadre();
                        butA = butA + feuilleMatchJoueur[i].getBut();
                    }
                }
                for (int i = 0; i < feuilleMatchJoueur.Length; i++)
                {
                    if (feuilleMatchJoueur[i].getIdEquipe() == idEquipeB)
                    {
                        tirB = tirB + feuilleMatchJoueur[i].getTir();
                        tirCadreB = tirCadreB + feuilleMatchJoueur[i].getTirCadre();
                        butB = butB + feuilleMatchJoueur[i].getBut();
                    }
                }
                
                FeuilleMatch1er feuilleM1 = new FeuilleMatch1er(equipeA, equipeB, possessionA1, possessionB1, tirA, tirB, tirCadreA, tirCadreB, butA, butB);
                feuilleM1.Show();
                timerA = 0;
                timerB = 0;
            }
            if (seconde == fin)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                ListeMatchDAO liste = new ListeMatchDAO();
                liste.updateMatch(1, dernierMatch);

                

                joueur.minuteJoueFin(this, fin);
                possessionA2 = match.getPossession1MTA(this);
                possessionB2 = match.getPossession1MTB(this);
                MessageBox.Show("A ='" + possessionA2 + "'% / B ='" + possessionB2 + "'%");

                FeuilleMatchJoueurDAO feuilleMJ = new FeuilleMatchJoueurDAO();
                for (int i = 0; i < feuilleMatchJoueur.Length; i++)
                {
                    FeuilleMatchJoueur matchJoueur = new FeuilleMatchJoueur(feuilleMatchJoueur[i].getIdMatch(), feuilleMatchJoueur[i].getIdEquipe(), feuilleMatchJoueur[i].getIdJoueur(), feuilleMatchJoueur[i].getMinuteJoue(), feuilleMatchJoueur[i].getBallonTouche(), feuilleMatchJoueur[i].getTir(), feuilleMatchJoueur[i].getTirCadre(), feuilleMatchJoueur[i].getBut(), feuilleMatchJoueur[i].getPasseDecisive());
                    feuilleMJ.insertFeuilleMatchJoueur(matchJoueur);
                }
                int possessTotalA = (possessionA1 + possessionA2) / 2;
                MessageBox.Show("possession A: '" + possessionA1+"'+'"+possessionA2+"'/2='"+possessTotalA+"'");
                int possessTotalB = (possessionB1 + possessionB2) / 2;
                MessageBox.Show("possession B: '" + possessionB1 + "'+'" + possessionB2 + "'/2='" + possessTotalB + "'");
                FeuilleMatch fenetreFM = new FeuilleMatch(equipeA, equipeB, possessTotalA, possessTotalB, idEquipeA, idEquipeB);
                fenetreFM.Show();
            }
            label10.Text = milliseconde.ToString();
            label11.Text = seconde.ToString();
        }

        public LinkLabel getLinkLabel1()
        {
            return linkLabel1;
        }
        public LinkLabel getLinkLabel2()
        {
            return linkLabel2;
        }
        public LinkLabel getLinkLabel3()
        {
            return linkLabel3;
        }
        public LinkLabel getLinkLabel4()
        {
            return linkLabel4;
        }
        public LinkLabel getLinkLabel5()
        {
            return linkLabel5;
        }
        public LinkLabel getLinkLabel6()
        {
            return linkLabel6;
        }
        public LinkLabel getLinkLabel7()
        {
            return linkLabel7;
        }
        public LinkLabel getLinkLabel8()
        {
            return linkLabel8;
        }
        public LinkLabel getLinkLabel9()
        {
            return linkLabel9;
        }
        public LinkLabel getLinkLabel10()
        {
            return linkLabel10;
        }
        public LinkLabel getLinkLabel11()
        {
            return linkLabel11;
        }
        public LinkLabel getLinkLabel12()
        {
            return linkLabel12;
        }
        public LinkLabel getLinkLabel13()
        {
            return linkLabel13;
        }
        public LinkLabel getLinkLabel14()
        {
            return linkLabel14;
        }
        public LinkLabel getLinkLabel15()
        {
            return linkLabel15;
        }
        public LinkLabel getLinkLabel16()
        {
            return linkLabel16;
        }
        public LinkLabel getLinkLabel17()
        {
            return linkLabel17;
        }
        public LinkLabel getLinkLabel18()
        {
            return linkLabel18;
        }
        public LinkLabel getLinkLabel19()
        {
            return linkLabel19;
        }
        public LinkLabel getLinkLabel20()
        {
            return linkLabel20;
        }
        public LinkLabel getLinkLabel21()
        {
            return linkLabel21;
        }
        public LinkLabel getLinkLabel22()
        {
            return linkLabel22;
        }
        public ComboBox getComboBox1()
        {
            return comboBox1;
        }
        public ComboBox getComboBox2()
        {
            return comboBox2;
        }
        public ComboBox getComboBox3()
        {
            return comboBox3;
        }
        public ComboBox getComboBox4()
        {
            return comboBox4;
        }

        public Joueur[] getTitulaireJoueurA()
        {
            return titulaireJoueurA;
        }
        public Joueur[] getTitulaireJoueurB()
        {
            return titulaireJoueurB;
        }
        public Joueur[] getRemplacantJoueurA()
        {
            return remplacantJoueurA;
        }
        public Joueur[] getRemplacantJoueurB()
        {
            return remplacantJoueurB;
        }
        public FeuilleMatchJoueur[] getFeuilleMatchJoueur()
        {
            return feuilleMatchJoueur;
        }
        public String getJoueurPossess()
        {
            return joueurPossess;
        }
        public String getEquipePossess()
        {
            return equipePossess;
        }
        public int getTimerA()
        {
            return timerA;
        }
        public int getTimerB()
        {
            return timerB;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            MatchDAO match = new MatchDAO();
            match.changement(this, seconde, miTemps, titulaireJoueurA, titulaireJoueurB);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MatchDAO match = new MatchDAO();
            match.remplacementA(comboBox1.Text, comboBox2.Text, this);
            JoueurDAO joueur = new JoueurDAO();
            joueur.minuteJoue(this, comboBox1.Text, comboBox2.Text, label5.Text, int.Parse(label11.Text), fin);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MatchDAO match = new MatchDAO();
            match.remplacementB(comboBox3.Text, comboBox4.Text, this);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel1.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel1.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel1.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel2.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel2.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel2.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel3.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel3.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel3.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel4.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel4.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel4.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel5.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel5.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel5.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel6.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel6.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel6.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel7.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel7.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel7.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel8.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel8.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel7.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel9.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel9.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel9.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel10.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel10.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel10.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel11.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel11.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel11.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel22.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel22.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel22.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel20.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel20.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel20.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel21.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel21.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel21.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel17.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel17.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel17.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel18.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel18.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel18.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel19.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel19.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel19.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel13.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel13.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel13.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel14.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel14.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel14.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel15.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel15.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel15.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel16.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel16.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel16.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JoueurDAO joueur = new JoueurDAO();
            joueurPossess = linkLabel12.Text;
            if (int.Parse(label11.Text) < miTemps)
            {
                joueur.ballonTouche(this, linkLabel12.Text, label6.Text);
                equipePossess = label6.Text;
                timer3.Start();
                timer2.Stop();
            }
            else
            {
                joueur.ballonTouche(this, linkLabel12.Text, label5.Text);
                equipePossess = label5.Text;
                timer2.Start();
                timer3.Stop();
            }
        }

        int timerA = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = duree * 1000 / 90;
            timerA++;
            label13.Text = timerA.ToString();
        }
        
        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        int timerB = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = duree * 1000 / 90;
            timerB++;
            label14.Text = timerB.ToString();
        }
    }
}
