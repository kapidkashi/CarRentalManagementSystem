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
    public partial class frmAccountSetting : Form
    {
        public frmAccountSetting()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBAccount;
        private DataSet DSAccount = new DataSet();
        private DataTable DTAccount = new DataTable();
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
            sql_cmd = sql_con.CreateCommand();

            string CommandText = "Select * from User";
            DBAccount = new SQLiteDataAdapter(CommandText, sql_con);
            DSAccount.Reset();
            DBAccount.Fill(DSAccount);
            DTAccount = DSAccount.Tables[0];
           

           

            sql_con.Close();
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {

              if (txtUser.Text == "")
                {
                    MessageBox.Show("Enter Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtOldPassword.Text == "")
                {
                    MessageBox.Show("Enter Old Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                     try
                     {
                         sql_con.ConnectionString = "Data Source = CarRentDB.db ; Version = 3; New = False; Compress = True";
                         sql_cmd.Connection = sql_con;



                        sql_cmd.CommandText = "select * from User where Name = '" + txtUser.Text + "'and Password = '" + txtOldPassword.Text + "'";
                        SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);



                        if (ds.Tables[0].Rows.Count != 0)
                        {
                                panel1.Show();
                        }
                        else
                        {
                                MessageBox.Show("User Name and Password do not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                     }
                     catch (Exception ab)
                     {
                        MessageBox.Show(ab.Message);
                     }    

                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
            

        }
        public string getUser { get; set; }
        public string getUserType { get; set; }
        private void frmAccountSetting_Load(object sender, EventArgs e)
        {
            lblUserType.Text = getUserType;
            txtUser.Text = getUser;
            LoadData();
        }
      
        private void btnEditUserName_Click(object sender, EventArgs e)
        {
            try
            {

                 string txtQuery = "Update User Set UserName= '" + txtUser.Text + "' where UserName = '" + txtUser.Text + "'";
            ExecuteQuery(txtQuery);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
           
        }

        private void txtOldPassword_Leave(object sender, EventArgs e)
        {
           
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {

                   string txtQuery = "update User set Password='" + txtConfirm.Text + "' where UserName ='"+txtUser.Text +"'";
            ExecuteQuery(txtQuery);

            txtOldPassword.Clear();
            txtNew.Clear();
            txtConfirm.Clear();
                MessageBox.Show("Your Password has been Updated!");
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
         ;
        }

        private void txtOldPassword_Enter(object sender, EventArgs e)
        {
            

       
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to go Back?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                frmDashboard fd = new frmDashboard();
                fd.getUser = txtUser.Text;
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
                fd.getUser = txtUser.Text;
                fd.getUserType = lblUserType.Text;
                fd.Show();
                this.Hide();

            }

        }

        private void cbOldPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOldPassword.Checked == true)
            {
                txtOldPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtOldPassword.UseSystemPasswordChar = true;
            }
        }

        private void cbNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNewPassword.Checked == true)
            {
                txtNew.UseSystemPasswordChar = false;

            }
            else
            {
                txtNew.UseSystemPasswordChar = true;
            }
        }

        private void cbConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirmPassword.Checked == true)
            {
                txtConfirm.UseSystemPasswordChar = false;

            }
            else
            {
                txtConfirm.UseSystemPasswordChar = true;
            }
        }
    }
}
