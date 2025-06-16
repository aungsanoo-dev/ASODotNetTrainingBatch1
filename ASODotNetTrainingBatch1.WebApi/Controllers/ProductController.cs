using ASODotNetTrainingBatch1.Shared;
using ASODotNetTrainingBatch1.WebApi.Model;
using ASODotNetTrainingBatch1.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace ASODotNetTrainingBatch1.WebApi.Controllers
{
    // Presenation Layer (API Controller)

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var model = _productService.GetProducts();
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetProducts(int pageNo, int pageSize)
        {
            var model = _productService.GetProducts(pageNo,pageSize);
            return Ok(model);
        }

        [HttpGet("Edit")]
        [HttpGet("{id}")]
        public IActionResult GetProducts(int id)
        {
            var model = _productService.GetProductById(id);
            if (!model.IsSuccess)
            {
                return NotFound(model);
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateProducts([FromBody] ProductModel product)
        {
            Console.WriteLine("CreateProduct => " + product.ToJson()); // Log the JSON representation
            var model = _productService.CreateProduct(product);
            return Ok(model);
        }

        [HttpPut]
        public IActionResult CreateOrUpdateProduct([FromBody] string productName)
        {
            // Simulate updating a product
            if (string.IsNullOrEmpty(productName))
            {
                return BadRequest("Product name cannot be empty.");
            }
     
            return NoContent(); 
        }

        [HttpPatch("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductModel product)
        {
            var model = _productService.UpdateProduct(productId, product);
            return Ok(model); 
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        { 
            return Ok(productId);
        }
    }
}
