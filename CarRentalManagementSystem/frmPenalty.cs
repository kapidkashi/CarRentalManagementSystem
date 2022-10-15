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
    public partial class frmPenalty : Form
    {
        public frmPenalty()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBPenalty;
        private DataSet DSPenalty = new DataSet();
        private DataTable DTPenalty = new DataTable();

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

            string CommandText = "Select * from Penalty";
            DBPenalty = new SQLiteDataAdapter(CommandText, sql_con);
            DSPenalty.Reset();
            DBPenalty.Fill(DSPenalty);
            DTPenalty = DSPenalty.Tables[0];
            dgvPenalty.DataSource = DTPenalty;

            sql_con.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to go Back?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPenalty.Text == "")
            {
                MessageBox.Show("Please fill up the form");
            }
            else
            {
                string txtQuery = "Insert into Penalty (Penalty) values ('" + txtPenalty.Text + "')";
                ExecuteQuery(txtQuery);
                LoadData();
                txtPenalty.Clear();
                MessageBox.Show("New Penalty has been added.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string txtQuery = "Update Penalty set Penalty = '" + txtPenalty.Text + "' where PenaltyID = PenaltyID ";
            ExecuteQuery(txtQuery);
            LoadData();
            txtPenalty.Clear();
            MessageBox.Show(" Penalty has been Updated.");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to remove this Penalty?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                string textQuery = "Delete from Penalty where Penalty ='" + txtPenalty.Text + "'";
                ExecuteQuery(textQuery);
                
                LoadData();
                txtPenalty.Clear();
            }
        }

        private void dgvPenalty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvPenalty.SelectedRows[0];
            txtPenalty.Text = dr.Cells[1].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure to Exit?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
               
                this.Close();
            }
        }

        private void frmPenalty_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
