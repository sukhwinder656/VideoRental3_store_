using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRental3_store_
{
    public partial class Form1 : Form
    {
        //global variable 
        String InsertOperation = "", DelOperation = "", EditOperation = "";
        RecordEntry Record = new RecordEntry();

        Customer customer = new Customer();
        Rental rental = new Rental();
        video vdeo = new video();
        int rentalFlag = 0;
        //method to empty the fields of the data 
        public void empty() {
            CustomerID.Text = "";
            TxtName_cus.Text = "";
            email_cus.Text = "";
            textBox_mobile.Text = "";
            Address_video.Text = "";


            VideoID.Text = "";
            Txttitle.Text = "";
            rating_txt.Text = "";
            TxtYear.Text = "";
            TxtCopies.Text = "";
            Txtcost.Text = "";
            TxtPlot.Text = "";
            TxtGenre.Text = "";


            rentalFlag = 0;

            Video_show.Checked = false;
            Customer_show.Checked = false;
            Rent_show.Checked = false;
            InsertOperation = "";
            DelOperation = "";
            EditOperation = "";
            rentalFlag = 0;

                

        }

        private void delCustomer_Click(object sender, EventArgs e)
        {
            if (!CustomerID.Text.ToString().Equals(""))
            {
                DelOperation = "delete from CustomerTable where id=" + Convert.ToInt32(CustomerID.Text) + "";
                Record.RecordOperation(DelOperation);
                MessageBox.Show("Member is deleted ");
            }
            else {
                MessageBox.Show("select the Customer to delete him ");
            }
            empty();
        }

        private void updateCustomer_Click(object sender, EventArgs e)
        {
            // update the details of the customer 
            if (!CustomerID.Text.ToString().Equals("") && !TxtName_cus.Text.ToString().Equals("") && !email_cus.Text.ToString().Equals("") && !textBox_mobile.Text.ToString().Equals("") && !Address_video.Text.ToString().Equals(""))
            {
                InsertOperation = "Update CustomerTable Name='" + TxtName_cus.Text + "',Contact='" + textBox_mobile.Text + "',Email'" + email_cus.Text + "',Address='" + Address_video.Text + "' where id=" + Convert.ToInt32(CustomerID.Text) + "";
                Record.RecordOperation(InsertOperation);
                MessageBox.Show("Member record is updated sucessfully ");
            }
            else
            {
                MessageBox.Show("Check the details once ");
            }

            empty();
        }

        private void AddVideo_Click(object sender, EventArgs e)
        {
            //add the details of the video 
            if (!Txttitle.Text.ToString().Equals("") && !rating_txt.Text.ToString().Equals("") && !TxtYear.Text.ToString().Equals("") && !Txtcost.Text.ToString().Equals("") && !TxtCopies.Text.ToString().Equals("") && !TxtPlot.Text.ToString().Equals("") && !TxtGenre.Text.ToString().Equals(""))
            {
                InsertOperation = "insert into VideoTable(Name,Ranking,Year,Cost,Copies,Plot,Genre) values ('" + Txttitle.Text + "','" + rating_txt.Text + "','" + TxtYear.Text + "','" + Txtcost.Text + "','" + TxtCopies.Text + "','" + TxtPlot.Text + "','" + TxtGenre.Text + "')";
                Record.RecordOperation(InsertOperation);
                MessageBox.Show("Video record is stored in the store");
            }
            else {
                MessageBox.Show("Fil all details ");

            }
            empty();
        }

        private void delVideo_Click(object sender, EventArgs e)
            
        {
            //del the selected video from the store 
            if (!VideoID.Text.ToString().Equals(""))
            {
                DelOperation = "delete from VideoTable where id=" + Convert.ToUInt32(VideoID.Text) + "";
                Record.RecordOperation(DelOperation);
                MessageBox.Show("video is removed from the store ");
            }
            else {
                MessageBox.Show("select the video to remove ");
            }
        }

        private void updateVideo_Click(object sender, EventArgs e)
        {
            //add the details of the video 
            if (!VideoID.Text.ToString().Equals("") && !Txttitle.Text.ToString().Equals("") && !rating_txt.Text.ToString().Equals("") && !TxtYear.Text.ToString().Equals("") && !Txtcost.Text.ToString().Equals("") && !TxtCopies.Text.ToString().Equals("") && !TxtPlot.Text.ToString().Equals("") && !TxtGenre.Text.ToString().Equals(""))
            {
                InsertOperation = "Update VideoTable Name='" + Txttitle.Text + "',Ranking'" + rating_txt.Text + "',Year='" + TxtYear.Text + "',Cost='" + Txtcost.Text + "',Copies='" + TxtCopies.Text + "',Plot='" + TxtPlot.Text + "',Genre='" + TxtGenre.Text + "' where  id=" + Convert.ToUInt32(VideoID.Text) + "";
                Record.RecordOperation(InsertOperation);
                MessageBox.Show("Video record is Updated in the store");
            }
            else
            {
                MessageBox.Show("Fil all details or select the video ");

            }
            empty();
        }

        private void rentalIssueVideo_Click(object sender, EventArgs e)
        {
            if (!CustomerID.Text.ToString().Equals("") && !VideoID.Text.ToString().Equals(""))
            {
                if (rental.checkIssue(CustomerID.Text, VideoID.Text) == 2)
                {
                    MessageBox.Show("you can't book more video ");
                }
                else if (rental.checkIssue(CustomerID.Text, VideoID.Text) == 0)
                {

                    InsertOperation = "insert into RentalTable(Customer_ID,Movie_ID,Booking,ReturnDate)values('" + CustomerID.Text + "','" + VideoID.Text + "','" + IssueVideo.Text + "','1')";
                    Record.RecordOperation(InsertOperation);
                    MessageBox.Show("Video is booked ");
                }
                else {
                    MessageBox.Show("All Video castte are booked ");
                }

            }
            else {
                MessageBox.Show("Must select the video and Cusotmer to book video ");
            }
            empty();
        }

        private void rentalVideoDelete_Click(object sender, EventArgs e)
        {
            if (rentalFlag == 0)
            {
                MessageBox.Show("Select the rental details to remove ");
            }
            else {
                DelOperation = "delete from RentalTable where id=" + rentalFlag + "";
                Record.RecordOperation(DelOperation);
                MessageBox.Show("video is deleted ");
            }
            empty();
        }

        private void Video_show_CheckedChanged(object sender, EventArgs e)
        {
            if (Video_show.Checked == true)
            {
                View.DataSource = vdeo.VideoRecord();
            }
            Customer_show.Checked = false;
            Rent_show.Checked = false;

        }

        private void Rent_show_CheckedChanged(object sender, EventArgs e)
        {
            if (Rent_show.Checked == true)
            {
                View.DataSource = rental.rentalRecord();
            }
            Video_show.Checked = false;
            Customer_show.Checked = false;

        }

        private void Customer_show_CheckedChanged(object sender, EventArgs e)
        {
            if (Customer_show.Checked == true)
            {
                View.DataSource = customer.CustomerRecord();
            }
            Video_show.Checked = false;
            Rent_show.Checked = false;
        }

        private void Txtcost_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //dislay the cost of the price of the video after adding the year of the video
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear -Convert.ToInt32(TxtYear.Text.ToString());
                int cost = 0;
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;

                }
                Txtcost.Text = "" + cost;


            }
            catch (Exception ex)
            {

            }
        }

        private void rentalReturnVideo_Click(object sender, EventArgs e)
        {
            if (rentalFlag>0 && !CustomerID.Text.ToString().Equals("") && !VideoID.Text.ToString().Equals(""))
            {
                EditOperation = "Update RentalTable set Customer_ID='" + CustomerID.Text + "',Movie_ID='" + VideoID.Text + "',Booking='" + IssueVideo.Text + "',ReturnDate='"+ReturnVideo.Text+"' where id="+rentalFlag+"";
                Record.RecordOperation(EditOperation);
                rental.getCharges(Convert.ToInt32(VideoID.Text),rentalFlag);
            }
            empty();

        }

        private void View_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Video_show.Checked==true) {
                VideoID.Text = View.CurrentRow.Cells[0].Value.ToString();
                Txttitle.Text = View.CurrentRow.Cells[1].Value.ToString();
                rating_txt.Text = View.CurrentRow.Cells[2].Value.ToString();
                TxtYear.Text = View.CurrentRow.Cells[3].Value.ToString();
                Txtcost.Text = View.CurrentRow.Cells[4].Value.ToString();
                TxtCopies.Text = View.CurrentRow.Cells[5].Value.ToString();
                TxtPlot.Text = View.CurrentRow.Cells[6].Value.ToString();
                TxtGenre.Text = View.CurrentRow.Cells[7].Value.ToString();
            }
            if (Customer_show.Checked==true) {

                CustomerID.Text = View.CurrentRow.Cells[0].Value.ToString();
                TxtName_cus.Text = View.CurrentRow.Cells[1].Value.ToString();
                textBox_mobile.Text = View.CurrentRow.Cells[2].Value.ToString();
               email_cus.Text = View.CurrentRow.Cells[3].Value.ToString();
                Address_video.Text = View.CurrentRow.Cells[4].Value.ToString();
            }
            if (Rent_show.Checked==true) {
                //
                rentalFlag = Convert.ToInt32(View.CurrentRow.Cells[0].Value.ToString());
                CustomerID.Text= View.CurrentRow.Cells[1].Value.ToString();
                VideoID.Text=View.CurrentRow.Cells[2].Value.ToString();
                IssueVideo.Text=View.CurrentRow.Cells[3].Value.ToString();


            }
            Rent_show.Checked = false;
            Customer_show.Checked = false;
            Video_show.Checked = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void best_custo_Click(object sender, EventArgs e)
        {
            DataTable tblData = new DataTable();
            tblData =Record.SearchRecord("select * from CustomerTable");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = Record.SearchRecord("select * from RentalTable where Customer_ID=" + Convert.ToInt32(tblData.Rows[x]["id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Most Booked Movie Title is :" + Title);

        }

        private void best_video_Click(object sender, EventArgs e)
        {
            DataTable tblData = new DataTable();
            tblData = Record.SearchRecord("select * from VideoTable");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = Record.SearchRecord("select * from RentalTable where Movie_ID=" + Convert.ToInt32(tblData.Rows[x]["id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Best Movies is   :" + Title);



        }

        public Form1()
        {
            InitializeComponent();
            Txtcost.Enabled = false;
        }

        private void addCustomer_Click(object sender, EventArgs e)
        {
            if (!TxtName_cus.Text.ToString().Equals("") && !email_cus.Text.ToString().Equals("") && !textBox_mobile.Text.ToString().Equals("") && !Address_video.Text.ToString().Equals("")) {
                InsertOperation = "insert into CustomerTable(Name,Contact,Email,Address) values ('"+TxtName_cus.Text+"','"+textBox_mobile.Text+"','"+email_cus.Text+"','"+Address_video.Text+"')";
                Record.RecordOperation(InsertOperation);
                MessageBox.Show("Member is registered sucessfully ");
            }
            else {
                MessageBox.Show("Check the details once ");
            }

            empty();
        }
    }
}
