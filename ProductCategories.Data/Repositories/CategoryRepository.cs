using Data.Models;
using ProductCategories.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCategories.Data.Repositories
{
    public class CategoryRepository  : Repository<Category>, ICategoryRepository
    {

        public CategoryRepository(MMTShopContext context) : base(context)
        {


        }
        

    }
}
