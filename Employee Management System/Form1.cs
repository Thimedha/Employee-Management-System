using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string password = txtpassword.Text;

            if (email == "finex.lk" && password == "Finex123")
            {
                MessageBox.Show("Login Success!", "Login Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Hide();
                MainMenu obj = new MainMenu();
                obj.Show();
            }
            else if (email != "finex.lk" && password == "Finex123")
            {
                MessageBox.Show("Your email is incorrect","Login Form",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
            else if (email == "finex.lk" && password != "Finex123")
            {
                MessageBox.Show("Your password is incorrect", "Login Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Login unsuccessful!", "Login Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
