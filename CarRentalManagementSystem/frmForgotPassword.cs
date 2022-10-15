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
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
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
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
             sql_cmd.CommandText = "select * from user where UserName = '" + txtName.Text + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count > 0)
                {


                 
                    
                        string txtQuery = "update User set Password='" + txtConfirmPassword.Text + "' where UserName ='" + txtName.Text + "'";
                        ExecuteQuery(txtQuery);

                        txtName.Clear();
                        txtConfirmPassword.Clear();
                        txtNewPassword.Clear();
                        LoadData();
                        MessageBox.Show("Your Password has been Updated!");

                    


                }
                else if (ds.Rows.Count == 0)
                {
                    MessageBox.Show("Incorrect User Name", "Confirm");
                }
                  else if (txtName.Text == "" || txtNewPassword.Text == "" || txtConfirmPassword.Text == "")
                {
                    MessageBox.Show("Fill all Data", "Confirm");
                }
                else if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password AND Confirm Password is not the same", "Confirm");
                }
             


            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
         
           
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Exit?", "Confirmation Message!", MessageBoxButtons.YesNo);
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

        private void cbNew_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNew.Checked == true)
            {
                txtNewPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void cbConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirm.Checked == true)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
