
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Adodotnet1
{
    class Joining_Data_table
    {

        public static void Alloperations()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("CustID", typeof(int));
            dt1.Columns.Add("ColX", typeof(int));
            dt1.Columns.Add("ColY", typeof(int));

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("CustID", typeof(int));
            dt2.Columns.Add("ColZ", typeof(int));

            for (int i = 0; i < 5; i++)
            {
                DataRow row1 = dt1.NewRow();
                row1["CustID"] = i;
                row1["ColX"] = i + 1;
                row1["ColY"] = i + 2;
                dt1.Rows.Add(row1);

                row1 = dt2.NewRow();
                row1["CustID"] = i;
                row1["ColZ"] = i + 3;
                dt2.Rows.Add(row1);
            }

            var result = from tbl1 in dt1.AsEnumerable()
                         join
                             tbl2 in dt2.AsEnumerable() on (int)tbl1["CustID"] equals (int)tbl2["CustID"]
                         select new
                         {
                             CustID = (int)tbl1["CustID"],
                             ColX = (int)tbl1["ColX"],
                             ColY = (int)tbl1["ColY"],
                             ColZ = (int)tbl2["ColZ"]
                         };

            foreach (var item in result)
            {
                Console.WriteLine("ID = {0} , Col1  = {1} , Col2 ={2} , Col3 = {3} ",item.CustID,item.ColX,item.ColY,item.ColZ);
            }
        }
    }
}
