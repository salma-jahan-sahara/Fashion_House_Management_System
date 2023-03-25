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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }
        
        public string username;
        public int[] productList = new int[100];
        public SqlCommand command1;
        public int[] selectedProductPrice = new int[100];
        public string[] selectedProductName = new string[100];
        public string cid;
        public string cName;
        public string cPhone;
        public string cLocation;
        public string date;
        public string inv;
        public int subtotal;

        Sales sales;
        public Invoice(Sales sales)
        {
            
            InitializeComponent();
            this.sales = sales;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM Invoices WHERE PurchaseDate='" + sales.dateTimePicker.Value+"' AND CId="+sales.idLabel.Text;
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                inv = reader["InvoiceId"].ToString();
                invoceLabel.Text += inv;
                cid = reader["CId"].ToString();
                cName = reader["CustomerName"].ToString();
                cPhone = reader["CustomerPhone"].ToString();
                cLocation = reader["CustomerLocation"].ToString();
                orderDateLabel.Text = reader["PurchaseDate"].ToString();
            }
            else
            {
                MessageBox.Show("Something Wrong!");
                
            }
            connection.Close();
            username = sales.username;
            customerLabel.Text = cName + "\n" + cPhone + "\n" + cLocation;
            string sql1;
            
            SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
            connection1.Open();
            int result1;
            for (int i = 0; i < 100; i++)//id
            {
               
                productList[i] = sales.productList[i];
                selectedProductPrice[i] = sales.selectedProductPrice[i];
                selectedProductName[i] = sales.selectedProductName[i];
                sql1 = "INSERT INTO InvoiceDetails ( ProductName, ProductQuantity, ProductPrice, UnitPrice, InvoiceId) VALUES" +
                    "('"+ selectedProductName[i] + "', '" + productList[i] + "', '" + selectedProductPrice[i]* productList[i] +
                    "', '" + selectedProductPrice[i] + "', '" + inv + "')";

                this.command1 = new SqlCommand(sql1, connection1);//may be error for datatype
                //SqlCommand.command1(sql1, connection1);
                result1 = command1.ExecuteNonQuery();
                if (result1 > 0)
                {
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
                
            }
            
            connection1.Close();
            
            
        }
        public int[] productPrice = new int[100];


        private void Invoice_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)//id
            {
                if (productList[i] != 0)
                {
                    idLabel.Text += "\n" + i.ToString();
                    pricelabel.Text += "\n" + selectedProductPrice[i].ToString();
                    quantityLabel.Text += "\n" + productList[i].ToString();
                    totalPriceLabel.Text += "\n" + (Convert.ToInt32(selectedProductPrice[i]) * Convert.ToInt32(productList[i])).ToString();
                    subtotal += Convert.ToInt32(selectedProductPrice[i]) * Convert.ToInt32(productList[i]);
                    nameLabel.Text += "\n" + selectedProductName[i];
                }

            }

            subtotalLabel.Text = subtotal.ToString();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }

        private void Invoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales(this);
            this.Hide();
            sales.Show();
        }
    }
}
