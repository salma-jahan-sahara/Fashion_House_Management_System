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
    class SupplierDataAccess: DataAccessLayer
    {
        public int phone;
        public List<Supplier> GetSuppliers()
        {
            string sql = "SELECT * FROM Suppliers";
            SqlDataReader reader = this.GetData(sql);
            List<Supplier> suppliers = new List<Supplier>();
            while (reader.Read())
            {
                Supplier supplier = new Supplier();
                supplier.SId = Convert.ToInt32(reader["SId"]);
                supplier.Name = reader["Name"].ToString();
                supplier.Phone = Convert.ToInt32(reader["Phone"]);
                supplier.Location = reader["Location"].ToString();
                supplier.CompanyName = reader["CompanyName"].ToString();
                supplier.JoinedDate = reader["JoinedDate"].ToString();
                supplier.WId = Convert.ToInt32(reader["WId"]);

                suppliers.Add(supplier);
            }
            return suppliers;
        }
        public Supplier GetSupplier(int id) 
        {
            string sql = "SELECT * FROM Suppliers WHERE SId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Supplier supplier = new Supplier();
                supplier.SId = Convert.ToInt32(reader["SId"]);
                supplier.Name = reader["Name"].ToString();
                supplier.Phone = Convert.ToInt32(reader["Phone"]);
                supplier.Location = reader["Location"].ToString();
                supplier.CompanyName = reader["CompanyName"].ToString();
                supplier.JoinedDate = reader["JoinedDate"].ToString();
                supplier.WId = Convert.ToInt32(reader["WId"]);
                return supplier;
            }
            return null;
        }


        public int AddSupplier(Supplier supplier)
        {

            try
            {
                phone = Convert.ToInt32(supplier.Phone);
            }
            catch
            {
                MessageBox.Show("Enter Phone number in correct format !!");
            }
            
            string sql = "INSERT INTO Suppliers(Name, Phone, Location, CompanyName, JoinedDate, WId) " +
                         "VALUES('" + supplier.Name + "', " + phone +
                         ", '" + supplier.Location + "', '" + supplier.CompanyName + "','" + supplier.JoinedDate + "'," + supplier.WId + ")";
            return this.ExecuteQuery(sql);
        }

        public int UpdateSupplier(Supplier supplier)
        {
            string sql = "UPDATE Suppliers SET Name='" + supplier.Name + "', Phone=" + supplier.Phone + ", Location='" + supplier.Location + "', CompanyName='" + supplier.CompanyName + "', WId=" + supplier.WId + " WHERE SId=" + supplier.SId;
            return this.ExecuteQuery(sql);
        }
        public int DeleteSupplier(int id)
        {
            string sql = "DELETE FROM Suppliers WHERE SId=" + id;
            return this.ExecuteQuery(sql);
        }

        public int GetSupplierId(string name)
        {
            string sql = "SELECT SId FROM Suppliers WHERE SupplierName='" + name + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["SId"]);
            }
            return -1;
        }
        public List<string> GetSuppliersNames()
        {
            string sql = "SELECT SupplierName FROM Suppliers";
            SqlDataReader reader = this.GetData(sql);
            List<string> supplierNames = new List<string>();
            while (reader.Read())
            {
                supplierNames.Add(reader["SupplierName"].ToString());
            }
            return supplierNames;
        }
    }
}
