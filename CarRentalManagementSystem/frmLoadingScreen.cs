using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pragados_Project
{
    public partial class frmLoadingScreen : Form
    {
        public frmLoadingScreen()
        {
            InitializeComponent();
        }
     
      
       
    
        private void frmLoadingScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 4;
            myProgress.Value = startpoint;
            if (myProgress.Value == 100)
            {
                myProgress.Value = 0;
                timer1.Stop();
                frmLogin log = new frmLogin();
                log.Show();
                this.Hide();
            }
            
        }
    }
}
