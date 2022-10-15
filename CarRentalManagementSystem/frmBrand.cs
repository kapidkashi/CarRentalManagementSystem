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

namespace Pragados_Project
{
    public partial class frmBrand : Form
    {
        public frmBrand()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBBrand;
        private DataSet DSBrand = new DataSet();
        private DataTable DTBrand = new DataTable();

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

            string CommandText = "Select * from CarBrand";
            DBBrand = new SQLiteDataAdapter(CommandText, sql_con);
            DSBrand.Reset();
            DBBrand.Fill(DSBrand);
            DTBrand = DSBrand.Tables[0];
            dgvBrand.DataSource = DTBrand;

            sql_con.Close();
        }
        private void frmBrand_Load(object sender, EventArgs e)
        {
            LoadData();  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text == "")
            {
                MessageBox.Show("Please fill up the form");
            }
            else
            {
                string txtQuery = "Insert into CarBrand (CarBrand) values ('" + txtBrand.Text + "')";
                ExecuteQuery(txtQuery);
                LoadData();
                txtBrand.Clear();
                MessageBox.Show("New Car Brand has been added.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string txtQuery = "Update CarBrand set CarBrand = '" + txtBrand.Text + "' where CarBrandID =CarBrandID";
            ExecuteQuery(txtQuery);
            LoadData();
            txtBrand.Clear();
            MessageBox.Show("Car Brand has been Updated.");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to remove this Brand?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                string textQuery = "Delete from CarBrand where CarBrand ='" + txtBrand.Text + "'";
                ExecuteQuery(textQuery);

                LoadData();
                txtBrand.Clear();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to go Back?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
               
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to Exit?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
               
                this.Close();
            }
        }

        private void dgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvBrand.Rows[e.RowIndex];
            txtBrand.Text = dr.Cells[1].Value.ToString();
        }
    }
}
