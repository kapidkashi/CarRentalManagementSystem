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
    public partial class frmTransaction : Form
    {
        public string getUser { get; set; }
        public string getUserType { get; set; }
        public frmTransaction()
        {
            InitializeComponent();
        }
        private SQLiteDataAdapter DBTransact;
        private DataSet DSTransact = new DataSet();
        private DataTable DTTransact = new DataTable();
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            lblUserType.Text = getUserType;
            lblUser.Text = getUser;
            LoadData();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

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

            string CommandTextTransact = "Select * from [Transaction]";
            DBTransact = new SQLiteDataAdapter(CommandTextTransact, sql_con);
            DSTransact.Reset();
            DBTransact.Fill(DSTransact);
            DTTransact = DSTransact.Tables[0];
            dgvTransact.DataSource = DTTransact;

         
            sql_con.Close();
        }

        private void dgvTransact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            DataGridViewRow dr = dgvTransact.Rows[e.RowIndex];
            txtReturnRentalID.Text = dr.Cells[1].Value.ToString();
            txtCustomerID.Text = dr.Cells[2].Value.ToString();
            txtCustomerName.Text = dr.Cells[3].Value.ToString();
            txtCarID.Text = dr.Cells[4].Value.ToString();
            txtCarName.Text = dr.Cells[5].Value.ToString();
            txtCarBrand.Text = dr.Cells[6].Value.ToString();
            txtCarModel.Text = dr.Cells[7].Value.ToString();
            byte[] imgData = (byte[])dr.Cells[12].Value;
            MemoryStream ms = new MemoryStream(imgData);
            pbImage.Image = Image.FromStream(ms);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
     

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                sql_cmd = new SQLiteCommand("select * from [Transaction] where RentalReturnID Like  '" + txtSearch.Text + "%' or CustomerID Like  '" + txtSearch.Text + "%' or CustomerName Like  '" + txtSearch.Text + "%' or CarID Like  '" + txtSearch.Text + "%' or Driver Like  '" + txtSearch.Text + "%' or CarName Like  '" + txtSearch.Text + "%' or CarBrand Like'%" + txtSearch.Text + "%' or CarModel Like '" + txtSearch.Text + "%'", sql_con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvTransact.DataSource = ds.Tables[0];



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

        private void Clear()
        {
            txtReturnRentalID.Clear();
            txtCustomerName.Clear();
            txtCarID.Clear();
            txtCarName.Clear();
            txtCarBrand.Clear();
            txtCarModel.Clear();
        
            pbImage.Image = null;
           

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
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
    }
}
