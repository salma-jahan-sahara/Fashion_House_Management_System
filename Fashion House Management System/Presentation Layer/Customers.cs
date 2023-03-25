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
    public partial class Customers : Form
    {
        public string username;
        public int errorChecker = 0;
        public Customers()
        {
            InitializeComponent();
        }
        AdminDashboard adminDashboard;
        public Customers(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
            this.username = adminDashboard.username;
        }

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void Customers_Load(object sender, EventArgs e)
        {
            if (username != "admin")
            { backButton.Visible = false; }
            CustomerService customerService = new CustomerService();
            customerDataGridView.DataSource = customerService.GetAllCustomers();
        }
        void UpdateListofCustomers()
        {
            CustomerService customerService = new CustomerService();
            customerDataGridView.DataSource = customerService.GetAllCustomers();
            idTextBox.Text = nameTextBox.Text = phoneTextBox.Text = locationTextBox.Text = string.Empty;
        }

        private void addCustomerBbutton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 1)
            { }
            else
            {
                CustomerService customerService = new CustomerService();
                int result = customerService.AddNewCustomer(nameTextBox.Text, Convert.ToInt32(phoneTextBox.Text), locationTextBox.Text, joinDateTimePicker.Text);
                if (result > 0)
                {
                    MessageBox.Show("New customer added ");
                    UpdateListofCustomers();
                }
                else
                {
                    MessageBox.Show("Error in adding.");
                }
            }
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 0)
            {
                CustomerService customerService = new CustomerService();
                int result = customerService.UpdateExistingCustomer(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, Convert.ToInt32(phoneTextBox.Text), locationTextBox.Text, joinDateTimePicker.Text);
                if (result > 0)
                {
                    MessageBox.Show("Employee updated successfully !!");
                    UpdateListofCustomers();
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

        private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            phoneTextBox.Text = "0" + customerDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            locationTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        public void inputValidation()//Call this function to check validity of inputs
        {
            if (nameTextBox.Text == "" || phoneTextBox.Text == "" || locationTextBox.Text == "")
            {
                MessageBox.Show("Enter all Informations!");
                errorChecker = 1;
            }
            else
            {
                errorChecker = 0;
            }
            if (errorChecker == 0)
            {
                try
                {
                    int p = Convert.ToInt32(phoneTextBox.Text);
                    errorChecker = 0;
                }
                catch
                {
                    MessageBox.Show("Enter Valid Information");
                    errorChecker = 1;
                }
                if (errorChecker == 0)
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

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerService customerService = new CustomerService();
            int result = customerService.DeleteCustomer(Convert.ToInt32(idTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Customer deleted successfully !!");
                UpdateListofCustomers();
            }
            else
            {
                MessageBox.Show("Error in deleting.");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            /*CustomerService customerService = new CustomerService();
            int result = customerService.SearchCustomer( Convert.ToInt32(searchTextBox.Text));//better to try catch
            if (result > 0)
            {
                //MessageBox.Show("New customer added ");
                nameTextBox.Text = "got it";
                UpdateListofCustomers();
            }
            else
            {
                UpdateListofCustomers();
                nameTextBox.Text = "didnot found";
                MessageBox.Show("Phone number not found.");
            }*/


            if (searchTextBox.Text == "")
            {
                MessageBox.Show("Enter Search Informations!");
            }
            else
            {
                string sql;
                try
                {
                    int s = Convert.ToInt32(searchTextBox.Text);
                    sql = "SELECT * FROM Customers WHERE Phone = " + searchTextBox.Text;

                }
                catch
                {

                    sql = "SELECT * FROM Customers WHERE Name = '" + searchTextBox.Text + "'";
                }

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    nameTextBox.Text = reader["Name"].ToString();
                    phoneTextBox.Text = reader["Phone"].ToString();
                    idTextBox.Text = reader["CId"].ToString();
                    locationTextBox.Text = reader["Location"].ToString();


                }
                else
                {
                    MessageBox.Show("Sorry, not found!");
                }
            }
        }
    }
}
