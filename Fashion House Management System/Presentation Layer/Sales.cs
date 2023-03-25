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
    public partial class Sales : Form
    {
        public string username;
        private List<Image> LoadedImages { get; set; }
        

        public int[] productIdArray = new int[100];
        public string[] productName = new string[100];
        public string[] productDetails = new string[100];
        public string[] productPrice = new string[100];

        public string[] productCategory = new string[100];
        public int[] productStock = new int[100];
        public int[] productList = new int[100];
        public int[] selectedProductPrice = new int[100];
        public string[] selectedProductName = new string[100];
        public string date;

        int arr = 0;
        public Sales()
        {
            InitializeComponent();
        }
        Invoice invoice;
        public Sales(Invoice invoice)
        {
            InitializeComponent();
            this.invoice = invoice;
            username = invoice.username;
        }

        private void Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        AdminDashboard adminDashboard;
        public Sales(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
            username = adminDashboard.username;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            if (username == "admin")
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                this.Hide();
                adminDashboard.Show();
            }
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            if (username != "admin")
            {
                backButton.Visible = false;
            }
            LoadImagesFromFolder();
            ImageList images = new ImageList();

            foreach (var image in LoadedImages)
            {
                images.Images.Add(image);
            }
            pictureEventsListView.LargeImageList = images;
            for (int itemIndex = 1; itemIndex <= LoadedImages.Count; itemIndex++)
                pictureEventsListView.Items.Add(new ListViewItem($"Image {itemIndex}", itemIndex - 1));
        }
        private void LoadImagesFromFolder()
        {

            LoadedImages = new List<Image>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
            string sql = "SELECT * from Products";// Where CategoryName='" + comboBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {

                while (reader.Read())
                {
                    var tempLocation = reader["ProductPhotoLocation"].ToString();
                    var tempImage = Image.FromFile(tempLocation);
                    LoadedImages.Add(tempImage);
                    /* public int[] productIdArray = new int[100];
                     public string[] productName = new string[100];
                     public string[] productDetails = new string[100];
                     public string[] productPrice = new string[100];
                     public string[] productStock = new string[100];*/
                    productIdArray[arr] = Convert.ToInt32(reader["PId"].ToString());
                    productName[arr] = reader["ProductName"].ToString();
                    productDetails[arr] = reader["ProductDetails"].ToString();
                    productPrice[arr] = reader["RetailPrice"].ToString();
                    //productCategory[arr] = reader["CategoryName"].ToString();
                    productStock[arr] = Convert.ToInt32(reader["Stock"]);
                    arr++;
                }
                arr = 0;//////////////delete this, if any serial problem
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }

        private void pictureEventsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureEventsListView.SelectedIndices.Count > 0)
            {
                /*int x=0;
                while(productCategory[x]==comboBox1.Text)
                {*/
                var selectedIndex = pictureEventsListView.SelectedIndices[0];
                Image selectedImg = LoadedImages[selectedIndex];
                productNameLabel.Text = productName[selectedIndex];
                productIdLabel.Text = productIdArray[selectedIndex].ToString();
                productList[productIdArray[selectedIndex]] = Convert.ToInt32(quantityNumericUpDown.Value);
                detailsLabel.Text = productDetails[selectedIndex];
                amountPriceLabel.Text = productPrice[selectedIndex];
                eventNamePictureBox.Image = selectedImg;
                totalLabel.Text = (Convert.ToInt32( amountPriceLabel.Text)*quantityNumericUpDown.Value).ToString();
                // x++;
                // }
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (idLabel.Text=="")
            {
                MessageBox.Show("Enter added customer's phone or name!");
            }
            else
            {
                string sql= "INSERT INTO Invoices (CId, PurchaseDate, CustomerName, CustomerPhone, CustomerLocation) VALUES('"+idLabel.Text+"', '"+dateTimePicker.Value+"', '"+nameLebel.Text+"', '"+phoneLabel.Text+"', '"+ locationLabel.Text+ "')"; 
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Confirmed!");

                    Invoice invoice = new Invoice(this);
                    this.Hide();
                    invoice.Show();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                connection.Close();



                //Array.Clear(productList, 0, productList.Length);

            }
            

            
        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            if(productIdLabel.Text=="ID")
            {
                MessageBox.Show("Select an item");
            }
            else {
                productList[Convert.ToInt32(productIdLabel.Text)] = Convert.ToInt32(quantityNumericUpDown.Value);
                selectedProductName[Convert.ToInt32(productIdLabel.Text)] = productNameLabel.Text;
                selectedProductPrice[Convert.ToInt32(productIdLabel.Text)] = Convert.ToInt32(amountPriceLabel.Text);
                quantityNumericUpDown.Value = 1;
                MessageBox.Show("Product added");
            }
            
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (productIdLabel.Text == "ID")
            {
                MessageBox.Show("Select an item");
            }
            else
            {
                productList[Convert.ToInt32(productIdLabel.Text)] = 0;
                MessageBox.Show(productNameLabel.Text + " removed!");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                MessageBox.Show("Enter Search Informations!");
                nameLebel.Text = " ";
                phoneLabel.Text = "";
                idLabel.Text = "";
                locationLabel.Text = "";
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

                    nameLebel.Text = reader["Name"].ToString();
                    phoneLabel.Text = reader["Phone"].ToString();
                    idLabel.Text = reader["CId"].ToString();
                    locationLabel.Text = reader["Location"].ToString();


                }
                else
                {
                    MessageBox.Show("Sorry, not found!");
                    nameLebel.Text = "";
                    phoneLabel.Text = "";
                    idLabel.Text = "";
                    locationLabel.Text = "";
                }
            }
            }

        private void quantityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            totalLabel.Text = (quantityNumericUpDown.Value * Convert.ToInt32(amountPriceLabel.Text)).ToString();
        }
        /*public void fillComboBox() // form load e call korte hobe
{
SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
string sql = "SELECT * from Categories";
SqlCommand command = new SqlCommand(sql, connection);
connection.Open();
SqlDataReader reader = command.ExecuteReader();
try
{

while (reader.Read())
{
categoryList = reader["CategoryName"].ToString();
existingComboBox.Items.Add(categoryList);

}
}
catch (Exception ex)
{
MessageBox.Show(ex.Message);
}
}*/
    }
}
