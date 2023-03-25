using Fashion_House_Management_System.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fashion_House_Management_System.Presentation_Layer
{
    public partial class EmployeeManagement : Form
    {
        public string username;
        public int errorChecker=0;
        public EmployeeManagement()
        {
            InitializeComponent();
            
        }
        AdminDashboard adminDashboard;
        public EmployeeManagement(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
            this.username = adminDashboard.username;
        }

        private void EmployeeManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
       
        private void addEmployeeBbutton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if(errorChecker ==1)
            { }
            else
            {
                EmployeeService employeeService = new EmployeeService();
                int result = employeeService.AddNewEmployee(nameTextBox.Text, usernameTextBox.Text, Convert.ToInt32(phoneTextBox.Text), locationTextBox.Text, positionComboBox.Text, Convert.ToInt32(salaryTextBox.Text), branchComboBox.Text, joinDateTimePicker.Text);
                if (result > 0)
                {
                    MessageBox.Show("New employee added ");
                    UpdateListofEmployees();
                }
                else
                {
                    MessageBox.Show("Error in adding.");
                }
            }
            
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (username == "admin")
            {
                AdminDashboard adminDashboard = new AdminDashboard(this);
                this.Hide();
                adminDashboard.Show();
            }
        }

        private void EmployeeManagement_Load(object sender, EventArgs e)
        {
            if(username!="admin")
            { backButton.Visible = false; }

            EmployeeService employeeService = new EmployeeService();
            employeeManagementDataGridView.DataSource = employeeService.GetAllEmployees();
        }
        void UpdateListofEmployees()
        {
            EmployeeService employeeService = new EmployeeService();
            employeeManagementDataGridView.DataSource = employeeService.GetAllEmployees();
            idTextBox.Text= nameTextBox.Text=usernameTextBox.Text=phoneTextBox.Text=locationTextBox.Text=positionComboBox.Text=salaryTextBox.Text=branchComboBox.Text = string.Empty;
        }

        private void updateEmployeeButton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 0)
            { 
                EmployeeService employeeService = new EmployeeService();
                int result = employeeService.UpdateExistingEmployee(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, usernameTextBox.Text, Convert.ToInt32(phoneTextBox.Text), locationTextBox.Text, positionComboBox.Text, Convert.ToInt32(salaryTextBox.Text), branchComboBox.Text, joinDateTimePicker.Text);
                if (result > 0)
                {
                    MessageBox.Show("Employee updated successfully !!");
                    UpdateListofEmployees();
                }
                else
                {
                    MessageBox.Show("Error in updating.");
                }
            }
            else
            {
                
            }
        }

        private void employeeManagementDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTextBox.Text = employeeManagementDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = employeeManagementDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            usernameTextBox.Text = employeeManagementDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            phoneTextBox.Text = "0"+employeeManagementDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();    
            locationTextBox.Text = employeeManagementDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            positionComboBox.Text = employeeManagementDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            salaryTextBox.Text = employeeManagementDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            branchComboBox.Text = employeeManagementDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();

            //deleteCategoryIdTextBox.Text = categoryListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        public void inputValidation()//Call this function to check validity of inputs
        {
            if (nameTextBox.Text == "" || usernameTextBox.Text == "" || phoneTextBox.Text == "" || locationTextBox.Text == "" || positionComboBox.Text == "" || salaryTextBox.Text == "" || branchComboBox.Text == "")
            { MessageBox.Show("Enter all Informations!");
                errorChecker= 1;
            }
            else
            { errorChecker = 0;
                }
            if (errorChecker == 0)
            {
                try
                {
                    int p= Convert.ToInt32(phoneTextBox.Text);
                    int s =Convert.ToInt32(salaryTextBox.Text);
                    errorChecker = 0;
                }
                catch
                {
                    MessageBox.Show("Enter Valid Information");
                    errorChecker = 1;
                }
                if(errorChecker ==0)
                {
                    try
                    {
                            errorChecker = 1;
                        int n = Convert.ToInt32(nameTextBox.Text);
                        MessageBox.Show("Name can not be Empty!");
                    
                    }
                    catch { errorChecker = 0; }
                }
                
            }

        }

        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            int result = employeeService.DeleteEmployee(Convert.ToInt32(idTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Employee deleted successfully !!");
                UpdateListofEmployees();
            }
            else
            {
                MessageBox.Show("Error in deleting.");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            if (searchTextBox.Text == "")
            {
                MessageBox.Show("Enter Search Informations!");
            }
            else
            {
                string sql;
                try { int s = Convert.ToInt32(searchTextBox.Text);
                    sql = "SELECT * FROM Employees WHERE Phone = " + searchTextBox.Text;

                }
                catch {
                    
                sql = "SELECT * FROM Employees WHERE Username = '" + searchTextBox.Text+ "'";
                }

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    idTextBox.Text = reader["EId"].ToString();
                    nameTextBox.Text = reader["Name"].ToString();
                    usernameTextBox.Text = reader["Username"].ToString();
                    phoneTextBox.Text = reader["Phone"].ToString();
                    locationTextBox.Text = reader["Location"].ToString();
                    positionComboBox.Text = reader["Position"].ToString();
                    salaryTextBox.Text = reader["Salary"].ToString();
                    branchComboBox.Text = reader["Branch"].ToString();

                }
                else
                {
                    MessageBox.Show("Sorry, not found!");




                }




            }
                    //nameLabel.Text = reader["Name"].ToString();
                    



        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}