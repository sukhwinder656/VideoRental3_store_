using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental3_store_
{
    public class video : RecordEntry
    {
        public String title { get; set; }
        public String Ranking { get; set; }
        public String Year { get; set; }
        public String Cost { get; set; }
        public String Copies { get; set; }
        public String Plot { get; set; }
        public String Genre { get; set; }
        public video() {
                
        }
        //get the record form the reantla table 
        public DataTable VideoRecord()
        {
            DataTable tbl = new DataTable();
            tbl = SearchRecord("select * from VideoTable");
            return tbl;
        }
    }
}
