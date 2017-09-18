using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataTable_Connecting_WithDataBase
{
    class Bussiness_Class
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;

        public void AllOperations()
        {
            con = new SqlConnection("User Id=testuser;Password=testuser;DataBase=TESTDB;Data Source=bg-in-dspdb1");
            con.Open();
            cmd = new SqlCommand("Select * from student", con);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();

            // showing the column

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine();
                for (int x = 0; x < dt.Columns.Count; x++)
                {
                    Console.Write(row[x].ToString() + " ");
                }


            }

            // Update the column

            string selectStatement = "SELECT * FROM Employee1";
            DataTable dt1 = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            conn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter();
            sqlDa.SelectCommand = new SqlCommand(selectStatement, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlDa);
            sqlDa.Fill(dt1);


            foreach (DataRow row in dt1.Rows)             // very very imp table must be heaving the primary key if wanted to use datatable opertion otherwise it will through an error. as if you wanted to try then see the employee table. 
            {
                if (dt1.Rows[0]["Ename"] != "Bhalla")
                {
                    dt1.Rows[0]["Eno"] = "1";
                    dt1.Rows[0]["Ename"] = "Bhalla";
                    dt1.Rows[0]["Job"] = "Java";
                    dt1.Rows[0]["Salary"] = "547896";
                }
            }

            dt1.AcceptChanges();
            sqlDa.UpdateCommand = cb.GetUpdateCommand();
            sqlDa.Update(dt1);
            Console.WriteLine();
            foreach (DataRow row in dt1.Rows)
            {
                Console.WriteLine(string.Join("\t",row.ItemArray));
            }
            con.Close();
            

        }

    }
}
