using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Adodotnet1
{
    class Program
    {

        
        static void Main(string[] args)
        {

            //SqlConnection con;
            //SqlCommand cmd;

            //con = new SqlConnection("User Id=testuser;password=testuser;DataBase=TESTDB;Data Source=bg-in-dspdb1");
            //cmd = new SqlCommand("Select * from Employee", con);
            //con.Open();
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());



            //DataTable dt = GetTable();

          
            //// datatable Read
            //foreach (DataRow row in dt.Rows)
            //{
            //    Console.WriteLine();
            //    for (int x = 0; x < dt.Columns.Count; x++)
            //    {
            //        Console.Write(row[x].ToString() + " ");
            //    }
            //}

            //Console.ReadLine();

            //using (DataTable table = new DataTable())
            //{
            //    table.Columns.Add("Name", typeof(string));
            //    table.Columns.Add(("date"), typeof(DateTime));

            //    table.Rows.Add("Akhilesh", DateTime.Now);
            //    table.Rows.Add("Dog", DateTime.Today);
                    
            //    foreach (DataRow row in table.Rows)
            //    {
            //        Console.WriteLine();
                    
            //        if (row["Name"].ToString().ToUpper().Equals("DOG"))
            //        {
            //            //row["Name"] = "Cortera";       // modifying
            //            //row["date"] = DateTime.UtcNow;
            //           // row.Delete();    //deleting 
            //        }
                    
            //        for (int i = 0; i < table.Columns.Count; i++)
            //        {
            //            Console.WriteLine(row[i].ToString()+" ");
            //        }
            //    }
            //    table.AcceptChanges();
            //}
            //Console.WriteLine(dt.Rows[1].ToString()+" ");

            Joining_Data_table.Alloperations();

            Console.ReadLine();
           
        }

          static DataTable GetTable()
        {    
              // datatable insertation
            DataTable table = new DataTable();
            table.Columns.Add("Eno", typeof(int));
            table.Columns.Add("Ename", typeof(string));
            table.Columns.Add("Job", typeof(string));

            table.Rows.Add(1, "Akhielsh", ".NET");
            table.Rows.Add(2, "Sudeep", ".NET");
            table.Rows.Add(3, "shetti", ".net");
            table.Rows.Add(1, "Akhielsh", ".NET");
            return table;
        }
    }
}
