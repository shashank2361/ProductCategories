
using Data.Models;
using ProductCategories.Core.Repositories;
using System.Collections.Generic;
 using System.Threading.Tasks;

namespace ProductCategories.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
          Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
        Task< Product> GetProductBySKU(int SKU);
 
     }
}
