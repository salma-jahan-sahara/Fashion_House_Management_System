using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Fashion_House_Management_System.DataAccess_Layer
{
  
    class DataAccessLayer : IDisposable
    {
        protected SqlConnection connection;
        protected SqlCommand command;

        public DataAccessLayer()
        {
            try
            {
                this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FashionHouseManagementSystem"].ConnectionString);
                this.connection.Open();
            }
            catch (Exception exp)
            {
                
            }
        }

        public SqlDataReader GetData(string sql)// Select Query
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteReader();
        }
        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql, connection); // insert query
            return this.command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.connection.Close();
        }

        ~DataAccessLayer()
        {
            //this.connection.Close();
        }
    }
}
