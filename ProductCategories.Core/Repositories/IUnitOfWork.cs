using ProductCategories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Core.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        IProductRepository ProductRepo { get; }
        ICategoryRepository CategoryRepo { get; }
        Task<int> CommitAsync();
    }
}
