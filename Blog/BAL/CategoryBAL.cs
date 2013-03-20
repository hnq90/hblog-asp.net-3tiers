using System.Collections.Generic;
using DAL;
using Entities;

namespace BAL
{
    public class CategoryBAL
    {

        public static void CreateCategory(Category cat)
        {
            CategoryDAL.CreateCategory(cat);
        }

        public static void UpdateCategory(int id, Category cat)
        {
            CategoryDAL.UpdateCategory(id, cat);
        }

        public static void DeleteCategory(int id)
        {
            CategoryDAL.DeleteCategory(id);
        }

        public List<Category> ListCategories()
        {
            return CategoryDAL.ListCategories();
        }

        public List<Category> ListCategoryById(int cid)
        {
            return CategoryDAL.ListCategoryById(cid);
        }

        public static int CountCategory()
        {
            return CategoryDAL.CountCategories();
        }
    }
}