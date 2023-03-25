using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer.Entities
{
    class User
    {
        public int UId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
    }
}
