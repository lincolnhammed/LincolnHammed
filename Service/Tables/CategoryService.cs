using Models.Tables;
using Persistences.Dall.Tables;
using System.Linq;
using System;

namespace Service.Tables
{
    public class CategoryService
    {
        private CategoryDall categoriaDAL = new CategoryDall();
        public IQueryable<Category> GetCategoriesOrderByName()
        {
            return categoriaDAL.GetCategoryOrderedByName();
        }
        public Category GetCategoryById(long id)
        {
            return categoriaDAL.GetCategoryForId(id);
        }
        public void SaveCategory(Category category)
        {
            categoriaDAL.SaveCategory(category);
        }
        public Category DeleteCategoryForId(long id)
        {
            return categoriaDAL.DeleteCategoryForId(id);
        }
        public IQueryable<Category> Get()
        {
            return categoriaDAL.Get();
        }


    }
}
