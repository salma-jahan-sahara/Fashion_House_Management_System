using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer
{
    class CategoryDataAccess:DataAccessLayer
    {
        public List<Category> GetCategories() 
        {
            string sql = "SELECT * FROM Categories";
            SqlDataReader reader = this.GetData(sql);
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.CaId = Convert.ToInt32(reader["CaId"]);
                category.CategoryName = reader["CategoryName"].ToString();
                categories.Add(category);
            }
            return categories;
        }
        public Category GetCategory(int id) 
        {
            string sql = "SELECT * FROM Categories WHERE CaId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Category category = new Category();
                category.CaId = Convert.ToInt32(reader["CaId"]);
                category.CategoryName = reader["CategoryName"].ToString();
                return category;
            }
            return null;
        }

        public int AddCategory(Category category)
        {
            string sql = "INSERT INTO Categories(CategoryName) VALUES('" + category.CategoryName + "')";
            return this.ExecuteQuery(sql);
        }

        public int UpdateCategory(Category category)
        {
            string sql = "UPDATE Categories SET CategoryName='" + category.CategoryName + "' WHERE CaID=" + category.CaId;
            return this.ExecuteQuery(sql);
        }
        public int DeleteCategory(int id)
        {
            string sql = "DELETE FROM Categories WHERE CaId=" + id;
            return this.ExecuteQuery(sql);
        }

        public int GetCategoryId(string name)
        {
            string sql = "SELECT CaId FROM Categories WHERE CategoryName='" + name + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["CaId"]);
            }
            return -1;
        }
        public List<string> GetCategoryNames()
        {
            string sql = "SELECT CategoryName FROM Categories";
            SqlDataReader reader = this.GetData(sql);
            List<string> categoryNames = new List<string>();
            while (reader.Read())
            {
                categoryNames.Add(reader["CategoryName"].ToString());
            }
            return categoryNames;
        }
    }
}

