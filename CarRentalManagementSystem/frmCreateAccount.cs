using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Pragados_Project
{
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source = CarRentDB.db ; Version = 3; New = False; Compress = True");

        }
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            frmCreateAccount fca = new frmCreateAccount();
            string CommandText = "Select * from User";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];



            sql_con.Close();

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
        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            LoadData();
            AdminID();
            EmpID();
        }
        private void AdminID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBLibID = new SQLiteDataAdapter("select AdminID from AdminID order by AdminID desc", sql_con);
                DataSet DSLibID = new DataSet();
                DBLibID.Fill(DSLibID);
                if (DSLibID.Tables[0].Rows.Count > 0)
                {
                    txtAutoAdminID.Text = DSLibID.Tables[0].Rows[0]["AdminID"].ToString();
                }
                else
                {
                    txtAutoAdminID.Text = "ADM0000";
                }
                if (!string.IsNullOrEmpty(txtAutoAdminID.Text))
                {
                    txtAutoAdminID.SelectionStart = 3;
                    txtAutoAdminID.SelectionLength = 4;
                    lblAutoAdmin.Text = txtAutoAdminID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoAdmin.Text))
                {
                    int ID = int.Parse(lblAutoAdmin.Text.ToString()) + 1;
                    txtID.Text = ID.ToString("ADM0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
        private void EmpID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBID = new SQLiteDataAdapter("select EmpID from EmpID order by EmpID desc", sql_con);
                DataSet DSID = new DataSet();
                DBID.Fill(DSID);
                if (DSID.Tables[0].Rows.Count > 0)
                {
                    txtAutoEmpID.Text = DSID.Tables[0].Rows[0]["EmpID"].ToString();
                }
                else
                {
                    txtAutoEmpID.Text = "EMP0000";
                }
                if (!string.IsNullOrEmpty(txtAutoEmpID.Text))
                {
                    txtAutoEmpID.SelectionStart = 3;
                    txtAutoEmpID.SelectionLength = 4;
                    lblAutoEmp.Text = txtAutoEmpID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoEmp.Text))
                {
                    int ID = int.Parse(lblAutoEmp.Text.ToString()) + 1;
                    txtID.Text = ID.ToString("EMP0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }

        private void cmbUserType_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbUserType.Text=="Employee")
            {
                EmpID();
            }
            else if (cmbUserType.Text== "Admin")
            {
                AdminID();
            }
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to go Back?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

          
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to go Back?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

             
                this.Close();
            }
           
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUserName.Text == "" || txtPassword.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fill all Data", "Confirm");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password AND Confirm Password is not the same", "Confirm");
            }
             else if(cmbUserType.Text =="Admin")
            {
                string txtQuery = "Insert into User(UserID,UserType,Name,Username,Password) values ('" + txtID.Text + "','" + cmbUserType  .Text + "','" + txtName.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "')";
                ExecuteQuery(txtQuery);
                string txtQueryRentalID = "Insert into AdminID(AdminID) values ('" + txtID.Text + "')";
                ExecuteQuery(txtQueryRentalID);
                MessageBox.Show("New Account has been Added.");
                AdminID();
                LoadData();
               
                txtID.Clear();
                txtName.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                

            }
           else if (cmbUserType.Text == "Employee")
            {
                string txtQuery = "Insert into User(UserID,UserType,Name,Username,Password) values ('" + txtID.Text + "','" + cmbUserType.Text + "','" + txtName.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "')";
                ExecuteQuery(txtQuery);
                string txtQueryRentalID = "Insert into EmpID(EmpID) values ('" + txtID.Text + "')";
                ExecuteQuery(txtQueryRentalID);
                MessageBox.Show("New Account has been Added.");
                EmpID();
                LoadData();
                txtName.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtID.Clear();
            }
        }

   

        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void cbConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirm.Checked)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserType.Text == "Employee")
            {
                EmpID();
            }
            else if (cmbUserType.Text == "Admin")
            {
                AdminID();
            }
        }
    }
}
