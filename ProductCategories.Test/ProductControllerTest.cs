using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductCategories.Api.Controllers;
using ProductCategories.Api.Mapping;
using ProductCategories.Core.Enums;
using ProductCategories.Core.Repositories;
using ProductCategories.Core.Services;
using ProductCategories.Data;
using ProductCategories.Data.Repositories;
using ProductCategories.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductCategories.Test
{
    public class ProductControllerTest : IClassFixture<TestDataFixture>
    {
       private readonly MMTShopContext _context;
       private   IProductService _productService;
       private   IProductRepository _productRepo;
       private readonly IMapper _mapper;
       private ILogger<ProductController> logger;
       private  IUnitOfWork _unitOfWork;

        public ProductControllerTest(TestDataFixture fixture)
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();
            _context = fixture.Context;
            _unitOfWork = new UnitOfWork(_context);
            _productRepo = new ProductRepository(_context);
            _productService = new ProductService(_unitOfWork);
        }


        [Fact]
        public async Task ProductController_GetProductsByCategory_ReturnProductsOK()
        {
              //Arrange  
            var controller = new ProductController(_productService, _mapper , logger);
            var numProducts = _context.Products.Where(x => x.CategoryId == (int)CategoryEnum.Home).Count();


            //Act
            var result = await controller.GetProductsByCategory((int)CategoryEnum.Home);

            var okResult = result.Result as OkObjectResult;
            var products = okResult.Value as List<Core.Models.Product>;
            //Assert

            Assert.IsType<OkObjectResult>(okResult);
             Assert.Equal(numProducts  , products.Count() );

             
        }

        [Fact]
        public async Task ProductController_GetProductsByCategory_NotFound()
        {
            //Arrange  
            var controller = new ProductController(_productService, _mapper, logger);
 


            //Act
            var result = await controller.GetProductsByCategory(7);
 
            //Assert
            Assert.IsType<NotFoundResult>(result.Result  );


        }

        [Fact]
        public async Task ProductController_GetHomeProducts_ReturnProductsOK()
        {
            //Arrange  
            var controller = new ProductController(_productService, _mapper, logger);
            var numProducts = _context.Products.Where(x => x.CategoryId == (int)CategoryEnum.Home).Count();


            //Act
            var result = await controller.GetProductsByCategory((int)CategoryEnum.Home);

            var okResult = result.Result as OkObjectResult;
            var products = okResult.Value as List<Core.Models.Product>;
            //Assert

            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(numProducts, products.Where(x =>x.CategoryId == (int)CategoryEnum.Home).Count()) ;


        }
        [Fact]
        public async Task ProductController_GetGardenProducts_ReturnProductsOK()
        {
            //Arrange  
            var controller = new ProductController(_productService, _mapper, logger);
            var numProducts = _context.Products.Where(x => x.CategoryId == (int)CategoryEnum.Garden).Count();


            //Act
            var result = await controller.GetProductsByCategory((int)CategoryEnum.Garden);

            var okResult = result.Result as OkObjectResult;
            var products = okResult.Value as List<Core.Models.Product>;
            //Assert

            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(numProducts, products.Where(x => x.CategoryId == (int)CategoryEnum.Garden).Count());


        }

        [Fact]
        public async Task ProductController_GetElectronicsProducts_ReturnProductsOK()
        {
            //Arrange  
            var controller = new ProductController(_productService, _mapper, logger);
            var numProducts = _context.Products.Where(x => x.CategoryId == (int)CategoryEnum.Electronics).Count();


            //Act
            var result = await controller.GetProductsByCategory((int)CategoryEnum.Electronics);

            var okResult = result.Result as OkObjectResult;
            var products = okResult.Value as List<Core.Models.Product>;
            //Assert

            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(numProducts, products.Where(x => x.CategoryId == (int)CategoryEnum.Electronics).Count());


        }


        [Fact]
        public async Task ProductController_GetFitnessProducts_ReturnProductsOK()
        {
            //Arrange  
            var controller = new ProductController(_productService, _mapper, logger);
            var numProducts = _context.Products.Where(x => x.CategoryId == (int)CategoryEnum.Fitness).Count();


            //Act
            var result = await controller.GetProductsByCategory((int)CategoryEnum.Fitness);

            var okResult = result.Result as OkObjectResult;
            var products = okResult.Value as List<Core.Models.Product>;
            //Assert

            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(numProducts, products.Where(x => x.CategoryId == (int)CategoryEnum.Fitness).Count());


        }

        [Fact]
        public async Task ProductController_GetToysProducts_ReturnProductsOK()
        {
            //Arrange  
            var controller = new ProductController(_productService, _mapper, logger);
            var numProducts = _context.Products.Where(x => x.CategoryId == (int)CategoryEnum.Toys).Count();


            //Act
            var result = await controller.GetProductsByCategory((int)CategoryEnum.Toys);

            var okResult = result.Result as OkObjectResult;
            var products = okResult.Value as List<Core.Models.Product>;
            //Assert

            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(numProducts, products.Where(x => x.CategoryId == (int)CategoryEnum.Toys).Count());


        }
    }
}
