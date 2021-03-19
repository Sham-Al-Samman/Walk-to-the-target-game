using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace game2
{
    public partial class History : Form
    {
        
        public History()
        {
            InitializeComponent();


            label7.Text = MainClass.profiles[0].name;
            label9.Text = MainClass.profiles[0].games[0].date;
            label10.Text = MainClass.profiles[0].games[0].duration;
            label11.Text = MainClass.profiles[0].games[0].successfulMoves.ToString();
            label12.Text = MainClass.profiles[0].games[0].numOfBarriers.ToString();
            //foreach (Profile p in MainClass.profiles)
            {
                
                displaySteps(MainClass.profiles[0].games[0]);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            //fun();
        }

        public void displaySteps(Game g)
        {
            tableLayoutPanel3.RowCount = g.successfulMoves;
            for (int i = 1; i <= g.successfulMoves; i++)
            {
                Label l1 = new Label();
                Label l2 = new Label();
                l1.Size = l2.Size = label13.Size;
                l1.Dock = l2.Dock = label13.Dock;
                l1.BackColor = l2.BackColor = label13.BackColor;
                l1.Font = l2.Font = label13.Font;
                l1.Margin = l2.Margin = label13.Margin;
                l1.TextAlign = l2.TextAlign = label13.TextAlign;

                l1.Text = i.ToString();
                l2.Text = g.steps[i-1].ToString();

                tableLayoutPanel3.Controls.Add(l1, 0, i);
                tableLayoutPanel3.Controls.Add(l2, 1, i);
                //tableLayoutPanel3.Controls.Add(new TextBox(), 0, 3);
                //tableLayoutPanel3.Controls.Add(new TextBox(), 1, 3);
                //tableLayoutPanel3.Controls.Add(new TextBox(), 0, 4);
                //tableLayoutPanel3.Controls.Add(new TextBox(), 1, 4);

                tableLayoutPanel3.Height += l1.Size.Height;
            }
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

        //public DataTable CreateDynamicTable(int rows, int cols)
        //{
        //    System.Data.DataTable mytable = new System.Data.DataTable();

        //    System.Data.DataColumn tColumn = null;      // TABLE COLUMNS.

        //    tColumn = new System.Data.DataColumn("Product", System.Type.GetType("System.String"));
        //    mytable.Columns.Add(tColumn);
        //    tColumn = new System.Data.DataColumn("Stock", System.Type.GetType("System.String"));
        //    mytable.Columns.Add(tColumn);
        //    tColumn = new System.Data.DataColumn("Quantity", System.Type.GetType("System.String"));
        //    mytable.Columns.Add(tColumn);
        //    tColumn = new System.Data.DataColumn(" ", System.Type.GetType("System.String"));
        //    mytable.Columns.Add(tColumn);




        //    return mytable;

        //    TableLayoutPanel t = new TableLayoutPanel();
        //    //t.RowCount = rows;
        //    //t.ColumnCount = cols;
        //    //t.Location = new Point(button1.Location.X + 10, button1.Bottom + 10);
        //   // t.Controls.Add(new DataGridCell());

        //    for (int i=0; i < rows; i++)
        //    {
        //        for (int j=0; j < cols; j++)
        //        {
        //            TextBox txt = new TextBox();
        //            txt.Dock = DockStyle.Fill;
        //            txt.Margin = new Padding(0);
        //            // t.Controls.Add(txt , i, j);

        //            DataTable dt = new DataTable();
        //            DataGrid d;
        //           // DataColumn
        //        }
        //       // MenuItem m = new MenuItem();


        //    }

        //    //return t;
        //}
    }
}
