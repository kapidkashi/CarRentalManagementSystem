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
using System.Text.RegularExpressions;

namespace Pragados_Project
{
    public partial class frmCustomer : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBCustomer;
        private DataSet DSCustomer = new DataSet();
        private DataTable DTCustomer = new DataTable();
        public string getUser { get; set; }
        public string getUserType { get; set; }
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            lblUserType.Text = getUserType;
            lblUser.Text = getUser;
            LoadData();
            CustomerID();
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

            string CommandText = "Select * from Customer";
            DBCustomer = new SQLiteDataAdapter(CommandText, sql_con);
            DSCustomer.Reset();
            DBCustomer.Fill(DSCustomer);
            DTCustomer = DSCustomer.Tables[0];
            dgvCustomer.DataSource = DTCustomer;

            sql_con.Close();
        }
     
        private void CustomerID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBID = new SQLiteDataAdapter("select CustomerID from Customer order by CustomerID desc", sql_con);
                DataSet DSID = new DataSet();
                DBID.Fill(DSID);
                if (DSID.Tables[0].Rows.Count > 0)
                {
                    txtAutoCustomerID.Text = DSID.Tables[0].Rows[0]["CustomerID"].ToString();
                }
                else
                {
                    txtAutoCustomerID.Text = "CUS0000";
                }
                if (!string.IsNullOrEmpty(txtAutoCustomerID.Text))
                {
                    txtAutoCustomerID.SelectionStart = 3;
                    txtAutoCustomerID.SelectionLength = 4;
                    lblAutoCustomerID.Text = txtAutoCustomerID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoCustomerID.Text))
                {
                    int ID = int.Parse(lblAutoCustomerID.Text.ToString()) + 1;
                    txtCustomerID.Text = ID.ToString("CUS0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
        private void Clear()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtEmail.Clear();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtName.Text == "" || txtAddress.Text == "" || txtContact.Text == "" || txtEmail.Text == "")
                {
                    MessageBox.Show("Please fill all DATA!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string txtQuery = "Insert into Customer(CustomerID,CustomerName,Address,Contact,Email) " +
                    "values ('" + txtCustomerID.Text + "','" + txtName.Text + "','" + txtAddress.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "')";
                    ExecuteQuery(txtQuery);
                    Clear();
                    LoadData();
                    CustomerID();
                    MessageBox.Show("New Customer has been added.");
                }
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

                string txtQuery = "Update Customer set CustomerID ='" + txtCustomerID.Text + "',CustomerName='" + txtName.Text + "'," +
                  " Address='" + txtAddress.Text + "',Contact='" + txtContact.Text + "',Email='" + txtEmail.Text + "' " +
                  "where CustomerID='" + txtCustomerID.Text + "'";
                ExecuteQuery(txtQuery);
                LoadData();
                CustomerID();
                Clear();
                MessageBox.Show("Customer Data has been Updated");
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }


          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            CustomerID();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to remove this Customer?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                string txtQuery = "Delete from Customer where CustomerID ='" + txtCustomerID.Text + "'";
                ExecuteQuery(txtQuery);
              
                LoadData();
                Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool IsOpen;
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

        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                sql_cmd = new SQLiteCommand("select * from Customer where CustomerName Like  '" + txtSearch.Text + "%' or Address Like'%" + txtSearch.Text + "%' or Contact Like '" + txtSearch.Text + "%' or Email Like '" + txtSearch.Text + "%'", sql_con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvCustomer.DataSource = ds.Tables[0];



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

      

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtContact_Enter(object sender, EventArgs e)
        {

        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                  DataGridViewRow dr = dgvCustomer.Rows[e.RowIndex];
            txtCustomerID.Text = dr.Cells[0].Value.ToString();
            txtName.Text = dr.Cells[1].Value.ToString();
            txtAddress.Text = dr.Cells[2].Value.ToString();
            txtContact.Text = dr.Cells[3].Value.ToString();
            txtEmail.Text = dr.Cells[4].Value.ToString();
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
         
        }
    }
}
