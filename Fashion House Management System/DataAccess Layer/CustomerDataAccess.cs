using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fashion_House_Management_System.DataAccess_Layer
{
    class CustomerDataAccess: DataAccessLayer
    {
        public int phone;
        public List<Customer> GetCustomers()
        {
            string sql = "SELECT * FROM Customers";
            SqlDataReader reader = this.GetData(sql);
            List<Customer> customers = new List<Customer>();
            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.CId = Convert.ToInt32(reader["CId"]);
                customer.Name = reader["Name"].ToString();
                customer.Phone = Convert.ToInt32(reader["Phone"]);
                customer.Location = reader["Location"].ToString();
                customer.JoinedDate = reader["JoinedDate"].ToString();
                customers.Add(customer);
            }
            return customers;
        }
        public Customer GetCustomer(int id)
        {
            string sql = "SELECT * FROM Customers WHERE CId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Customer customer = new Customer();
                customer.CId = Convert.ToInt32(reader["CId"]);
                customer.Name = reader["Name"].ToString();
                customer.Phone = Convert.ToInt32(reader["Phone"]);
                customer.Location = reader["Location"].ToString();
                customer.JoinedDate = reader["JoinedDate"].ToString();
                return customer;
            }
            return null;
        }
        public int AddCustomer(Customer customer)
        {

            try
            {
                phone = Convert.ToInt32(customer.Phone);
            }
            catch
            {
                MessageBox.Show("Enter Phone number in correct format !!");
            }
            
            string sql = "INSERT INTO Customers(Name, Phone, Location, JoinedDate) " +
                         "VALUES('" + customer.Name + "', " + phone +
                         ", '" + customer.Location + "','" + customer.JoinedDate + "')";
            return this.ExecuteQuery(sql);
        }
        public int UpdateCustomer(Customer customer)
        {
            string sql = "UPDATE Customers SET Name='" + customer.Name + "', Phone=" + customer.Phone + ", JoinedDate='" + customer.JoinedDate + "' WHERE CId=" + customer.CId;
            return this.ExecuteQuery(sql);
        }
        public int SearchCustomer(Customer customer)
        {
            string sql = "SELECT * FROM Customers Where Phone=" + customer.Phone;
               
            return this.ExecuteQuery(sql);
        }
        public int DeleteCustomer(int id)
        {
            string sql = "DELETE FROM Customers WHERE CId=" + id;
            return this.ExecuteQuery(sql);
        }

        public int GetCustomerId(string name)
        {
            string sql = "SELECT CId FROM Customers WHERE CustomerName='" + name + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["CId"]);
            }
            return -1;
        }
        public List<string> GetCustomersNames()
        {
            string sql = "SELECT CustomerName FROM Customers";
            SqlDataReader reader = this.GetData(sql);
            List<string> customerNames = new List<string>();
            while (reader.Read())
            {
                customerNames.Add(reader["CustomerName"].ToString());
            }
            return customerNames;
        }
    }
}
