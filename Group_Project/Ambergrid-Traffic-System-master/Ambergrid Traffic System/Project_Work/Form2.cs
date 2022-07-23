using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Work
{
    public partial class Form2 : Form
    {
        decimal l = 0;
        public Form2()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (l == 0)
            {
                timer1.Interval = 1;
                l++;
                label1.Visible = true;
            }
            else if (l == 1)
            {
                timer1.Interval = 500;
                l++;
                label2.Visible = true;
            }
            else if (l == 2)
            {
                timer1.Interval = 500;
                l++;
                label3.Visible = true;
            }
            else if (l == 3)
            {
                timer1.Interval = 500;
                l++;
                label4.Visible = true;
            }
            else if (l == 4)
            {
                timer1.Interval = 500;
                l++;
                label5.Visible = true;
            }
            else if (l == 5)
            {
                timer1.Interval = 500;
                l++;
                label6.Visible = true;
            }
            else if (l == 6)
            {
                timer1.Interval = 500;
                l++;
                label7.Visible = true;
            }
            else if (l == 7)
            {
                timer1.Interval = 500;
                l++;
                label8.Visible = true;
            }
            else if (l == 8)
            {
                timer1.Interval = 500;
                l++;
                label9.Visible = true;
            }
            else if (l == 9)
            {
                timer1.Interval = 500;
                l++;
                label10.Visible = true;
            }
            else if (l == 10)
            {
                this.Hide();
                Form4 f4 = new Form4();
                f4.Show();
                timer1.Stop();
            }
        }
    }
}