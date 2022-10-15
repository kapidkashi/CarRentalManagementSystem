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
    public partial class frmLogin : Form
    {
        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        public frmLogin()
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

            frmCreateAccount fca = new frmCreateAccount();
            string CommandText = "Select * from User";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];



            sql_con.Close();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please fill all data", "Confirm");
                }
                else
                {  
                   
                    
                   
                   

                    sql_cmd.CommandText = "select * from user where UserName = '" + txtName.Text + "'and Password = '" + txtPassword.Text + "'";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                    DataTable ds = new DataTable();
                    da.Fill(ds);

                    //sql_con.Open();
                    //SQLiteDataReader dr = sql_cmd.ExecuteReader();
                   
                    if (ds.Rows.Count>0)
                        {
                           
                            if (ds.Rows[0][1].ToString() == "Admin")
                            {
                                this.Hide();

                                frmDashboard fd = new frmDashboard();
                                fd.getUser = txtName.Text = ds.Rows[0][2].ToString();
                                fd.getUserType = "Admin:";



                                fd.Show();
                            }
                            else if (ds.Rows[0][1].ToString() == "Employee")
                            {
                                this.Hide();
                                frmDashboard fd = new frmDashboard();
                                fd.getUser = txtName.Text = ds.Rows[0][2].ToString(); ;
                                fd.getUserType = "Employee:";



                                fd.Show();
                            }

                           

                        }

                    else
                    {
                        MessageBox.Show("User Name and Password do not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    //sql_con.Close();

                }
            }


            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }

        }

    
            



        

        private void lblClickHere_Click(object sender, EventArgs e)
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
                frmCreateAccount fca = new frmCreateAccount();
                fca.Show();
            }
           
            
        }

        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
          if(cbPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;

            }
          else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmForgotPassword")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmForgotPassword fp = new frmForgotPassword();
                fp.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
