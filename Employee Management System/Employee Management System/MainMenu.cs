using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class MainMenu : Form
    {
      
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnemployeedetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Details obj = new Employee_Details();
            obj.Show();
        }

        private void btnsalary_Click(object sender, EventArgs e)
        {
            this.Hide();
            Salary obj = new Salary();
            obj.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("Do you really want to exit this system?", "Application Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
           
            
        }
    }
}
