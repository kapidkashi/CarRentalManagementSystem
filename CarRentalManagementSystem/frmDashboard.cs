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
    public partial class frmDashboard : Form
    {
        public string getUser { get; set; }
        public string getUserType { get; set; }
        public frmDashboard()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DBCar;
        private DataSet DSCar = new DataSet();
        private DataTable DTCar = new DataTable();
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source = CarRentDB.db ; Version = 3; New = False; Compress = True");

        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblUserType.Text = getUserType;
            lblUser.Text = getUser;
            if(lblUserType.Text == "Employee:")
            {
                btnUser.Visible = false;
            }
            SetConnection();
            string CTCar = "Select Count(*) from Cars where Availability='Yes'";
            DBCar = new SQLiteDataAdapter(CTCar, sql_con);      
            DBCar.Fill(DTCar);
            lblCars.Text =  DTCar.Rows[0][0].ToString();

            string CTAdmin = "Select Count(*) from User where UserType='Admin'";
            SQLiteDataAdapter DBAdmin = new SQLiteDataAdapter(CTAdmin, sql_con);
            DataTable DTAdmin = new DataTable();
            DBAdmin.Fill(DTAdmin);
            lblAdmin.Text = DTAdmin.Rows[0][0].ToString();

            string CTEmployee = "Select Count(*) from User where UserType='Employee'";
            SQLiteDataAdapter DBEmployee = new SQLiteDataAdapter(CTEmployee, sql_con);
            DataTable DTEmployee = new DataTable();
            DBEmployee.Fill(DTEmployee);
            lblEmployee.Text = DTEmployee.Rows[0][0].ToString();

            string CTCustomer = "Select Count(*) from [Customer]";
            SQLiteDataAdapter DBCustomer = new SQLiteDataAdapter(CTCustomer, sql_con);
            DataTable DTCustomer = new DataTable();
            DBCustomer.Fill(DTCustomer);
            lblCustomer.Text = DTCustomer.Rows[0][0].ToString();

            this.lblDateNow.Text = DateTime.Now.ToString();
            LoadData();

        }
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();

            string CommandText = "Select * from Cars";
            DBCar = new SQLiteDataAdapter(CommandText, sql_con);

            DBCar.Fill(DTCar);

            DSCar.Reset();
            DBCar.Fill(DSCar);
            DTCar = DSCar.Tables[0];
            dgvCar.DataSource = DTCar;
            sql_con.Close();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            log.Show();
            this.Hide();
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            frmCar fc = new frmCar();
            fc.getUser = lblUser.Text;
            fc.getUserType = lblUserType.Text;
            fc.Show();
         

            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer fcu = new frmCustomer();
            fcu.getUser = lblUser.Text;
            fcu.getUserType = lblUserType.Text;
            fcu.Show();
        

            this.Hide();
        }

        private void btnRental_Click(object sender, EventArgs e)
        {
            frmRental fr = new frmRental();
           
            fr.getUser = lblUser.Text;
            fr.getUserType = lblUserType.Text;
            fr.Show();
            this.Hide();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {

            frmTransaction ft = new frmTransaction();
            ft.getUser = lblUser.Text;
            ft.getUserType = lblUserType.Text;
            ft.Show();
      

            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser fu = new frmUser();
            fu.getUser = lblUser.Text;
            fu.getUserType = lblUserType.Text;
            fu.Show();

            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            frmAccountSetting fas = new frmAccountSetting();
            fas.getUser = lblUser.Text;
            fas.getUserType = lblUserType.Text;
            fas.Show();

            this.Hide();
        }

        private void dgvCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvCar.Rows[e.RowIndex];
            byte[] imgData = (byte[])dr.Cells[7].Value;
            MemoryStream ms = new MemoryStream(imgData);
            pbImage.Image = Image.FromStream(ms);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblDateNow.Text = DateTime.Now.ToString();
        }
    }
}
