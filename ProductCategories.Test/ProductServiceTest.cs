using AutoMapper;
using Data.Models;
using Moq;
using ProductCategories.Core.Enums;
using ProductCategories.Core.Repositories;
using ProductCategories.Core.Services;
using ProductCategories.Core.Strategies;
using ProductCategories.Data.Repositories;
using ProductCategories.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProductCategories.Test
{
    public class ProductServiceTest
    {


        private readonly IProductService _productService;
        private readonly Mock<IUnitOfWork> _uowMock = new Mock<IUnitOfWork>();
        private readonly Mock<IProductStrategy> _productStrategyMock = new Mock<IProductStrategy>();


        public ProductServiceTest()
        {
             _productService = new ProductService(_uowMock.Object);

        }
        [Fact]
        public async Task ProductService_GetProductsByCategory_ReturnProducts()
        {

            //Arrange
            var catId =  (int)CategoryEnum.Home;
 
            var productsTest = new List<Product>()
            {
                 new Product(){
                Id = 1,
                CategoryId = catId,
                Sku = 10000,
                Name= "Sofa1",
                Description = "Sofa Daimond",
                Price = Convert.ToDecimal(1000.50)

            },
                new Product()
                {
                    Id = 1,
                    CategoryId = 2,
                    Sku = 10001,
                    Name = "Sofa2",
                    Description = "Sofa Premium",
                    Price = Convert.ToDecimal(1000.50)
                }
            };


             _uowMock.Setup(x => x.ProductRepo.GetProductsByCategory(catId)).ReturnsAsync(productsTest);
            _productStrategyMock.Setup(x => x.GetAllProducts()).ReturnsAsync(productsTest);

            //ACT
            var products = await _productService.GetProductsByCategory(catId);
            //Assert

            //_productStrategyMock.Verify(x => x.GetAllProducts());

             Assert.IsType<List<Product>>(products);


        }


            [Fact]
        public async Task ProductService_CreateProduct_SaveSuccess()
        {

            //Arrange
            var sku = 10000;

            var productTest =  new Product()
                {
               
                    CategoryId = (int)CategoryEnum.Home,
                    Sku = sku,
                    Name = "Sofa1",
                    Description = "Sofa Daimond",
                    Price = Convert.ToDecimal(1000.50)

                };

            _uowMock.Setup(x => x.ProductRepo.AddAsync(productTest) );
             var newId = _uowMock.Setup(x => x.CommitAsync()).ReturnsAsync(1);

            //ACT
            var product = await _productService.CreateProduct(productTest);
             _uowMock.Setup(x => x.ProductRepo.GetProductBySKU( sku)).ReturnsAsync(product);

            var getnewproduct = await _productService.GetProductBySKU(sku);

            //Assert
            Assert.Equal(sku, getnewproduct.Sku);
            Assert.IsType<Product>(getnewproduct); 
      


        }



    }
}
