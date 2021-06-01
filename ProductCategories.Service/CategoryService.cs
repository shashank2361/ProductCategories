using ProductCategories.Core.Models;
using ProductCategories.Core.Repositories;
using ProductCategories.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Category> CreateCategory(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(Category Category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryByCatId(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task UpdateCategory(Category CategoryToBeUpdated, Category Category)
        {
            throw new NotImplementedException();
        }
    }
}
