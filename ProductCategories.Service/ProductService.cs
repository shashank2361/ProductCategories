
using Data.Models;
using ProductCategories.Core.Enums;
using ProductCategories.Core.Repositories;
using ProductCategories.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategories.Service
{
    public class ProductService :  IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product product)
        {
              await _unitOfWork.ProductRepo.AddAsync(product);
              await _unitOfWork.CommitAsync();
              return product;
         }

      
      

        public async Task<Product> GetProductBySKU(int sku)
        {
            return await _unitOfWork.ProductRepo.GetProductBySKU(sku);
        }



        public async Task<Product> GetProductById(int id)
        {
            return  await _unitOfWork.ProductRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            switch (categoryId)
            {
                case (int)CategoryEnum.Home :
                     return await new HomeStrategy(_unitOfWork).GetAllProducts();
                case (int)CategoryEnum.Garden:
                    return await new GardenStrategy(_unitOfWork).GetAllProducts();
                case (int)CategoryEnum.Electronics:
                    return await new ElectronicsStrategy(_unitOfWork).GetAllProducts();
                case (int)CategoryEnum.Fitness: 
                    return await new FitnessStrategy(_unitOfWork).GetAllProducts();
                case (int)CategoryEnum.Toys:
                    return await new ToysStrategy(_unitOfWork).GetAllProducts();
                default:
                    return null;
                        //Enumerable.Empty<Product>().ToList();
            }
        }

         
    }
}
