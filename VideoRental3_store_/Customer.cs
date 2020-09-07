using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental3_store_
{
   public class Customer:RecordEntry
    {
        public String Name { get; set; }
        public String Contact { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }

        //constructor 
        public Customer() {


        }

        //get the record form the reantla table 
        public DataTable CustomerRecord()
        {
            DataTable tbl = new DataTable();
            tbl = SearchRecord("select * from CustomerTable");
            return tbl;
        }
    }
}
