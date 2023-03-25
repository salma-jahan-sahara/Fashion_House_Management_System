using Fashion_House_Management_System.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fashion_House_Management_System.Presentation_Layer
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void logInbutton_Click(object sender, EventArgs e)
        {
            LoginService loginService = new LoginService();
            string result = loginService.LoginValidation(usernameTextBox.Text, passwordTextBox.Text);
            if (result == "Admin")
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                this.Hide();
                adminDashboard.Show();
            }
            else if (result == "EmpManager")
            {
                EmployeeManagement employeeManagement = new EmployeeManagement();
                this.Hide();
                employeeManagement.Show();
            }
            else if (result == "CusManager")
            {
                Customers customers = new Customers();
                this.Hide();
                customers.Show();
            }
            else if (result == "SupManager")
            {
                Suppliers suppliers = new Suppliers();
                this.Hide();
                suppliers.Show();
            }
            else if (result == "WarManager")
            {
                WareHouse wareHouse = new WareHouse();
                this.Hide();
                wareHouse.Show();
            }
            else if (result == "CatManager")
            {
                Categories categories = new Categories();
                this.Hide();
                categories.Show();
            }
            else if (result == "ProManager")
            {
                Products products = new Products();
                this.Hide();
                products.Show();
            }
            else if (result == "SalManager")
            {
                Sales sales = new Sales();
                this.Hide();
                sales.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
