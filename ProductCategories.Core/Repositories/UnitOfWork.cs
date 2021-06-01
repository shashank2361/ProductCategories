using Data.Models;
using ProductCategories.Core.Repositories;
using ProductCategories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MMTShopContext _context;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(MMTShopContext context )
        {
            this._context = context;
        }

        public IProductRepository ProductRepo   { get => _productRepository = _productRepository ?? new ProductRepository(_context);  }
        public ICategoryRepository CategoryRepo  { get => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);  }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
