using Data.Models;
using ProductCategories.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Core.Strategies
{
    public interface IProductStrategy
    {
        Task<IEnumerable<Product>> GetAllProducts( );
    }
}
