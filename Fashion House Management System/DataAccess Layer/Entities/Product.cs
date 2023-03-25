using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer.Entities
{
    class Product
    {
        public int PId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
        public string ProductDetails { get; set; }
        public string ProductPhotoLocation { get; set; }
        public int CaId { get; set; }
    }
}
