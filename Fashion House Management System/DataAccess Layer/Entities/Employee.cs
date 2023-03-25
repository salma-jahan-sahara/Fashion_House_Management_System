using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer.Entities
{
    class Employee

    {
        public int EId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int Phone { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string JoinedDate { get; set; }
        
        public string Branch { get; set; }
        
    }
}
