using System;

namespace ProductCategories.Core.Models
{
     public   abstract class SKU
    {
        public  virtual  int Sku { get; set; }
    }

        



    public     class Product : SKU
    {

        public  int Id { get; set; }
        public  override  int Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }






    }
}
