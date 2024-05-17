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
using System.Net.Mail;
using System.Net;

namespace Employee_Management_System
{
    public partial class Employee_Details : Form
    {
        public Employee_Details()
        {
            InitializeComponent();
            displayData();

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-THAS7GN\SQLEXPRESS;Initial Catalog=FinexDB;Integrated Security=True");
        SqlDataAdapter adpt;
        DataTable dt;
        int Emp_ID;
        public void displayData()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from RegTB", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dgvEmployee.DataSource = dt;
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Emp_ID = txtID.Text;
                string First_Name = txtFName.Text;
                string Last_Name = txtLName.Text;
                string Date_Of_Birth = dtpDateOfBirth.Text;
                string Gender = cmbGender.Text;
                string Marital_Status = cmbMarital_Status.Text;
                string Contact = txtContactNo.Text;
                string Address = txtAddress.Text;
                string Email = txtEmail.Text;
                string Department = cmbDepartment.Text;


                string query_insert = "INSERT INTO RegTB VALUES('" + Emp_ID + "','" + First_Name + "','" + Last_Name + "','" + Date_Of_Birth + "','" + Gender + "','" + Marital_Status + "','" + Contact + "','" + Address + "','" + Email + "','" + Department + "')";
                displayData();
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();

                cmnd.ExecuteNonQuery();
          
                DialogResult result = MessageBox.Show("Do you want to save it?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Saved successfully!");
                }
                else if (result == DialogResult.No)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some data missing" + ex);
            }
            finally
            {
                con.Close();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updatesql = "UPDATE RegTB SET Emp_ID='" + txtID + "' ,First_Name='" + txtFName + "',Last_Name='" + txtLName + "',Date_Of_Birth='" + dtpDateOfBirth + "',Gender='" + cmbGender + "',Marital_Status='" + cmbMarital_Status + "',Contact='" + txtContactNo + "',Address='" + txtAddress + "',Email='" + txtEmail + "',Department='" + cmbDepartment + "'";
            displayData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string deletesql = "DELETE FROM RegTB WHERE Emp_ID='" + txtID + "' ,First_Name='" + txtFName + "',Last_Name='" + txtLName + "',Date_Of_Birth='" + dtpDateOfBirth + "',Gender='" + cmbGender + "',Marital_Status='" + cmbMarital_Status + "',Contact='" + txtContactNo + "',Address='" + txtAddress + "',Email='" + txtEmail + "',Department='" + cmbDepartment + "'";
            displayData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string Register = txtID.Text;
                string query_search = "SELECT * FROM RegTB WHERE Register ='" + txtID.Text + "'";
                SqlCommand cmnd = new SqlCommand(query_search, con);
                SqlDataReader r = cmnd.ExecuteReader();
                while (r.Read())
                {
                    txtID.Text = r[1].ToString();
                    txtFName.Text = r[2].ToString();
                    txtLName.Text = r[3].ToString();
                    dtpDateOfBirth.Text = r[4].ToString();
                    cmbGender.Text = r[5].ToString();
                    cmbMarital_Status.Text = r[6].ToString();
                    txtContactNo.Text = r[7].ToString();
                    txtAddress.Text = r[8].ToString();
                    txtEmail.Text = r[9].ToString();
                    cmbDepartment.Text = r[10].ToString();

                    displayData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching" + ex);
            }
            finally
            {
               
            }
        }

        private void dgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Emp_ID = Convert.ToInt32(dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtFName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLName.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpDateOfBirth.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbGender.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbMarital_Status.Text = dgvEmployee.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtContactNo.Text = dgvEmployee.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvEmployee.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtEmail.Text = dgvEmployee.Rows[e.RowIndex].Cells[8].Value.ToString();
            cmbDepartment.Text = dgvEmployee.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
    }
}