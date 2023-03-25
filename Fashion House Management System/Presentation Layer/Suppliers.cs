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
    public partial class Suppliers : Form
    {
        public string username;
        public int errorChecker = 0;
        public Suppliers()
        {
            InitializeComponent();
        }
        AdminDashboard adminDashboard;
        public Suppliers(AdminDashboard adminDashboard)
        {

            InitializeComponent();
            this.adminDashboard = adminDashboard;
            this.username = adminDashboard.username;
        }

        private void Suppliers_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Suppliers_Load(object sender, EventArgs e)
        {
            if (username != "admin")
            { backButton.Visible = false; }
            SupplierService supplierService = new SupplierService();
            supplierDataGridView.DataSource = supplierService.GetAllSuppliers();
        }
        void UpdateListofEmployees()
        {
            SupplierService supplierService = new SupplierService();
            supplierDataGridView.DataSource = supplierService.GetAllSuppliers();
            nameTextBox.Text = phoneTextBox.Text = locationTextBox.Text = companyNameTextBox.Text = warehouseComboBox.Text = string.Empty;
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
                try
                {
                    int s = Convert.ToInt32(searchTextBox.Text);
                    sql = "SELECT * FROM Suppliers WHERE Phone = " + searchTextBox.Text;
                }
                catch
                {
                    sql = "SELECT * FROM Suppliers WHERE CompanyName = '" + searchTextBox.Text + "'";
                }

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    nameTextBox.Text = reader["Name"].ToString();
                    phoneTextBox.Text = reader["Phone"].ToString();
                    companyNameTextBox.Text= reader["CompanyName"].ToString();
                    locationTextBox.Text = reader["Location"].ToString();
                    warehouseComboBox.Text=reader["Wid"].ToString();

                }
                else
                {
                    //MessageBox.Show("Sorry, not found!");
                    //////////////////If any error, delete below codes in else and uncomment upper messagebox////////////////////////////

                    SqlConnection connections = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                    connection.Open();
                    sql = "SELECT * FROM Suppliers WHERE Name = '" + searchTextBox.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader readers = command.ExecuteReader();
                    if (reader.Read())
                    {

                        nameTextBox.Text = reader["Name"].ToString();
                        phoneTextBox.Text = reader["Phone"].ToString();
                        companyNameTextBox.Text = reader["CompanyName"].ToString();
                        locationTextBox.Text = reader["Location"].ToString();
                        warehouseComboBox.Text = reader["Wid"].ToString();//id to name transfer kora better

                    }
                    else
                    {
                        MessageBox.Show("Sorry, not found!");

                    }

                }

            }

        }

        private void addEmployeeBbutton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 1)
            { }
            else
            {
                SupplierService supplierService = new SupplierService();
                //string name, int phone, string location, string companyName, string joinedDate, string warehouseName
                int result = supplierService.AddNewSupplier(nameTextBox.Text, Convert.ToInt32(phoneTextBox.Text),locationTextBox.Text, companyNameTextBox.Text, joinDateTimePicker.Text, warehouseComboBox.Text);
                if (result > 0)
                {
                    MessageBox.Show("New supplier added ");
                    UpdateListofEmployees();
                }
                else
                {
                    MessageBox.Show("Error in adding.");
                }
            }
             void inputValidation()
            {
                if (nameTextBox.Text == "" || phoneTextBox.Text == "" || locationTextBox.Text == "" || companyNameTextBox.Text == "" || joinDateTimePicker.Text == "" || warehouseComboBox.Text == "")
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
                        //int s = Convert.ToInt32(salaryTextBox.Text);
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
        }

        private void updateEmployeeButton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 0)
            {
                SupplierService supplierService = new SupplierService();
                int result = supplierService.UpdateExistingSupplier(nameTextBox.Text, Convert.ToInt32(phoneTextBox.Text), locationTextBox.Text, companyNameTextBox.Text, joinDateTimePicker.Text, warehouseComboBox.Text);
                
                if (result > 0)
                {
                    MessageBox.Show("Supplier updated successfully !!");
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
        private void inputValidation()
        {
            throw new NotImplementedException();
        }

        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            SupplierService supplierService = new SupplierService();
            int result = supplierService.DeleteSupplier(Convert.ToInt32(idTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Supplier deleted successfully !!");
                UpdateListofEmployees();
            }
            else
            {
                MessageBox.Show("Error in deleting.");
            }

        }

        private void supplierDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTextBox.Text = supplierDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = supplierDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            phoneTextBox.Text = "0" + supplierDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            locationTextBox.Text = supplierDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            companyNameTextBox.Text = supplierDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            joinDateTimePicker.Text = supplierDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            warehouseComboBox.Text = supplierDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
