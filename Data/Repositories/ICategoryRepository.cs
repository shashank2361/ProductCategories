using Data.Models;
using ProductCategories.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCategories.Data.Repositories
{
    public interface  ICategoryRepository : IRepository<Category>
    {
    }
}
