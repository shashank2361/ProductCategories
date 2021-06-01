using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCategories.Test
{
    public class TestDataFixture : IDisposable
    {

        public MMTShopContext Context { get; set; }

        



        public TestDataFixture()
        {
            var builder = new DbContextOptionsBuilder<MMTShopContext>()
            .UseInMemoryDatabase(databaseName: "TestNewListDb");
            Context = new MMTShopContext(builder.Options);

        

        var _categories = new List<Category>
            {
                  new Category(){ CategoryId= 1, Description  = "Home"     },
                  new Category(){ CategoryId= 2, Description  = "Garden"     },
                  new Category(){ CategoryId= 3, Description  = "Electronics"   },
                  new Category(){ CategoryId= 4, Description  = "Fitness"    },
                  new Category(){ CategoryId= 5, Description  = "Toys"    },
            };


            var _products = new List<Product>
            {
                  new Product(){ Id= 1, Sku = 10000, Name  = "Sofa" , Description ="Sofa Daimond" , Price = Convert.ToDecimal(101.50) ,  CategoryId = 1  },
                  new Product(){ Id= 2, Sku = 10001,  Name  = "Sofa" , Description ="Sofa Platinum" , Price = Convert.ToDecimal(120.50) ,  CategoryId = 1  },
                  new Product(){ Id= 3,  Sku = 10002, Name  = "Table" , Description ="Table Oak" , Price = Convert.ToDecimal(120.50) ,  CategoryId = 1  },
                  new Product(){ Id= 4,  Sku = 20000, Name  = "Chair" , Description ="Garden Chair" , Price = Convert.ToDecimal(210.50) ,  CategoryId = 2  },
                  new Product(){ Id= 5,  Sku = 20001, Name  = "Table" , Description ="Garden Table" , Price = Convert.ToDecimal(120.50) ,  CategoryId = 2  },
                  new Product(){ Id= 6,  Sku = 30000, Name  = "Ipad" , Description ="ipad 10" , Price = Convert.ToDecimal(1110.50) ,  CategoryId = 3  },
                  new Product(){ Id= 7,  Sku = 30001, Name  = "Iphone" , Description ="iphone 10 " , Price = Convert.ToDecimal(1230.50) ,  CategoryId = 3  },
                  new Product(){ Id= 8,  Sku = 40000, Name  = "Mat" , Description ="Yoga mat" , Price = Convert.ToDecimal(10.50) ,  CategoryId = 4  },
                  new Product(){ Id= 9,  Sku = 50000, Name  = "Car" , Description ="ToyCar" , Price = Convert.ToDecimal(10.50) ,  CategoryId = 5 },
                  
            };

            Context.Categories.AddRange(_categories);
         
            Context.Products.AddRange(_products);
                Context.SaveChanges();
      
        

        } 


          public void Dispose()
        {
           Context.Dispose();
        }
    }
}
