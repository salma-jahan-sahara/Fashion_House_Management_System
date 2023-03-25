using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer
{
    class ProductDataAccess : DataAccessLayer
    {
        public List<Product> GetProducts()
        {
            string sql = "SELECT * FROM Products";
            SqlDataReader reader = this.GetData(sql);
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();
                product.PId = Convert.ToInt32(reader["PId"]);
                product.ProductName = reader["ProductName"].ToString();
                product.Stock = Convert.ToInt32(reader["Stock"]);
                product.RetailPrice = Convert.ToDouble(reader["RetailPrice"]);
                product.WholesalePrice = Convert.ToDouble(reader["WholesalePrice"]);
                product.ProductDetails = reader["ProductDetails"].ToString();
                product.ProductPhotoLocation = reader["ProductPhotoLocation"].ToString();
                product.CaId = Convert.ToInt32(reader["CaId"]);

                products.Add(product);
            }
            return products;
        }
        public Product GetProduct(int id)
        {
            string sql = "SELECT * FROM Products WHERE PId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Product product = new Product();
                product.PId = Convert.ToInt32(reader["PId"]);
                product.ProductName = reader["ProductName"].ToString();
                product.Stock = Convert.ToInt32(reader["Stock"]);
                product.RetailPrice = Convert.ToDouble(reader["RetailPrice"]);
                product.WholesalePrice = Convert.ToDouble(reader["WholesalePrice"]);
                product.ProductDetails = reader["ProductDetails"].ToString();
                product.ProductPhotoLocation = reader["ProductPhotoLocation"].ToString();
                product.CaId = Convert.ToInt32(reader["CaId"]);
                return product;
            }
            return null;
        }
        public int AddProduct(Product product)
        {
            string sql = "INSERT INTO Products(ProductName,Stock,RetailPrice,WholesalePrice,ProductDetails,ProductPhotoLocation,CaId) VALUES('" + product.ProductName + "'," + product.Stock + "," + product.RetailPrice + "," + product.WholesalePrice + ",'" + product.ProductDetails + "','" + product.ProductPhotoLocation + "'," + product.CaId + ")";
            
            return this.ExecuteQuery(sql);

        }

        public int UpdateProduct(Product product)
        {
            string sql = "UPDATE Products SET ProductName='" + product.ProductName + "',Stock=" + product.Stock + ", RetailPrice=" + product.RetailPrice + ",WholesalePrice=" + product.WholesalePrice + ",  ProductDetails='" + product.ProductDetails + "',ProductPhotoLocation='" + product.ProductPhotoLocation + "', CaId=" + product.CaId + " WHERE PId=" + product.PId;
            return this.ExecuteQuery(sql);
        }
        public int DeleteProduct(int id)
        {
            string sql = "DELETE FROM Products WHERE PId=" + id;
            return this.ExecuteQuery(sql);
        }
        /*public List<Product> GetProductsByCategoryId(int categoryId)
        {
            string sql = "SELECT * FROM Products WHERE CategoryId=" + categoryId;
            SqlDataReader reader = this.GetData(sql);
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.PId = Convert.ToInt32(reader["PId"]);
                products.ProductName = reader["ProductName"].ToString();
                products.Stock = Convert.ToInt32(reader["Stock"]);
                product.RetailPrice = Convert.ToDouble(reader["RetailPrice"]);
                product.WholesalePrice = Convert.ToDouble(reader["WholesalePrice"]);
                product.ProductDetails = reader["ProductDetails"].ToString();
                product.ProductPhotoLocation = reader["ProductPhotoLocation"].ToString();
                product.CaId = Convert.ToInt32(reader["CaId"]);
            }
            //category wise product list
            return products;
        }*/
    }
}
