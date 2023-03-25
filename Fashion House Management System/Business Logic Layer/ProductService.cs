using Fashion_House_Management_System.DataAccess_Layer;
using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.Business_Logic_Layer
{
    class ProductService
    {
        ProductDataAccess productDataAccess;
        public ProductService()
        {
            this.productDataAccess = new ProductDataAccess();
        }

        public List<Product> GetAllProducts()
        {
            return this.productDataAccess.GetProducts();
        }
        public Product GetProduct(int id)
        {
            return this.productDataAccess.GetProduct(id);
        }

        public int AddNewProduct(string productName, int stock, double retailPrice,double wholesalePrice,string productDetails,string productPhotoLocation, string categoryName)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            int caId = categoryDataAccess.GetCategoryId(categoryName);

            //WarehouseDataAccess warehouseDataAccess = new WarehouseDataAccess();
            //int wId = warehouseDataAccess.GetWarehouseId(warehouseName);

            Product product = new Product()
            {
                ProductName = productName,
                Stock = stock,
                RetailPrice = retailPrice,
                WholesalePrice = wholesalePrice,
                ProductDetails = productDetails,
                ProductPhotoLocation = productPhotoLocation,
                CaId = caId,
                //WId = wId,// ware house name return
            };
            this.productDataAccess = new ProductDataAccess();
            return this.productDataAccess.AddProduct(product);
        }
        public int UpdateExistingProduct(int pId, string productName, int stock, double retailPrice, double wholesalePrice, string productDetails, string productPhotoLocation, string categoryName)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            int caId = categoryDataAccess.GetCategoryId(categoryName);

            //WarehouseDataAccess warehouseDataAccess = new WarehouseDataAccess();
            //int wId = warehouseDataAccess.GetWarehouseId(warehouseName);

            Product product = new Product()
            {
                PId = pId,
                ProductName = productName,
                Stock = stock,
                RetailPrice = retailPrice,
                WholesalePrice = wholesalePrice,
                ProductDetails = productDetails,
                ProductPhotoLocation = productPhotoLocation,
                CaId = caId,
                //WId = wId,// ware house name return
            };
            this.productDataAccess = new ProductDataAccess();
            return this.productDataAccess.UpdateProduct(product);
        }
        public int DeleteProduct(int id)
        {
            return this.productDataAccess.DeleteProduct(id);
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
