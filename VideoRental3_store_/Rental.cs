using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRental3_store_
{
   public class Rental: RecordEntry
    {
        public String CustomerID { get; set; }
        public String MovieID { get; set; }
        public String BookingDate { get; set; }
        public String ReturnDate { get; set; }

        public Rental() {

        }
        //get the record form the reantla table 
        public DataTable rentalRecord() {
            DataTable tbl = new DataTable();
            tbl=SearchRecord("select * from RentalTable");
            return tbl;
        }
        public int checkIssue(String Customer_ID,String Movie_ID) {

            MovieID = Movie_ID;
            int copies = 0;
            DataTable tbl = new DataTable();
            tbl = SearchRecord("select * from RentalTable where Customer_ID="+Customer_ID+" and ReturnDate='1'");
            if (tbl.Rows.Count < 2)
            {
                tbl = new DataTable();
                tbl =SearchRecord("select * from VideoTable where id="+Convert.ToInt32(MovieID)+"");
                copies =Convert.ToInt32(tbl.Rows[0]["Copies"].ToString());
                tbl = new DataTable();
                tbl = SearchRecord("select * from RentalTable where Movie_ID='" + MovieID + "' and ReturnDate='1'");
                if (tbl.Rows.Count < copies)
                {
                    return 0;
                }
                else {
                    return 1;
                }
                
            }
            else {
                return 2;
            }
        }

        //get he charges 
        public void getCharges(int Video_ID, int Rental_ID) {

            //get the rentanl cst 
            DataTable tbl = new DataTable();
            int cost = 0;
            tbl = SearchRecord("select * from VideoTable where id="+Video_ID+"");
            cost=Convert.ToInt32(tbl.Rows[0]["Cost"].ToString());

            //get the days difference 

            DateTime new_date = DateTime.Now;

            tbl = new DataTable();
            tbl = SearchRecord("select * from RentalTable where id="+Rental_ID+"");
            BookingDate = tbl.Rows[0]["Booking"].ToString();
            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(BookingDate);


            //get the difference in the days fromat
            String Daysdiff = (new_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));

            


            int Charges = Convert.ToInt32(DaysInterval) * cost;
            MessageBox.Show("Video is returned and the Charges are $" + Charges);


        }


    }
}
