using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental3_store_
{
    public class RecordEntry
    {
        //Conn Instance Object of SQl Connection Class
        SqlConnection conn;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=RentalStore;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand cmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;

        //this method is used to execute the sql query like insert delete update in the database tables
        public void RecordOperation(String query)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable SearchRecord(String qry)
        {
            DataTable tbl = new DataTable();

            conn = new SqlConnection(conStr);

            conn.Open();

            cmd = new SqlCommand(qry, conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();

            return tbl;
        }


    }
}
