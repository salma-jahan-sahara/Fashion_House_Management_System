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

    public partial class Products : Form
    {
        public int errorChecker = 0;
        public Products()
        {
            InitializeComponent();
        }
        
        public string username;
        AdminDashboard adminDashboard;
        public Products(AdminDashboard adminDashboard)
        {

            InitializeComponent();
            this.adminDashboard = adminDashboard;
            this.username = adminDashboard.username;
        }

        private void Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        /*private void logOutButton_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }*/

        private void backButton_Click(object sender, EventArgs e)
        {
            if (username == "admin")
            {
                AdminDashboard adminDashboard = new AdminDashboard(this);
                this.Hide();
                adminDashboard.Show();
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            ProductService productService = new ProductService();
            productListDataGridView.DataSource = productService.GetAllProducts();
            CategoryService categoryService = new CategoryService();
            productCategoryComboBox.DataSource = categoryService.GetCategoryNames();

            if (username != "admin")
            { backButton.Visible = false; }

            /*if (productManagement.ButtonType == 2)//edit
            {
                addProductButton.Visible = false;
                deleteButton.Visible = false;
                updateButton.Visible = true;
            }
            else if (productManagement.ButtonType == 3)//delete
            { 
                addProductButton.Visible = false;
                deleteButton.Visible = true;
                updateButton.Visible = false;
            }
            else//add by default
            {
                addProductButton.Visible = true;
                deleteButton.Visible = false;
                updateButton.Visible = false;
            }*/

        }


        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            selectProductPictureLabel.Text = openFileDialog.FileName;
            addPhotosPictureBox.ImageLocation = selectProductPictureLabel.Text;
        }
        void UpdateListofProducts()
        {
            ProductService productService = new ProductService();
            productListDataGridView.DataSource = productService.GetAllProducts();
            productIdTextBox.Text = productNameTextBox.Text = stockTextBox.Text = retailPriceTextBox.Text = wholeSellPriceTextBox.Text = productCategoryComboBox.Text = productDetailsTextBox.Text = string.Empty;
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (errorChecker == 1)
            { }
            else
            {
                ProductService productService = new ProductService();
                int result = productService.AddNewProduct(productNameTextBox.Text, Convert.ToInt32(stockTextBox.Text),  Convert.ToDouble(retailPriceTextBox.Text), Convert.ToDouble(wholeSellPriceTextBox.Text), productDetailsTextBox.Text, selectProductPictureLabel.Text, productCategoryComboBox.Text);
                if (result > 0)
                {
                    MessageBox.Show("New product added ");
                    UpdateListofProducts();
                }
                else
                {
                    MessageBox.Show("Error in adding.");
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            inputValidation();
            if (errorChecker == 1)
            { }
            else
            {
                ProductService productService = new ProductService();
                int result = productService.UpdateExistingProduct(Convert.ToInt32(productIdTextBox.Text), productNameTextBox.Text, Convert.ToInt32(stockTextBox.Text), Convert.ToDouble(retailPriceTextBox.Text), Convert.ToDouble(wholeSellPriceTextBox.Text), productDetailsTextBox.Text, selectProductPictureLabel.Text, productCategoryComboBox.Text);
                if (result > 0)
                {
                    MessageBox.Show("New product updated ");
                    UpdateListofProducts();
                }
                else
                {
                    MessageBox.Show("Error in update.");
                }
            }

        }
        public void inputValidation()
        {
            if (productNameTextBox.Text == "" || stockTextBox.Text == "" || retailPriceTextBox.Text == "" || wholeSellPriceTextBox.Text == "" || productCategoryComboBox.Text == "" || productDetailsTextBox.Text == "")
            {
                MessageBox.Show("Enter all Informations!");
                errorChecker = 1;
            }
            else
            {
                errorChecker = 0;
            }
        }

        private void productListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            productIdTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            productNameTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            stockTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            retailPriceTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            wholeSellPriceTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            productDetailsTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            selectProductPictureLabel.Text = productListDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            productCategoryComboBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
            addPhotosPictureBox.ImageLocation = productListDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ProductService productService = new ProductService();
            int result = productService.DeleteProduct(Convert.ToInt32(productIdTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Product deleted successfully !!");
                UpdateListofProducts();
            }
            else
            {
                MessageBox.Show("Error in deleting.");
            }
        }

        private void productLogoutButton_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            if (username == "admin")
            {
                AdminDashboard adminDashboard = new AdminDashboard(this);
                this.Hide();
                adminDashboard.Show();
            }
            else
            {
                backButton.Visible = false;
            }
        }

        private void productCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
