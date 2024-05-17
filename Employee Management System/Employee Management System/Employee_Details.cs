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
using System.Collections;

namespace Employee_Management_System
{
    public partial class Employee_Details : Form
    {
         SqlDataAdapter adpt;
        DataTable dt;
        int Emp_ID;
        public Employee_Details()
        {
            InitializeComponent();
            displayData();

        }
        SqlConnection con = new SqlConnection(@"Data Source=WHITE-DEVIL\SQLEXPRESS;Initial Catalog=FinexDB;Integrated Security=True");
      
        public void displayData()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from Reg_TB", con);
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


                string query_insert = "INSERT INTO Reg_TB VALUES('" + Emp_ID + "','" + First_Name + "','" + Last_Name + "','" + Date_Of_Birth + "','" + Gender + "','" + Marital_Status + "','" + Contact + "','" + Address + "','" + Email + "','" + Department + "')";
           
                SqlCommand cmnd = new SqlCommand(query_insert, con);
               
                con.Open();
                cmnd.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("Do you want to save it?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
               
                {
                    MessageBox.Show("Saved successfully!");
                    ClearDB();  
             
                    

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
            try
            {
                con.Open();
                string query = "UPDATE Reg_TB SET First_Name = '" + txtFName.Text + "', Last_Name = '" + txtLName.Text + "', Date_Of_Birth = '" + dtpDateOfBirth.Text + "', Gender = '" + cmbGender.Text + "', Marital_Status = '" + cmbMarital_Status.Text + "', Contact = '" + txtContactNo.Text + "', Address = '" + txtAddress.Text + "', Email = '" + txtEmail.Text + "', Department = '" + cmbDepartment.Text + "' WHERE Emp_ID = '" + txtID.Text + "'  ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand del = new SqlCommand("DELETE FROM Reg_TB WHERE Emp_ID ='" + txtID.Text + "'", con);
                del.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("Do you want to delete it?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)

                {
                    MessageBox.Show("Deleted successfully!");
                    ClearDB();
          


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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string u_EmpID = txtSearchEID.Text;

            try
            {
                con.Open();
                SqlCommand comn = new SqlCommand("SELECT * FROM [dbo].[Reg_Tb] WHERE (Emp_ID= '" + u_EmpID + "')", con);
                SqlDataReader reader;
                reader = comn.ExecuteReader();
                while (reader.Read())
                {
                    txtID.Text = reader.GetValue(0).ToString();
                    txtFName.Text = reader.GetValue(1).ToString();
                    txtLName.Text = reader.GetValue(2).ToString();
                    dtpDateOfBirth.Text = reader.GetValue(3).ToString();
                    cmbGender.Text = reader.GetValue(4).ToString();
                    cmbMarital_Status.Text = reader.GetValue(5).ToString();
                    txtContactNo.Text = reader.GetValue(6).ToString();  
                    txtAddress.Text = reader.GetValue(7).ToString();    
                    txtEmail.Text = reader.GetValue(8).ToString();  
                    cmbDepartment.Text = reader[9].ToString();  
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void Employee_Details_Load(object sender, EventArgs e)
        {
            displayData();
        }
        private void ClearDB()
        {
            txtID.Clear();
            txtFName.Clear();
            txtLName.Clear();
            dtpDateOfBirth.Refresh();
            cmbGender.Refresh();
            cmbMarital_Status.Refresh();
            txtContactNo.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            cmbDepartment.Refresh();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WHITE-DEVIL\SQLEXPRESS;Initial Catalog=FinexDB;Integrated Security=True");
            con.Open();
            adpt = new SqlDataAdapter("select * from Reg_TB", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dgvEmployee.DataSource = dt;
            con.Close();
        }

        private void dgvEmployee_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Manage application form Close ?", "Manage Employee Form Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                MainMenu obj = new MainMenu();
                obj.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit this system?", "Application Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to logout this system?", "Application Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form1 obj1 = new Form1();
                obj1.Show();
            }
        }
    }

}