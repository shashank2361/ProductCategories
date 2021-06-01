using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductCategories.Api.Validations;
using ProductCategories.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, IMapper _mapper , ILogger<ProductController> logger)
        {
            this.productService = productService;
            this._mapper = _mapper;
             _logger = logger;
        
        }


        [HttpGet]
        [Route("GetProductsbyCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Core.Models.Product>>> GetProductsByCategory(int categoryId)
        {
            var products = await productService.GetProductsByCategory(categoryId);
            if (products != null      ) 
            {
                var newproduct = _mapper.Map<IEnumerable<Product>, IEnumerable<Core.Models.Product>>(products);

                return Ok(newproduct);

            }
          return NotFound();
        }

      
       [HttpGet("{SKU}")]
        public async Task<ActionResult<Core.Models.Product>> GetProductBySKU(int SKU)
        {
           
            var product = await productService.GetProductBySKU(SKU);
            if (product!= null)
            {
                var newproduct = _mapper.Map<Product, Core.Models.Product>(product);
                return Ok(newproduct);
            }
      
            return NotFound();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Models.Product>> GetProductById(int id)
        {

            var product = await productService.GetProductById(id);

            if (product != null)
            {
                var newproduct = _mapper.Map<Product, Core.Models.Product>(product);
                return Ok(newproduct);
            }

            return NotFound();
        }



        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Core.Models.Product homeproduct)
        {

            var validator = new SaveProductValidator();
            var validationResult = await validator.ValidateAsync(homeproduct);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);


            var product = _mapper.Map<Core.Models.Product, Product>(homeproduct);
            var newproducts = await productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = newproducts.Id }, newproducts);

        }



    }
}
