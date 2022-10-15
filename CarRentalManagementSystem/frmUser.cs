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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBUser;
        private DataSet DSUser = new DataSet();
        private DataTable DTUser = new DataTable();
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

            string CommandTextCar = "Select UserID,UserType,Name,UserName from User";
            DBUser = new SQLiteDataAdapter(CommandTextCar, sql_con);
            DSUser.Reset();
            DBUser.Fill(DSUser);
            DTUser = DSUser.Tables[0];
            dgvUser.DataSource = DTUser;

        

            sql_con.Close();
        }
        private void btAddUser_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmCreateAccount")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmCreateAccount fc = new frmCreateAccount();
                fc.Show();
            }

        }
        public string getUser { get; set; }
        public string getUserType { get; set; }
        private void frmUser_Load(object sender, EventArgs e)
        {
            lblUser.Text = getUser;
            lblUserType.Text = getUserType;
            LoadData();
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
             
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvUser.Rows[e.RowIndex];
            txtUserID.Text = dr.Cells[0].Value.ToString();
            cmbUserType.Text = dr.Cells[1].Value.ToString();
            txtName.Text =dr.Cells[2].Value.ToString();
            txtUserName.Text = dr.Cells[3].Value.ToString();
        }
        private void Clear()
        {
            txtUserID.Clear();
            cmbUserType.Text = "";
            txtName.Clear();
            txtUserName.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string txtQuery = "Update User set UserType = '"+ cmbUserType.Text+ "', Name = '" + txtName.Text + "',UserName = '" + txtUserName.Text + "'" +
                "where UserID = '"+txtUserID.Text +"'";
            ExecuteQuery(txtQuery);
            LoadData();
            Clear();

            MessageBox.Show("User has been Updated.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to remove this User?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                string txtQuery = "Delete from User where UserID ='" + txtUserID.Text + "'";
                ExecuteQuery(txtQuery);

                LoadData();
                Clear();
            }
        }

        private void btnReloadCarBrand_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                sql_cmd = new SQLiteCommand("select UserID,UserType,Name,UserName from User where UserType Like  '" + txtSearch.Text + "%' or UserName Like'%" + txtSearch.Text + "%' or Name Like '" + txtSearch.Text + "%'", sql_con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvUser.DataSource = ds.Tables[0];



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

    }
}
