
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Core.Services
{
    public interface IProductService
    {
        //Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
        Task<Product> GetProductBySKU(int sku);
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        //Task UpdateProduct(Product productToBeUpdated, Product product);
        //Task DeleteProduct(Product product);
    }
}
