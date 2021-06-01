using ProductCategories.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryByCatId(int id);
         Task<Category> CreateCategory(Category newCategory);
        Task UpdateCategory(Category CategoryToBeUpdated, Category Category);
        Task DeleteCategory(Category Category);

    }
}
