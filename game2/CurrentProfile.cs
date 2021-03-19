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
    public partial class CurrentProfile : Form
    {
        public CurrentProfile()
        {
            InitializeComponent();
            //MessageBox.Show(MainClass.current + " " + MainClass.profiles.Count);

            int current = MainClass.current;
            
            //show profile info:
            textBox1.Text = MainClass.profiles[current].name;
            
            if (MainClass.profiles[current].gender == Gender.MALE)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            
            comboBox1.SelectedIndex = MainClass.profiles[current].age - 3;

            if (MainClass.profiles[current].toyFigure == "cat.png")
                radioButton3.Checked = true;
            else if (MainClass.profiles[current].toyFigure == "c1.png")
                radioButton4.Checked = true;
            else
                radioButton5.Checked = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int current = MainClass.current;

            bool flag = true;

            //set name
            if (textBox1.Text == string.Empty)
                flag = false;
            else
                MainClass.profiles[current].name = textBox1.Text;

            //set gender
            if (radioButton1.Checked)
                MainClass.profiles[current].gender = Gender.MALE;
            else if (radioButton2.Checked)
                MainClass.profiles[current].gender = Gender.FEMALE;
            else
                flag = false;

            //set age
            if (comboBox1.SelectedIndex != -1)
                MainClass.profiles[current].age = Int32.Parse(comboBox1.SelectedItem.ToString());
            else
                flag = false;

            //set toy figure
            if (radioButton3.Checked)
                MainClass.profiles[current].toyFigure = "cat.png";
            else if (radioButton4.Checked)
                MainClass.profiles[current].toyFigure = "c1.png";
            else if (radioButton5.Checked)
                MainClass.profiles[current].toyFigure = "c2.png";

            if (!flag)
                label6.Visible = true; //show a message if one of the fields is empty
            else
            {
                label6.Visible = false;
                this.Close();
                new Form1().Show();
            }
        }
    }
}
