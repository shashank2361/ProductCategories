using Data.Models;
using Microsoft.EntityFrameworkCore;
using ProductCategories.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository( MMTShopContext context) : base(context)
        {

        }

 

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await MMTShopContext.Products.Include( x => x.Category).Where( x=>x.CategoryId == categoryId).ToListAsync();

        }

        public async Task<Product> GetProductBySKU(int SKU)
        {
            return await MMTShopContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Sku == SKU) ;

        }




        private MMTShopContext MMTShopContext
        {
            get { return Context as MMTShopContext; }
        }


    }
}
