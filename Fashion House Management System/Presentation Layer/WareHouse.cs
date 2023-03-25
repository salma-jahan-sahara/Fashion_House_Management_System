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
    public partial class WareHouse : Form
    {
        
        public int errorChecker = 0;
        public WareHouse()
        {
            InitializeComponent();
        }
        public string username;
        AdminDashboard adminDashboard;
        public WareHouse(AdminDashboard adminDashboard)
        {

            InitializeComponent();
            this.adminDashboard = adminDashboard;
            this.username = adminDashboard.username;
        }

        private void WareHouse_FormClosing(object sender, FormClosingEventArgs e)
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

        private void WareHouse_Load(object sender, EventArgs e)
        {
            if (username != "admin")
            { backButton.Visible = false; }

            WareHouseService wareHouseService = new WareHouseService();
            wareHouseDataGridView.DataSource = wareHouseService.GetAllWareHouses();

        }
        void UpdateListofWareHouses() 
        {
            WareHouseService wareHouseService = new WareHouseService();
            wareHouseDataGridView.DataSource = wareHouseService.GetAllWareHouses();
            idTextBox.Text = nameTextBox.Text = locationTextBox.Text = phoneTextBox.Text = searchTextBox.Text = string.Empty;
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
                    sql = "SELECT * FROM WareHouses WHERE Phone = " + searchTextBox.Text;

                }
                catch
                {

                    sql = "SELECT * FROM Employees WHERE WarehouseName = '" + searchTextBox.Text + "'";
                }

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    nameTextBox.Text = reader["WarehouseName"].ToString();
                    phoneTextBox.Text = reader["Phone"].ToString();
                    locationTextBox.Text = reader["Location"].ToString();

                }
                else
                {
                    MessageBox.Show("Sorry, not found!");

                }

            }

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public string id;
        private void wareHouseDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTextBox.Text = wareHouseDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = wareHouseDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            locationTextBox.Text = wareHouseDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            phoneTextBox.Text = wareHouseDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
        }


        private void addEmployeeBbutton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 1)
            { }
            else
            {
                WareHouseService wareHouseService = new WareHouseService();
                int result = wareHouseService.AddNewWareHouse(nameTextBox.Text, locationTextBox.Text, Convert.ToInt32(phoneTextBox.Text));
                if (result > 0)
                {
                    MessageBox.Show("New warehouse added ");
                    UpdateListofWareHouses();
                }
                else
                {
                    MessageBox.Show("Error in adding.");
                }
            }
        }
        public void inputValidation()
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

        private void updateWareHouseButton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 0)
            { 
                WareHouseService wareHouseService = new WareHouseService();
                int result = wareHouseService.UpdateExistingWareHouse(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, locationTextBox.Text, Convert.ToInt32(phoneTextBox.Text));
                if (result > 0)
                {
                    MessageBox.Show("Warehouse updated successfully !!");
                    UpdateListofWareHouses();
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

        private void deleteWareHouseButton_Click(object sender, EventArgs e)
        {
            WareHouseService wareHouseService = new WareHouseService();
            int result = wareHouseService.DeleteWareHouse(Convert.ToInt32(idTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Ware House deleted successfully !!");
                UpdateListofWareHouses();
            }
            else
            {
                MessageBox.Show("Error in deleting.");
            }
        }
    }
    
}
