using Microsoft.AspNetCore.Mvc;
using NegotiationApi.Models;
using NegotiationApi.Services.Interfaces;

namespace NegotiationApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Products product)
        {
            try
            {
                _productService.AddProduct(product);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products= _productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id) 
        { 
            var ProductId= _productService.GetProductById(id);
            return Ok(ProductId);
        }
        

    }
}
