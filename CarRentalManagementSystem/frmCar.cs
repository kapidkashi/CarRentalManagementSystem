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
using System.Drawing.Imaging;

namespace Pragados_Project
{
    public partial class frmCar : Form
    {
        public frmCar()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBCar;
        private DataSet DSCar = new DataSet();
        private DataTable DTCar = new DataTable();


        private SQLiteDataAdapter DBBrand;
        private DataSet DSBrand = new DataSet();
        private DataTable DTBrand = new DataTable();

        private SQLiteDataAdapter DBPenalty;
        private DataSet DSPenalty = new DataSet();
        private DataTable DTPenalty = new DataTable();


        public string getUser { get; set; }
        public string getUserType { get; set; }
        private void frmCar_Load(object sender, EventArgs e)
        {
            lblUserType.Text = getUserType;
            lblUser.Text = getUser;
            CarID();
            LoadData();
            
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

            string CommandTextCar = "Select * from Cars";
            DBCar = new SQLiteDataAdapter(CommandTextCar, sql_con);
            DSCar.Reset();
            DBCar.Fill(DSCar);
            DTCar = DSCar.Tables[0];
            dgvCar.DataSource = DTCar;

            string CommandTextBrand = "Select * from CarBrand";
            DBBrand = new SQLiteDataAdapter(CommandTextBrand, sql_con);
            DSBrand.Reset();
            DBBrand.Fill(DSBrand);
            DTBrand = DSBrand.Tables[0];
            frmBrand fb = new frmBrand();
            fb.dgvBrand.DataSource = DTBrand;

            cmbCarBrand.DataSource = DTBrand;
            cmbCarBrand.DisplayMember = "CarBrand";
            cmbCarBrand.ValueMember = "CarBrandID";


            string CommandTextPenalty = "Select * from Penalty";
            DBPenalty = new SQLiteDataAdapter(CommandTextPenalty, sql_con);
            DSPenalty.Reset();
            DBPenalty.Fill(DSPenalty);
            DTPenalty = DSPenalty.Tables[0];
            frmPenalty fp = new frmPenalty();
            fp.dgvPenalty.DataSource = DTPenalty;

            cmbPenalty.DataSource = DTPenalty;
            cmbPenalty.DisplayMember = "Penalty";
            cmbPenalty.ValueMember = "PenaltyID";

            sql_con.Close();
        }
        private void CarID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBID = new SQLiteDataAdapter("select CarID from Cars order by CarID desc", sql_con);
                DataSet DSID = new DataSet();
                DBID.Fill(DSID);
                if (DSID.Tables[0].Rows.Count > 0)
                {
                    txtAutoCarID.Text = DSID.Tables[0].Rows[0]["CarID"].ToString();
                }
                else
                {
                    txtAutoCarID.Text = "CAR0000";
                }
                if (!string.IsNullOrEmpty(txtAutoCarID.Text))
                {
                    txtAutoCarID.SelectionStart = 3;
                    txtAutoCarID.SelectionLength = 4;
                    lblAutoCarID.Text = txtAutoCarID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoCarID.Text))
                {
                    int ID = int.Parse(lblAutoCarID.Text.ToString()) + 1;
                    txtCarID.Text = ID.ToString("CAR0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
     
        String imgLoc = "";
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLoc = dialog.FileName.ToString();
                pbImage.ImageLocation = imgLoc;


            }

        }
        private void Clear()
        {
         
            txtCarName.Clear();
            txtCarModel.Clear();
            txtPrice.Clear();
            
            pbImage.Image = null;
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCarModel.Text == "" || txtCarName.Text == "" || txtPrice.Text == "" )
                {
                    MessageBox.Show("Please fill all DATA!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (pbImage.Image == null)
                {
                    MessageBox.Show("Please input Car Image", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    byte[] imageBt = null;
                    FileStream fstream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imageBt = br.ReadBytes((int)fstream.Length);
                    sql_con.Open();
                    string txtQuery = "Insert into Cars(CarID,CarName,CarBrand,CarModel,Price,Availability,Penalty,Image) " +
                        "values ('" + txtCarID.Text + "','" + txtCarName.Text + "','" + cmbCarBrand.Text + "','" + txtCarModel.Text + "'," +
                        "'" + txtPrice.Text + "','" + cmbAvail.Text + "','" + cmbPenalty.Text + "',@imageBt)";
                    sql_cmd = new SQLiteCommand(txtQuery, sql_con);
                    sql_cmd.Parameters.Add(new SQLiteParameter("@imageBt", imageBt));
                    sql_cmd.ExecuteNonQuery();
                    sql_con.Close();
                    CarID();
                    LoadData();
                    Clear();
                    MessageBox.Show("New Car has been added!");
                }
               
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
           
            
     
         
        }

        private void dgvCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvCar.Rows[e.RowIndex];
                txtCarID.Text = dr.Cells[0].Value.ToString();
                txtCarName.Text = dr.Cells[1].Value.ToString();
                cmbCarBrand.Text = dr.Cells[2].Value.ToString();
                txtCarModel.Text = dr.Cells[3].Value.ToString();
                txtPrice.Text = dr.Cells[4].Value.ToString();
                cmbAvail.Text = dr.Cells[5].Value.ToString();
                cmbPenalty.Text = dr.Cells[6].Value.ToString();
                byte[] imgData = (byte[])dr.Cells[7].Value;
                MemoryStream ms = new MemoryStream(imgData);
                pbImage.Image = Image.FromStream(ms);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] imgData = (byte[])dgvCar.Rows[0].Cells[7].Value;
                MemoryStream ms = new MemoryStream(imgData);
                pbImage.Image = Image.FromStream(ms);

                string txtQuery = "Update Cars set CarID='" + txtCarID.Text + "',CarName='" + txtCarName.Text + "'," +
                    "CarBrand='" + cmbCarBrand.Text + "',CarModel='" + txtCarModel.Text + "',Price='" + txtPrice.Text + "'," +
                    "Availability='" + cmbAvail.Text + "',Penalty='" + cmbPenalty.Text + "',Image=@imageBt where CarID = '" + txtCarID.Text + "' ";

                sql_cmd = new SQLiteCommand(txtQuery, sql_con);
                sql_cmd.Parameters.Add(new SQLiteParameter("@imageBt", imgData));

                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                CarID();
                LoadData();
                Clear();
                MessageBox.Show("Car Data has been Updated!");
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

           

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            CarID();
            LoadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to remove this Car?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if(x == DialogResult.Yes)
            {
                string txtQuery = "Delete from Cars where CarID ='" + txtCarID.Text + "'";
                ExecuteQuery(txtQuery);
                
                LoadData();
                Clear();
            }
           
        }

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
            else if(txtSearch.Text =="Search")
            {
                LoadData();
            }
            else
            {
                LoadData();
            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            //bool IsOpen;
            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f.Name == "frmDashboard")
            //    {
                    DialogResult x = MessageBox.Show("Are you sure to Exit?", "Confirmation Message!", MessageBoxButtons.YesNo);
                    if (x == DialogResult.Yes)
                    {
                        frmDashboard fd = new frmDashboard();
                        fd.getUser = lblUser.Text;
                        fd.getUserType = lblUserType.Text;
                        fd.Show();
                        this.Hide();
                
                    }
            //    }

            //}

            
           
          
        }

        private void btnAddCarBrand_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmBrand")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmBrand fb = new frmBrand();
                fb.Show();
            }
            
        }

        private void btnReloadCarBrand_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddPenalty_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmPenalty")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmPenalty fp = new frmPenalty();
                fp.Show();
            }
            
        }

        private void btnReloadPenalty_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvCar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
 }

