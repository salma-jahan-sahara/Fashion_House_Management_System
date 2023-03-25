using Fashion_House_Management_System.DataAccess_Layer;
using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.Business_Logic_Layer
{
    class SupplierService
    {
        SupplierDataAccess supplierDataAccess;
        public SupplierService()
        {
            this.supplierDataAccess = new SupplierDataAccess();
        }

        public List<Supplier> GetAllSuppliers()
        {

            return this.supplierDataAccess.GetSuppliers();
        }
        public Supplier GetSupplier(int id)
        {
            return this.supplierDataAccess.GetSupplier(id);
        }

        public int AddNewSupplier(string name, int phone, string location, string companyName, string joinedDate, string warehouseName)
        {
            WareHouseDataAccess wareHouseDataAccess = new WareHouseDataAccess();
            int wId = wareHouseDataAccess.GetWareHouseId(warehouseName);

            Supplier supplier = new Supplier()
            {
                Name = name,
                //Username = username,
                Phone = phone,
                Location = location,
                CompanyName = companyName,
                //Salary = salary,
                //Branch = branch,
                JoinedDate = joinedDate,
                WId = wId
            };
            this.supplierDataAccess = new SupplierDataAccess();
            return this.supplierDataAccess.AddSupplier(supplier);
        }
        public int UpdateExistingSupplier( string name, int phone, string location, string companyName, string joinedDate, string warehouseName)
        {
            WareHouseDataAccess wareHouseDataAccess = new WareHouseDataAccess();
            int wId = wareHouseDataAccess.GetWareHouseId(warehouseName);
            Supplier supplier = new Supplier()
            {
                //SId = sId,
                Name = name,
                //Username = username,
                Phone = phone,
                Location = location,
                CompanyName = companyName,
                //Salary = salary,
                //Branch = branch,
                JoinedDate = joinedDate,
                WId = wId
            };
            this.supplierDataAccess = new SupplierDataAccess();
            return this.supplierDataAccess.UpdateSupplier(supplier);
        }
        public int DeleteSupplier(int id)
        {
            return this.supplierDataAccess.DeleteSupplier(id);
        }
        
        /*public List<Product> GetAllProductsByCategory(string categoryName)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            int categoryId = categoryDataAccess.GetCategoryId(categoryName);
            this.productDataAccess = new ProductDataAccess();
            return this.productDataAccess.GetProductsByCategoryId(categoryId);
        }*/
    }
}
