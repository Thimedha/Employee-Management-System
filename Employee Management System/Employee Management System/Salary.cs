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
    public partial class Salary : Form
    {
        SqlDataAdapter adpt;
        DataTable dt;
        int Emp_ID;
        public Salary()
        {
            InitializeComponent();
            displayData();

        }
        SqlConnection con = new SqlConnection(@"Data Source=WHITE-DEVIL\SQLEXPRESS;Initial Catalog=FinexDB;Integrated Security=True");

        public void displayData()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from Salary_TB", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dgvSalary.DataSource = dt;
            con.Close();
        }
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salary application form Close ?", "Salary Form Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Emp_ID = txtID.Text;
                string Emp_Name = txtEName.Text;
                string Salary_Month = dtpSalaryMonth.Text;
                string Department = cmbDepartment.Text;
                string Basic_Salary = txtBasic.Text;
            


                string query_insert = "INSERT INTO Salary_TB VALUES('" + Emp_ID + "','" + Emp_Name + "','" + Salary_Month + "','" + Department + "','" + Basic_Salary + "')";

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
                string query = "UPDATE Salary_TB SET Emp_Name = '" + txtEName.Text + "', Salary_Month = '" + dtpSalaryMonth.Text + "', Department = '" + cmbDepartment.Text + "', Basic_Salary = '" + txtBasic.Text + "' WHERE Emp_ID = '" + txtID.Text + "'  ";
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
                SqlCommand del = new SqlCommand("DELETE FROM Salary_TB WHERE Emp_ID ='" + txtID.Text + "'", con);
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
        private void ClearDB()
        {
          
            txtID.Clear();
            txtEName.Clear();
            dtpSalaryMonth.Refresh();
            cmbDepartment.Refresh();
            txtBasic.Clear();
          

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WHITE-DEVIL\SQLEXPRESS;Initial Catalog=FinexDB;Integrated Security=True");
            con.Open();
            adpt = new SqlDataAdapter("select * from Salary_TB", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dgvSalary.DataSource = dt;
            con.Close();
        }

        private void dgvSalary_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Emp_ID = Convert.ToInt32(dgvSalary.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtEName.Text = dgvSalary.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpSalaryMonth.Text = dgvSalary.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbDepartment.Text = dgvSalary.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBasic.Text = dgvSalary.Rows[e.RowIndex].Cells[4].Value.ToString();
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string u_EmpID = txtSearchEID.Text;

            try
            {
                con.Open();
                SqlCommand comn = new SqlCommand("SELECT * FROM [dbo].[Salary_Tb] WHERE (Emp_ID= '" + u_EmpID + "')", con);
                SqlDataReader reader;
                reader = comn.ExecuteReader();
                while (reader.Read())
                {
                    txtID.Text = reader.GetValue(0).ToString();
                    txtEName.Text = reader.GetValue(1).ToString();
                    dtpSalaryMonth.Text = reader.GetValue(2).ToString();
                    cmbDepartment.Text = reader.GetValue(3).ToString();
                    txtBasic.Text = reader.GetValue(4).ToString();
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
    }
}