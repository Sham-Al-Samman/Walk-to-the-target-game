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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(MainClass.profiles.ToArray()); // it is empty at the begining // 
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                label3.Visible = true; //show a message
            else
            {
                MainClass.current = comboBox1.SelectedIndex;
                label3.Visible = false;
                Form1 playForm = new Form1();
                playForm.Show();
                this.Hide();
            }
                
        }

        private void createProfileButton_Click(object sender, EventArgs e)
        {
            CreateProfile profileForm = new CreateProfile();
            profileForm.Show();
            this.Hide();
        }
    }
}
