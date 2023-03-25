using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.DataAccess_Layer.Entities
{
    class Sale
    {
        public int SaleId { get; set; }
        public string SoldBy { get; set; }
        public string SoldDate { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
        public string CustomerName { get; set; }
        public double TransactionAmount { get; set; }
        public string WareHouse { get; set; }
        public string Branch { get; set; }
        public int PId { get; set; }
        public int CId { get; set; }
        public int EId { get; set; }
        public int TId { get; set; }
        public int WId { get; set; }
    }
}
