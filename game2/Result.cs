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
    public partial class Result : Form
    {
        public Result(int score, int steps, string duration)
        {
            InitializeComponent();

            label5.Text = score.ToString();
            label6.Text = duration;
            label7.Text = steps.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Start().Show();
            this.Close();
        }
    }
}
