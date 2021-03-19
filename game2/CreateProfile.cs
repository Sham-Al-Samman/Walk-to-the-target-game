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
    public partial class CreateProfile : Form
    {
        public CreateProfile()
        {
            InitializeComponent();

            //check the first toy figure by default
            radioButton3.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile p = new Profile();
            bool flag = true;

            //set name
            if (textBox1.Text == string.Empty)
                flag = false;
            else
                p.name = textBox1.Text;

            //set gender
            if (radioButton1.Checked)
                p.gender = Gender.MALE;
            else if (radioButton2.Checked)
                p.gender = Gender.FEMALE;
            else
                flag = false;

            //set age
            if (comboBox1.SelectedIndex != -1)
                p.age = Int32.Parse(comboBox1.SelectedItem.ToString());
            else
                flag = false;

            //set toy figure
            if (radioButton3.Checked)
                p.toyFigure = "cat.png";
            else if (radioButton4.Checked)
                p.toyFigure = "c1.png";
            else if (radioButton5.Checked)
                p.toyFigure = "c2.png";

            if (!flag)
                label6.Visible = true; //show a message if one of the fields is empty
            else
            {
                label6.Visible = false;
                //add profile
                MainClass.profiles.Add(p);
                MainClass.current = MainClass.profiles.Count - 1;

                ///// open playing form after saving a profile./////
                new Form1().Show();
                this.Close();
            }
            
        }
    }
}
