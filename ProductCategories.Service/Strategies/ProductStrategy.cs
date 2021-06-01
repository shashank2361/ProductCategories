using Data.Models;
using ProductCategories.Core.Enums;
using ProductCategories.Core.Repositories;
using ProductCategories.Core.Strategies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories.Service
{

    public class ProductStrategy
    {

        private IProductStrategy productStrategy;

        public ProductStrategy(IProductStrategy productStrategy)
        {
            this.productStrategy = productStrategy;
        }

        public Task<IEnumerable<Product>> GetAllProducts(int CategoryId)
        {
            return productStrategy.GetAllProducts();
        }

    }


    public class HomeStrategy : IProductStrategy
    {
        public IUnitOfWork unitOfWork { get; }

        public HomeStrategy(IUnitOfWork unitOfWork)
        {
           this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await unitOfWork.ProductRepo.GetProductsByCategory((int)CategoryEnum.Home);
        }
    }

    public class GardenStrategy : IProductStrategy
    {
        public IUnitOfWork unitOfWork { get; }

        public GardenStrategy(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await unitOfWork.ProductRepo.GetProductsByCategory((int)CategoryEnum.Garden);
        }
    }


    public  class ElectronicsStrategy : IProductStrategy
    {
        public IUnitOfWork unitOfWork { get; }

        public ElectronicsStrategy(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await  unitOfWork.ProductRepo.GetProductsByCategory((int)CategoryEnum.Electronics);
        }
    }


    public class FitnessStrategy : IProductStrategy
    {
        public IUnitOfWork unitOfWork { get; }

        public FitnessStrategy(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await unitOfWork.ProductRepo.GetProductsByCategory((int)CategoryEnum.Fitness);
        }
    }



    public class ToysStrategy : IProductStrategy
    {
        public IUnitOfWork unitOfWork { get; }

        public ToysStrategy(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await unitOfWork.ProductRepo.GetProductsByCategory((int)CategoryEnum.Toys);
        }
    }



}
