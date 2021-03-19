using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    public partial class Form1 : Form
    {
        int speed = 90;
        int numOfSteps = 0;
        int numOfSuccessfulSteps = 0;
        int numOfBarriers;
        int seconds = 0;
        int minutes = 0;

        Game g;

        public Form1()
        {
            InitializeComponent();

            //display user name:
            label6.Text = MainClass.profiles[MainClass.current].name;
            //set toy figure:
            if (MainClass.profiles[MainClass.current].toyFigure == "cat.png")
                toy.Image = game2.Properties.Resources.cat;
            else if (MainClass.profiles[MainClass.current].toyFigure == "c1.png")
                toy.Image = game2.Properties.Resources.c1;
            else
                toy.Image = game2.Properties.Resources.c2;

            // random barriers:
            Random r = new Random();

            int barriers = numOfBarriers = r.Next(1, 4);
            int c = 0, random = r.Next(0, 26);
            foreach (Control box in panel1.Controls)
            {
                if (box is PictureBox && (box.Tag == "vertical barrier" || box.Tag == "horizantal barrier"))
                {
                    c++;
                    if (c == random)
                    {
                        box.Visible = true;
                        barriers--;
                        random = r.Next(c+1, 26);
                    }
                    if (barriers == 0)
                        break;
                    
                }
            }

            //create a new game:
            g = new Game();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                numOfSteps++;

            if (e.KeyCode == Keys.Left && toy.Left - speed > 0 && ThereAreNoBarriers("left"))
            {
                
                toy.Left -= 90;
                numOfSuccessfulSteps++;
                g.steps.Add(Keys.Left);
                if (!timer1.Enabled) timer1.Enabled = true;
            }
            if (e.KeyCode == Keys.Right && toy.Right + speed < panel1.Right && ThereAreNoBarriers("right"))
            {
                
                toy.Left += speed;
                numOfSuccessfulSteps++;
                g.steps.Add(Keys.Right);
                if (!timer1.Enabled) timer1.Enabled = true;
            }
            
            if (e.KeyCode == Keys.Up && toy.Top - speed >= 0 && ThereAreNoBarriers("up"))
            {
                
                toy.Top -= speed;
                numOfSuccessfulSteps++;
                g.steps.Add(Keys.Up);
                if (!timer1.Enabled) timer1.Enabled = true;
            }
            if (e.KeyCode == Keys.Down && toy.Bottom + speed < panel1.Bottom && ThereAreNoBarriers("down"))
            {
                
                toy.Top += speed;
                numOfSuccessfulSteps++;
                g.steps.Add(Keys.Down);
                if (!timer1.Enabled) timer1.Enabled = true; 
            }
            
            label9.Text = numOfSteps.ToString();
            label10.Text = numOfSuccessfulSteps.ToString();
            
            if (toy.Bounds.IntersectsWith(target.Bounds)) // if the player hits the target 
            {
                timer1.Enabled = false;

                //add this game to the current profile:
                g.setInfo(label8.Text, numOfSteps, numOfSuccessfulSteps, numOfBarriers ,100/numOfSteps);
                MainClass.profiles[MainClass.current].games.Add(g);

                new Result(100/numOfSteps, numOfSuccessfulSteps, label8.Text).Show();
                this.Close();
                //MessageBox.Show("you won !\n" + numOfSteps + "\n" + label8.Text);
            }
            
        }

        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{
        //}

        /*
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        */

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sec;
            string min;

            seconds++;
            
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            sec = seconds < 10 ? "0" + seconds : seconds.ToString();
            min = minutes < 10 ? "0" + minutes : minutes.ToString();

            label8.Text = min + ':' + sec;
            label7.Text = (100 / numOfSteps).ToString();

            //label11.Text = pictureBox4.Left + ", " + pictureBox4.Right + ", " + pictureBox4.Top + ", " + pictureBox4.Bottom;
            //label12.Text = toy.Location.X + ", " + toy.Right + ", " + toy.Top + ", " + toy.Bottom;
        }

        private bool ThereAreNoBarriers(string direction)
        {
            
            bool canMove = true;
            foreach (Control box in panel1.Controls)
            {
                if (box is PictureBox && box.Tag == "vertical barrier" && box.Visible==true)
                {
                    switch (direction)
                    {
                        case "left":
                            {
                                if (toy.Left > box.Left && toy.Left < box.Right && toy.Bounds.IntersectsWith(box.Bounds))
                                    canMove = false;
                                break;
                            }
                        case "right":
                            {
                                if (toy.Right > box.Left && toy.Right < box.Right && toy.Bounds.IntersectsWith(box.Bounds))
                                    canMove = false;
                                break;
                            }
                    }
                }
                else if (box is PictureBox && box.Tag == "horizantal barrier" && box.Visible == true)
                {
                    
                    switch (direction)
                    {  
                        case "up":
                            {
                                if (toy.Top > box.Top && toy.Top < box.Bottom && toy.Bounds.IntersectsWith(box.Bounds))
                                    canMove = false;
                                break;
                            }
                        case "down":
                            {
                                if (toy.Bottom > box.Top && toy.Bottom < box.Bottom && toy.Bounds.IntersectsWith(box.Bounds))
                                    canMove = false;
                                break;
                            }
                    }
                }
            }
            return canMove;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {

        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new Statistics().Show();
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

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new History().Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1_KeyDown(null, new KeyEventArgs(Keys.Up));
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            Form1_KeyDown(null, new KeyEventArgs(Keys.Down));
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            Form1_KeyDown(null, new KeyEventArgs(Keys.Left));
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            Form1_KeyDown(null, new KeyEventArgs(Keys.Right));
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
    }
}
