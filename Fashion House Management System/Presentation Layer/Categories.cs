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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        public string username;
        AdminDashboard adminDashboard;
        public Categories(AdminDashboard adminDashboard)
        {

            InitializeComponent();
            this.adminDashboard = adminDashboard;
            this.username = adminDashboard.username;
        }

        private void Categories_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Categories_Load(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            categoryListDataGridView.DataSource = categoryService.GetAllCategories();

            if (username != "admin") // initiaize psition
            { backButton.Visible = false; }

        }
        void UpdateListofCategories()
        {
            CategoryService categoryService = new CategoryService();
            categoryListDataGridView.DataSource = categoryService.GetAllCategories();
            addCategoryNameTextBox.Text = updateCategoryNameTextBox.Text = updateCategoryIdTextBox.Text = deleteCategoryIdTextBox.Text = string.Empty; // Text box e lekha theke jay, ota remove korte
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            int result = categoryService.AddNewCategory(addCategoryNameTextBox.Text);
            if (result > 0)
            {
                MessageBox.Show("New category added ");
                UpdateListofCategories();
            }
            else
            {
                MessageBox.Show("Error in adding.");
            }
        }

        private void categoryListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateCategoryIdTextBox.Text = categoryListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateCategoryNameTextBox.Text = categoryListDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

            deleteCategoryIdTextBox.Text = categoryListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            int result = categoryService.UpdateExistingCategory(Convert.ToInt32(updateCategoryIdTextBox.Text), updateCategoryNameTextBox.Text);
            if (result > 0)
            {
                MessageBox.Show("Category updated successfully !!");
                UpdateListofCategories();
            }
            else
            {
                MessageBox.Show("Error in updating.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            int result = categoryService.DeleteCategory(Convert.ToInt32(deleteCategoryIdTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Category deleted successfully !!");
                UpdateListofCategories();
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
                try
                {
                    int s = Convert.ToInt32(searchTextBox.Text);
                    sql = "SELECT * FROM Categoriess WHERE CaId = " + searchTextBox.Text;

                }
                catch
                {

                    sql = "SELECT * FROM Categories WHERE CategoryName = '" + searchTextBox.Text + "'";
                }

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    updateCategoryNameTextBox.Text = reader["CategoryName"].ToString();
                    
                    updateCategoryIdTextBox.Text = reader["CaId"].ToString();
                   

                }
                else
                {
                    MessageBox.Show("Sorry, not found!");
                }
            }
        }
    }
}