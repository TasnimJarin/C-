using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Project_Work
{
    public partial class Form15 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form15()
        {
            InitializeComponent();
        }
        void ResetContro()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();

        }
        public static String status="Unknown";
        public static String ER = "NO";
        public static String SV = "YES";
        public static String DES = "  ";
        public static String PAYMENT= "NO";


        public static string reason;
        public static string amount;
        bool a, b, c, d;
        public static string p =Form4.x;

        private void button3_Click(object sender, EventArgs e)
        {
            a = textBox1.Text != "";
            b = textBox3.Text != "";
            c = textBox2.Text != "";
            d = textBox4.Text != "";
            if (a && b && c && d)
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey3 = " Select * from PENALTY_TABLE  where UID=@UID";
                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                cmd3.Parameters.AddWithValue("@UID", textBox3.Text);
                con.Open();
                if (cmd3.ExecuteScalar() != null)
                {
                    MessageBox.Show("THIS USER IS ALREADY PENALIZED");
                }
                else
                {

                    if (a && b && c && d)
                    {
                        String qurey = " insert into PENALTY_TABLE values(@UID,@CR,@P_AMOUNT,@DATE,@SIGNAL)";
                        String qurey2 = " insert into HISTORY_TABLE values(@UID,@CR,@P_AMOUNT,@SIGNAL,@SNAME,@DATE,@STATUS)";
                        //String qurey4 = "insert into LISTING_TABLE values(@UID,@DES,@REASON,@ER,@SV,@PAYEMNT)";

                        SqlCommand cmd = new SqlCommand(qurey, con);
                        SqlCommand cmd2 = new SqlCommand(qurey2, con);
                        //SqlCommand cmd4 = new SqlCommand(qurey3, con);
                        cmd.Parameters.AddWithValue("@UID", textBox3.Text);
                        cmd.Parameters.AddWithValue("@CR", textBox1.Text);
                        cmd.Parameters.AddWithValue("@P_AMOUNT", textBox2.Text);
                        cmd.Parameters.AddWithValue("@DATE", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@SIGNAL", textBox4.Text);
                        cmd2.Parameters.AddWithValue("@UID", textBox3.Text);
                        cmd2.Parameters.AddWithValue("@CR", textBox1.Text);
                        cmd2.Parameters.AddWithValue("@P_AMOUNT", textBox2.Text);
                        cmd2.Parameters.AddWithValue("@SIGNAL", textBox4.Text);
                        cmd2.Parameters.AddWithValue("@SNAME", p);
                        cmd2.Parameters.AddWithValue("@DATE", dateTimePicker1.Value);
                        cmd2.Parameters.AddWithValue("@STATUS", status);
                        /*
                        cmd4.Parameters.AddWithValue("@UID", textBox3.Text);
                        cmd4.Parameters.AddWithValue("@DES", DES);
                        cmd4.Parameters.AddWithValue("@REASON", textBox1.Text);
                        cmd4.Parameters.AddWithValue("@SV", SV);
                        cmd4.Parameters.AddWithValue("@ER", DES);
                        cmd4.Parameters.AddWithValue("@PAYMENT", PAYMENT);
                        */
                        int a = cmd.ExecuteNonQuery();
                        int b = cmd2.ExecuteNonQuery();
                        //int d = cmd4.ExecuteNonQuery();
                        if (a > 0 && b > 0)
                        {
                            ResetContro();
                            MessageBox.Show("Fine Allotted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Fine Allotment Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You Have to fill everything.");
            }
        }
    private void textBox3_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider1.SetError(this.textBox3, "Please enter User ID ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox1_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox1, "Please enter Case Reason ");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox2_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider3.SetError(this.textBox2, "Please enter Amount ");
            }
            else
            {
                errorProvider3.Clear();
            }
        }
    }
}