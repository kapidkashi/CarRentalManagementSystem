using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Pragados_Project
{
    public partial class frmRental : Form
    {
        public string getUser { get; set; }
        public string getUserType { get; set; }
        
        public frmRental()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBCar;
        private DataSet DSCar = new DataSet();
        private DataTable DTCar = new DataTable();

        private SQLiteDataAdapter DBCustomer;
        private DataSet DSCustomer = new DataSet();
        private DataTable DTCustomer = new DataTable();

        private SQLiteDataAdapter DBRent;
        private DataSet DSRent = new DataSet();
        private DataTable DTRent = new DataTable();

        


        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
                LoadData();
            }
        }

        private void frmRental_Load(object sender, EventArgs e)
        {

            lblUserType.Text = getUserType;
            lblUser.Text = getUser;
            LoadData();
            RentalID();
            ReturnID();
            Bind();
            TransactID();
            this.lblDateNow.Text = DateTime.Now.ToString();
            if (txtRentalPrice.Text == "")
            {
                cmbDriver.Enabled = false;
            }
            else
            {
                cmbDriver.Enabled = true;
            }


        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source = CarRentDB.db ; Version = 3; New = False; Compress = True");

        }
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();

            string CommandTextCar = "Select * from Cars where Availability='Yes'";
            DBCar = new SQLiteDataAdapter(CommandTextCar, sql_con);
            DSCar.Reset();
            DBCar.Fill(DSCar);
            DTCar = DSCar.Tables[0];
            dgvCar.DataSource = DTCar;

            string CommandTextCustomer = "Select * from Customer";
            DBCustomer = new SQLiteDataAdapter(CommandTextCustomer, sql_con);
            DSCustomer.Reset();
            DBCustomer.Fill(DSCustomer);
            DTCustomer = DSCustomer.Tables[0];
            frmCustomer fc = new frmCustomer();
            fc.dgvCustomer.DataSource = DTCustomer;

            cmbCustomerID.DataSource = DTCustomer;
            cmbCustomerID.DisplayMember = "CustomerID";
            cmbCustomerID.ValueMember = "CustomerID";

            string CommandTextCarRental = "Select * from CarRental";
            DBRent = new SQLiteDataAdapter(CommandTextCarRental, sql_con);
            DSRent.Reset();
            DBRent.Fill(DSRent);
            DTRent = DSRent.Tables[0];
            
            dgvCarRented.DataSource = DTRent;

          
            sql_con.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                sql_cmd = new SQLiteCommand("select * from Cars where CarName Like  '" + txtSearch.Text + "%' or CarBrand Like'%" + txtSearch.Text + "%' or CarModel Like '" + txtSearch.Text + "%'", sql_con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvCar.DataSource = ds.Tables[0];



            }
            else if (txtSearch.Text == "Search")
            {
                LoadData();
            }
            else
            {
                LoadData();
            }
        }


      

        
        private void RentalID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBID = new SQLiteDataAdapter("select CarRentalID from [CarRentalID] order by CarRentalID desc", sql_con);
                DataSet DSID = new DataSet();
                DBID.Fill(DSID);
                if (DSID.Tables[0].Rows.Count > 0)
                {
                    txtAutoRentalID.Text = DSID.Tables[0].Rows[0]["CarRentalID"].ToString();
                }
                else
                {
                    txtAutoRentalID.Text = "RNTL0000";
                }
                if (!string.IsNullOrEmpty(txtAutoRentalID.Text))
                {
                    txtAutoRentalID.SelectionStart = 4;
                    txtAutoRentalID.SelectionLength = 5;
                    lblAutoRentalID.Text = txtAutoRentalID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoRentalID.Text))
                {
                    int ID = int.Parse(lblAutoRentalID.Text.ToString()) + 1;
                    txtRentalID.Text = ID.ToString("RNTL0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }

        private SQLiteDataAdapter DBBind;

        private DataTable DTBind;
        private SQLiteCommandBuilder cmd = new SQLiteCommandBuilder();
        private void Bind()
        {

            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            sql_cmd.CommandText = "select * from Customer where CustomerID=@CustomerID";
            sql_cmd.Parameters.AddWithValue("@CustomerID", cmbCustomerID.SelectedValue);
            DTBind = new DataTable();
            DBBind = new SQLiteDataAdapter();
            cmd.DataAdapter = DBBind;

            DBBind.SelectCommand = sql_cmd;
            DBBind.Fill(DTBind);
            DTCustomer.AcceptChanges();
            txtCustomerName.DataBindings.Clear();

            txtCustomerName.DataBindings.Add("Text", DTCustomer, "CustomerName", false, DataSourceUpdateMode.OnPropertyChanged);


            sql_con.Close();

        }
        private void ReturnID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBID = new SQLiteDataAdapter("select CarReturnID from [CarReturnID] order by CarReturnID desc", sql_con);
                DataSet DSID = new DataSet();
                DBID.Fill(DSID);
                if (DSID.Tables[0].Rows.Count > 0)
                {
                    txtAutoReturnID.Text = DSID.Tables[0].Rows[0]["CarReturnID"].ToString();
                }
                else
                {
                    txtAutoReturnID.Text = "RTRN0000";
                }
                if (!string.IsNullOrEmpty(txtAutoReturnID.Text))
                {
                    txtAutoReturnID.SelectionStart = 4;
                    txtAutoReturnID.SelectionLength = 5;
                    lblAutoReturnID.Text = txtAutoReturnID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoReturnID.Text))
                {
                    int ID = int.Parse(lblAutoReturnID.Text.ToString()) + 1;
                    txtReturnID.Text = ID.ToString("RTRN0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
        private void TransactID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBID = new SQLiteDataAdapter("select TransactID from [Transaction] order by TransactID desc", sql_con);
                DataSet DSID = new DataSet();
                DBID.Fill(DSID);
                if (DSID.Tables[0].Rows.Count > 0)
                {
                    txtAutoTransactID.Text = DSID.Tables[0].Rows[0]["TransactID"].ToString();
                }
                else
                {
                    txtAutoTransactID.Text = "TRNSCT0000";
                }
                if (!string.IsNullOrEmpty(txtAutoTransactID.Text))
                {
                    txtAutoTransactID.SelectionStart = 6;
                    txtAutoTransactID.SelectionLength = 7;
                    lblAutoTransactID.Text = txtAutoTransactID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoTransactID.Text))
                {
                    int ID = int.Parse(lblAutoTransactID.Text.ToString()) + 1;
                    txtTransactID.Text = ID.ToString("TRNSCT0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
        //Car Rental
        private void dgvCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvCar.Rows[e.RowIndex];
            txtCarID.Text=dr.Cells[0].Value.ToString();
            txtCarName.Text = dr.Cells[1].Value.ToString();
            txtCarBrand.Text = dr.Cells[2].Value.ToString();
            txtCarModel.Text = dr.Cells[3].Value.ToString();
            txtRentalPrice.Text = dr.Cells[4].Value.ToString();
            txtAvail.Text = dr.Cells[5].Value.ToString();
            txtPenalyPerDay.Text = dr.Cells[6].Value.ToString();
            byte[] imgData = (byte[])dr.Cells[7].Value;
            MemoryStream ms = new MemoryStream(imgData);
            pbImage.Image = Image.FromStream(ms);

            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }



        }
        //update car rent availability
        private void RentAvailability()
        {
            string txtQueryAvail = "Update Cars set Availability='" + "No" + "' where CarID ='" + txtCarID.Text + "'";
            ExecuteQuery(txtQueryAvail);

        }
        //insert transaction rental car to dataabse
        private void RentTransaction()
        {
            try
            {
        byte[] imageBT = (byte[])dgvCar.Rows[0].Cells[7].Value;
            MemoryStream ms = new MemoryStream(imageBT);
            pbImage.Image = Image.FromStream(ms);

                   
            sql_con.Open();

                string txtQuery = "Insert into [Transaction] (TransactID,RentalReturnID,CustomerID,CustomerName,CarID,CarName,CarBrand,CarModel,Driver,Total,Image) values " +
                    "('" + txtTransactID.Text + "','" + txtRentalID.Text +"','"+cmbCustomerID.Text+"','"+txtCustomerName.Text +"','"+txtCarID.Text + "'," +
                    "'" + txtCarName.Text + "','" + txtCarBrand.Text + "','" + txtCarModel.Text + "','" + cmbDriver.Text + "','" + txtRentalTotal.Text + "',@imageBT)";
            sql_cmd = new SQLiteCommand(txtQuery, sql_con);
            sql_cmd.Parameters.Add(new SQLiteParameter("@imageBT", imageBT));
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();

           
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
            

         

        }
        //Insert rental car to database
        private void btnRent_Click(object sender, EventArgs e)
        {
            try
            {

            if (txtRentalDays.Text == "")
            {
                MessageBox.Show("Please select Return Date");
            }
            else
            {
                RentAvailability();
                RentTransaction();

                byte[] imageBT = (byte[])dgvCar.Rows[0].Cells[7].Value;
                MemoryStream ms = new MemoryStream(imageBT);
                pbImage.Image = Image.FromStream(ms);


                sql_con.Open();

                string txtQuery = "Insert into CarRental(CarRentalID,CustomerID,CustomerName,CarID,CarName,CarBrand,CarModel,PenaltyPerDay,RentDate,ReturnDate,Price,Driver,Total,Image) " +
                   "values ('" + txtRentalID.Text + "','" + cmbCustomerID.Text + "','" + txtCustomerName.Text + "','" + txtCarID.Text + "','" + txtCarName.Text + "','" + txtCarBrand.Text + "','" + txtCarModel.Text + "'," +
                   "'" + txtPenalyPerDay.Text + "','" + dtpRental.Text + "','" + dtpReturn.Text + "','" + txtRentalPrice.Text + "','" + cmbDriver.Text + "','" + txtRentalTotal.Text + "',@imageBT)";
              

                sql_cmd = new SQLiteCommand(txtQuery, sql_con);
          
                sql_cmd.Parameters.Add(new SQLiteParameter("@imageBT", imageBT));
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                string txtQueryRentalID = "Insert into CarRentalID(CarRentalID) values ('" + txtRentalID.Text + "')";
                ExecuteQuery(txtQueryRentalID);

                LoadData();
                ClearRent();
                RentalID();
                TransactID();       
                MessageBox.Show("Car has been Rented Succesfully!");
              

            }

      
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
          

        }
        private void ClearRent()
        {
            cmbCustomerID.Text = "";
            txtCustomerName.Clear();
            txtCarID.Clear();
            txtCarName.Clear();
            txtCarBrand.Clear();
            txtCarModel.Clear();
            txtPenalyPerDay.Clear();
            txtAvail.Clear();
            pbImage.Image = null;
            dtpRental.ResetText();
            dtpReturn.ResetText();
            txtRentalPrice.Clear();
            txtRentalTotal.Clear();
              
            
        }

        private void dtpReturn_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                 string date1 = dtpRental.Value.ToString();
                DateTime dt1 = Convert.ToDateTime(date1);

                string date2 = dtpReturn.Value.ToString();
                DateTime dt2 = Convert.ToDateTime(date2);

                int days;
                days = (dt2 - dt1).Days;
                txtRentalDays.Text = String.Format("{0:0}", days);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

          
           
            
        }

      

        private void txtRentalDays_TextChanged(object sender, EventArgs e)
        {

            try
            {

                 int PricePerDay = Convert.ToInt32(txtRentalPrice.Text);
                int Days = Convert.ToInt32(txtRentalDays.Text);
                int Total;

                Total = PricePerDay * Days;
                txtRentalTotal.Text = Total.ToString();


                if (cmbDriver.Text == "Yes")
                {


                    Total = Total + 500;
                    txtRentalTotal.Text = Total.ToString();



                }
                if (txtRentalDays.Text == "0")
                {


                    Total = Total * 0;
                    txtRentalTotal.Text = Total.ToString();



                }

            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

          
            

        }
        
        private void dgvCar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                 DataGridViewRow dr = dgvCar.Rows[e.RowIndex];
            txtCarID.Text = dr.Cells[0].Value.ToString();
            txtCarName.Text = dr.Cells[1].Value.ToString();
            txtCarBrand.Text = dr.Cells[2].Value.ToString();
            txtCarModel.Text = dr.Cells[3].Value.ToString();
            txtRentalPrice.Text = dr.Cells[4].Value.ToString();
            txtAvail.Text = dr.Cells[5].Value.ToString();
            txtPenalyPerDay.Text = dr.Cells[6].Value.ToString();
            byte[] imgData = (byte[])dr.Cells[7].Value;
            MemoryStream ms = new MemoryStream(imgData);
            pbImage.Image = Image.FromStream(ms);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
          

          
            
        }

        private void cmbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRentalTotal.Text != "")
                {
                    int Total = Convert.ToInt32(txtRentalTotal.Text);


                    if (cmbDriver.Text == "Yes")
                    {


                        Total = Total + 500;
                        txtRentalTotal.Text = Total.ToString();



                    }

                    if (cmbDriver.Text == "None")
                    {


                        Total = Total - 500;
                        txtRentalTotal.Text = Total.ToString();



                    }


                }

            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }


        }


        private void dtpRental_ValueChanged(object sender, EventArgs e)
        {
            try
            {

              string date1 = dtpRental.Value.ToString();
                DateTime dt1 = Convert.ToDateTime(date1);

                string date2 = dtpReturn.Value.ToString();
                DateTime dt2 = Convert.ToDateTime(date2);

                int days;
                days = (dt2 - dt1).Days;
                txtRentalDays.Text = String.Format("{0:0}", days);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

           
            
        }

   

        private void cmbDriver_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {  
                if (txtRentalTotal.Text != "")
            {
                int Total = Convert.ToInt32(txtRentalTotal.Text);

             
                    if (cmbDriver.Text == "Yes")
                    {


                        Total = Total + 500;
                        txtRentalTotal.Text = Total.ToString();



                    }
             
                    if (cmbDriver.Text == "None")
                    {


                        Total = Total - 500;
                        txtRentalTotal.Text = Total.ToString();



                    }
              
              
            }

            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

         
        }

        //update car rental
        private void UpdateRentTransaction()
        {
            try
            {
                byte[] imageBT = (byte[])dgvCar.Rows[0].Cells[7].Value;
                MemoryStream ms = new MemoryStream(imageBT);
                pbImage.Image = Image.FromStream(ms);


                sql_con.Open();

                string txtQuery = "Update Trancsaction set ,CustomerID='" + cmbCustomerID.Text + "',CustomerName='" + txtCustomerName.Text + "',CarID='" + txtCarID.Text + "'," +
                    "CarName='" + txtCarName.Text + "',CarBrand='" + txtCarBrand.Text + "',CarModel='" + txtCarModel.Text + "',Total='" + txtRentalTotal.Text + "',Image=@imageBT where Rental/ReturnID='" + txtRentalID.Text + "' ";
                 
                sql_cmd = new SQLiteCommand(txtQuery, sql_con);
                sql_cmd.Parameters.Add(new SQLiteParameter("@imageBt", imageBT));
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();


            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
     

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearRent();
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to go Back?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                frmDashboard fd = new frmDashboard();
                fd.getUser = lblUser.Text;
                fd.getUserType = lblUserType.Text;
                fd.Show();
                this.Hide();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to Exit?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                frmDashboard fd = new frmDashboard();
                fd.getUser = lblUser.Text;
                fd.getUserType = lblUserType.Text;
                fd.Show();
                this.Hide();

            }

        }

        private void txtAvail_TextChanged(object sender, EventArgs e)
        {
            if(txtAvail.Text == "No")
            {
                btnRent.Enabled = false;
                
            }
            else
            {
                btnRent.Enabled = true;
               
            }
        }

       


        //Car Return
        private void dgvCarRented_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCarRented_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

              DataGridViewRow dr = dgvCarRented.Rows[e.RowIndex];
            txtReturnRentalID.Text = dr.Cells[0].Value.ToString();
            txtReturnCustomerID.Text = dr.Cells[1].Value.ToString();
            txtReturnCustomerName.Text = dr.Cells[2].Value.ToString();
            txtReturnCarID.Text = dr.Cells[3].Value.ToString();
            txtReturnCarName.Text = dr.Cells[4].Value.ToString();
            txtReturnCarBrand.Text = dr.Cells[5].Value.ToString();
            txtReturnCarModel.Text = dr.Cells[6].Value.ToString();
            txtPenaltyPerDay1.Text = dr.Cells[7].Value.ToString();
            
            dtpReturnDate.Text = dr.Cells[9].Value.ToString();
            txtReturnDriver.Text = dr.Cells[11].Value.ToString();
            txtReturnTotal.Text = dr.Cells[12].Value.ToString();
            byte[] imgData = (byte[])dr.Cells[13].Value;
            MemoryStream ms = new MemoryStream(imgData);
            pbImage1.Image = Image.FromStream(ms);

            
            DateTime d1 = dtpReturnDate.Value.Date;
            DateTime d2 = DateTime.Now;

            TimeSpan t = d2 - d1;
            int Penalty = Convert.ToInt32(txtPenaltyPerDay1.Text);
            int days = Convert.ToInt32(t.TotalDays);
                if (days <= 0)
            {
                txtDelay.Text = "No Delay";
                txtPenalty.Text = "No Penalty";

            }
            else
            {
                txtDelay.Text = ""+days+" day/s";
                txtPenalty.Text = "" + days * Penalty;


            }

            

            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
           
        }

        private void lblDateNow_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearReturn()
        {
            txtReturnRentalID.Clear();
            txtReturnCustomerID.Clear();
            txtReturnCarID.Clear();
            txtReturnCustomerName.Clear();
            txtReturnCarName.Clear();
            txtReturnCarBrand.Clear();
            txtReturnCarModel.Clear();
            dtpReturnDate.ResetText();
            txtDelay.Clear();
            txtPenalty.Clear();
            txtPenaltyPerDay1.Clear();
            pbImage1.Image = null;



        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblDateNow.Text = DateTime.Now.ToString();
        }

        private void ReturnAvailability()
        {
            try
            {

                  string txtQueryAvail = "Update Cars set Availability='" + "Yes" + "' where CarID ='" + txtReturnCarID.Text + "'";
            ExecuteQuery(txtQueryAvail);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        
        }
        private void ReturnTransaction()
        {
            try
            {
            byte[] imageBT = (byte[])dgvCarRented.Rows[0].Cells[13].Value;
            MemoryStream ms = new MemoryStream(imageBT);
            pbImage1.Image = Image.FromStream(ms);


            sql_con.Open();

            string txtQuery = "Insert into [Transaction] (TransactID,RentalReturnID,CustomerID,CustomerName,CarID,CarName,CarBrand,CarModel,Driver,Total,Delay,Penalty,Image) values " +
                "('" + txtTransactID.Text + "','" + txtReturnID.Text + "','" + txtReturnCustomerID.Text + "','" + txtReturnCustomerName.Text + "','" + txtReturnCarID.Text + "'," +
                "'" + txtReturnCarName.Text + "','" + txtReturnCarBrand.Text + "','" + txtReturnCarModel.Text + "','" + txtReturnDriver.Text + "','" + txtReturnTotal.Text + "','" + txtDelay.Text + "','" + txtPenalty.Text + "',@imageBT)";
            sql_cmd = new SQLiteCommand(txtQuery, sql_con);
            sql_cmd.Parameters.Add(new SQLiteParameter("@imageBT", imageBT));
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
           





        }

        //Return Car
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {

            ReturnAvailability();
            ReturnTransaction();
            string txtQuery = "Delete from CarRental where CarRentalID ='" + txtReturnRentalID.Text + "'";
            ExecuteQuery(txtQuery);
            string txtQueryReturnID = "Insert into CarReturnID(CarReturnID) values ('" + txtReturnID.Text + "')";
            ExecuteQuery(txtQueryReturnID);
            MessageBox.Show("Car has been Return Succesfully!");
            LoadData();
            ClearReturn();
            ReturnID();
            TransactID();

            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearReturn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to go Back?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                frmDashboard fd = new frmDashboard();
                fd.Show();
                this.Hide();
            }
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch1.Text != "")
            {
                sql_cmd = new SQLiteCommand("select * from CarRental where CarRentalID Like  '" + txtSearch1.Text + "%' or CustomerID Like  '" + txtSearch1.Text + "%' or CustomerName Like  '" + txtSearch1.Text + "%' or CarID Like  '" + txtSearch1.Text + "%' or Driver Like  '" + txtSearch1.Text + "%' or CarName Like  '" + txtSearch1.Text + "%' or CarBrand Like'%" + txtSearch1.Text + "%' or CarModel Like '" + txtSearch1.Text + "%'", sql_con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvCar.DataSource = ds.Tables[0];



            }
            else if (txtSearch1.Text == "Search")
            {
                LoadData();
            }
            else
            {
                LoadData();
            }
        }

        private void dgvCarRental_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow dr = dgvCarRented.Rows[e.RowIndex];
                txtRentalID.Text = dr.Cells[0].Value.ToString();
               cmbCustomerID.Text = dr.Cells[1].Value.ToString();
                txtCustomerName.Text = dr.Cells[2].Value.ToString();
                txtCarID.Text = dr.Cells[3].Value.ToString();
                txtCarName.Text = dr.Cells[4].Value.ToString();
                txtCarBrand.Text = dr.Cells[5].Value.ToString();
                txtCarModel.Text = dr.Cells[6].Value.ToString();
                txtPenalyPerDay.Text = dr.Cells[7].Value.ToString();
                dtpRental.Text = dr.Cells[8].Value.ToString();
                dtpReturn.Text = dr.Cells[9].Value.ToString();
                txtRentalPrice.Text = dr.Cells[10].Value.ToString();
             
                txtReturnDriver.Text = dr.Cells[11].Value.ToString();
                txtReturnTotal.Text = dr.Cells[12].Value.ToString();
                byte[] imgData = (byte[])dr.Cells[13].Value;
                MemoryStream ms = new MemoryStream(imgData);
                pbImage.Image = Image.FromStream(ms);


                string date1 = dtpRental.Value.ToString();
                DateTime dt1 = Convert.ToDateTime(date1);

                string date2 = dtpReturn.Value.ToString();
                DateTime dt2 = Convert.ToDateTime(date2);

                int days;
                days = (dt2 - dt1).Days;
                txtRentalDays.Text = String.Format("{0:0}", days);









            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
}

        private void dgvCarRental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //DataGridViewRow dr = dgvCarRental.Rows[e.RowIndex];
                //txtRentalID.Text = dr.Cells[0].Value.ToString();
                //cmbCustomerID.Text = dr.Cells[1].Value.ToString();
                //txtCustomerName.Text = dr.Cells[2].Value.ToString();
                //txtCarID.Text = dr.Cells[3].Value.ToString();
                //txtCarName.Text = dr.Cells[4].Value.ToString();
                //txtCarBrand.Text = dr.Cells[5].Value.ToString();
                //txtCarModel.Text = dr.Cells[6].Value.ToString();
                //txtPenalyPerDay.Text = dr.Cells[7].Value.ToString();
                //dtpRental.Text = dr.Cells[8].Value.ToString();
                //dtpReturn.Text = dr.Cells[9].Value.ToString();
                //txtRentalPrice.Text = dr.Cells[10].Value.ToString();
                //cmbDriver.Text = dr.Cells[11].Value.ToString();

                //txtRentalTotal.Text = dr.Cells[12].Value.ToString();
                //byte[] imgData = (byte[])dr.Cells[13].Value;
                //MemoryStream ms = new MemoryStream(imgData);
                //pbImage.Image = Image.FromStream(ms);











            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }

        private void txtRentalPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtRentalPrice.Text == "")
            {
                cmbDriver.Enabled = false;
            }
            else
            {
                cmbDriver.Enabled = true;
            }

        }
    }
}
