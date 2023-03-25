using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer.Entities
{
    class Supplier
    {
        public int SId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; }
        public string JoinedDate { get; set; }
        public int WId { get; set; }
    }
}
