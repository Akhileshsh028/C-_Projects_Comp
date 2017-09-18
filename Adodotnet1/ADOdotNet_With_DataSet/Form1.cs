using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.Design;
using Microsoft.VisualBasic;
namespace ADOdotNet_With_DataSet
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cmdb;
        DataSet ds;
        int rno = 0;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("User ID=testuser;Password=testuser;DataBase=TESTDB;Data Source=bg-in-dspdb1");
            da = new SqlDataAdapter("Select Eno,Ename,Job,Salary from Employee1 Order by Eno", con);
            ds = new DataSet();
            da.Fill(ds, "Employee1");
            //ShowData();

        }

        private void ShowData()
        {
            textBox1.Text = ds.Tables[0].Rows[rno][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[rno][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[rno][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[rno][3].ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rno = 0;
            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // previous Button 
            if (rno > 0)
            {
                rno -= 1;
                if (ds.Tables[0].Rows[rno].RowState == DataRowState.Deleted)
                    MessageBox.Show("Deleted Row cannot be accessed");
                ShowData();
            }
            else
            {
                MessageBox.Show("This is the firest record");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //next record
            if (rno < ds.Tables[0].Rows.Count - 1)
            {
                rno += 1;
                if (ds.Tables[0].Rows[rno].RowState == DataRowState.Deleted)
                {
                    MessageBox.Show("Deleted Row data cannot be accessed");
                    return;
                    ShowData();

                }
                else
                    MessageBox.Show("Last recoed of the table");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            rno = ds.Tables[0].Rows.Count - 1;
            ShowData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //new button
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            int inex = ds.Tables[0].Rows.Count - 1;
            int eno = Convert.ToInt32(ds.Tables[0].Rows[inex][0]) + 1;
            textBox1.Text = eno.ToString();
            textBox2.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // insert button
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text;

            ds.Tables[0].Rows.Add(dr);
            rno = ds.Tables[0].Rows.Count - 1;
            MessageBox.Show("DataRow Added to datatable of dataset");
            //da.Update(ds, "Employee1");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // update command
            ds.Tables[0].Rows[rno][1] = textBox2.Text;
            ds.Tables[0].Rows[rno][2] = textBox3.Text;
            ds.Tables[0].Rows[rno][3] = textBox4.Text;
            MessageBox.Show("Items updated successfully");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows[rno].Delete();
            MessageBox.Show("Row deleted Sucessfully");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // db update
            cmdb = new SqlCommandBuilder(da);
            da.Update(ds, "Employee1");
            MessageBox.Show("Data Saved to Db server");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // search
            DataRow dr = null;
                string value =textBox1.Text.ToString();
            if (value.Trim().Length > 0)
                dr = ds.Tables[0].Rows.Find(rno);
                if(dr!=null)
                {
                    textBox2.Text= dr[1].ToString();
                    textBox3.Text= dr[2].ToString();
                    textBox4.Text= dr[3].ToString();
                }
            else
                    MessageBox.Show("Employee does no");
        }




    }
}
