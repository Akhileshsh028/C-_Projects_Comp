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

namespace ADOExample
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string stringstr;
        public Form1()
        {
            
            InitializeComponent();
            con = new SqlConnection("User Id=testuser ; password=testuser ; Database=TESTDB ; Data source = bg-in-dspdb1");
            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            LoadData();
      

        }

        private void LoadData()
        {
            cmd.CommandText = String.Format("Select Eno,Ename,Job,Salary from Employee order by Eno");
            dr = cmd.ExecuteReader();
            ShowData();
        }

        private void ShowData()
        {
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
            }
            else
            {
                MessageBox.Show("No data Found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dr.IsClosed == true)
            {
                MessageBox.Show("next is not possible");
            }
            else
            {

                ShowData();   // next button
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)    //close Button
                con.Close();
          
           this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // new button
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            dr.Close();
            cmd.CommandText = "Select ISNULL(Max(Eno),1000)+1 from Employee";
            textBox1.Text = cmd.ExecuteScalar().ToString();
            button3.Enabled = true;
            textBox2.Focus();
        }

        private void ExecuteDML()
        {
            DialogResult d = MessageBox.Show("Are you sure want to Execute the command" + stringstr,
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                cmd.CommandText = stringstr;
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Statement Executed Successfully");
                }
                else
                    MessageBox.Show("Statement Not Executed");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Insert button
            stringstr = String.Format("Insert into Employee (Eno,Ename,Job,Salary) values ('{0}','{1}','{2}','{3}')",
                        textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            ExecuteDML();
            button3.Enabled = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            // update button

            stringstr = String.Format("update employee set Ename= '{0}',Job ='{1}',Salary='{2}' where Eno ='{3}' ", textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text);
            dr.Close();
            ExecuteDML();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            stringstr = String.Format("Delete from Employee where Eno = '{0}' ",textBox1.Text);
            dr.Close();
            ExecuteDML();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
