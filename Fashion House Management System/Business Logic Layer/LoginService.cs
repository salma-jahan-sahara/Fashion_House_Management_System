using Fashion_House_Management_System.DataAccess_Layer;
using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.Business_Logic_Layer
{
    class LoginService
    {
        LoginDataAccess loginDataAccess;
        public LoginService()
        {
            this.loginDataAccess = new LoginDataAccess();
        }
        public string LoginValidation(string username, string password)
        {
            User user = new User()
            {
                Username = username,
                Password = password
            };
            return loginDataAccess.UserLoginValidation(user);
        }
    }
}
