using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();

            label4.Text = MainClass.NumOfGames().ToString();
            label6.Text = MainClass.profiles.Count.ToString();
            label8.Text = MainClass.HighestScore().ToString();
            label10.Text = MainClass.LowestScore().ToString();
            label12.Text = MainClass.MinimumDuration();
            label14.Text = MainClass.MaximumDuration();
            label16.Text = MainClass.TotalDuration();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }

        private void currentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new CurrentProfile().Show();
        }

        private void newProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new CreateProfile().Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new Statistics().Show();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new History().Show();
        }
    }
}
