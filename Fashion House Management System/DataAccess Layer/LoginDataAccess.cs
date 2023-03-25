using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer
{
    class LoginDataAccess: DataAccessLayer
    {
        public string UserLoginValidation(User user)
        {
            string sql = "SELECT * FROM Users WHERE Username='" + user.Username + "' AND Password='" + user.Password + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return reader["Position"].ToString(); ;
            }
            return "never";
        }
    }
}
