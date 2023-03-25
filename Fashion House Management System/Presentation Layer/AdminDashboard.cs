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
    public partial class AdminDashboard : Form
    {
        public string username="admin";///delete admin from username;
        public AdminDashboard()
        {
            InitializeComponent();
        }
        Categories categories;
        public AdminDashboard(Categories categories)
        {
            InitializeComponent();
            this.categories = categories;
            this.username = categories.username;
        }
        Customers customers;
        public AdminDashboard(Customers customers)
        {
            InitializeComponent();
            this.customers = customers;
            this.username = customers.username;
        }
        Products products;
        public AdminDashboard(Products products)
        {
            InitializeComponent();
            this.products = products;
            this.username = products.username;
        }
        EmployeeManagement employeeManagement;
        public AdminDashboard(EmployeeManagement employeeManagement)
        {
            InitializeComponent();
            this.employeeManagement = employeeManagement;
            this.username = employeeManagement.username;
        }
        Suppliers suppliers;
        public AdminDashboard(Suppliers suppliers)
        {
            InitializeComponent();
            this.suppliers = suppliers;
            this.username = suppliers.username;
        }
        
        WareHouse wareHouse;
        public AdminDashboard(WareHouse wareHouse)
        {
            InitializeComponent();
            this.wareHouse = wareHouse;
            this.username = wareHouse.username;
        }



        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeManagement employeeManagement = new EmployeeManagement(this);
            this.Hide();
            employeeManagement.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers(this);
            this.Hide();
            customers.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers(this);
            this.Hide();
            suppliers.Show();
        }

        

        private void wareHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WareHouse wareHouse = new WareHouse(this);
            this.Hide();
            wareHouse.Show();

        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories(this);
            this.Hide();
            categories.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products products = new Products(this);
            this.Hide();
            products.Show();

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales(this);
            this.Hide();
            sales.Show();
        }
    }
}
