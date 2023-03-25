using Fashion_House_Management_System.DataAccess_Layer;
using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.Business_Logic_Layer
{
    class CategoryService
    {
        CategoryDataAccess categoryDataAccess;
        public CategoryService()
        {
            this.categoryDataAccess = new CategoryDataAccess();
        }

        public List<Category> GetAllCategories()
        {
           
            return this.categoryDataAccess.GetCategories();
        }
         public Category GetCategory(int id)
        {
            return this.categoryDataAccess.GetCategory(id);
        }

        public int AddNewCategory(string categoryName)
        {
            Category category = new Category() { CategoryName = categoryName };
            return this.categoryDataAccess.AddCategory(category);
        }
        public int UpdateExistingCategory(int caId,string categoryName)
        {
            Category category = new Category() {CaId=caId, CategoryName  = categoryName };
            return this.categoryDataAccess.UpdateCategory(category);
        }
        public int DeleteCategory(int id)
        {
            return this.categoryDataAccess.DeleteCategory(id);
        }
        public List<string> GetCategoryNames()
        {
            return this.categoryDataAccess.GetCategoryNames();
        }
    }
}
