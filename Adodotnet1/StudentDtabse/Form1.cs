using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace StudentDtabse
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string conctionstring = "User Id=testuser;password=testuser;database=TESTDB;Data Source=bg-in-dspdb1";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //save button
            con = new SqlConnection(conctionstring);
            con.Open();
            string cmmd = String.Format("insert into student values '{0}','{1}','{2}''{3}' ", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            cmd = new SqlCommand(cmmd, con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Not saved");
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // clear
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            con = new SqlConnection(conctionstring);
            con.Open();
            string cmmd = String.Format("Delete from student where stdrn= {0}", textBox1.Text);
            cmd = new SqlCommand(cmmd, con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Not Deleted");
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(conctionstring);
            string cmmd = String.Format("Select * from student where stdrn = {0} ", textBox1.Text);
            con.Open();

            cmd = new SqlCommand(cmmd,con);

            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                }
                else
                {
                    MessageBox.Show("No records");
                }
            }
            catch (Exception ex)
            { Console.WriteLine("No recoed"); }
            finally
            { con.Close(); }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(conctionstring);
            con.Open();
            String cmmd = String.Format("update from student where stdrn = {0} ", textBox1.Text);
            cmd = new SqlCommand(cmmd, con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated");

            }
            catch (Exception)
            {
                MessageBox.Show("Not Updated");
            }
            finally
            {
                con.Close();
            }
        }




    }
}
