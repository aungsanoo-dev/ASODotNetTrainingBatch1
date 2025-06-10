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
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var model = _productService.GetProducts();
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
            // Here you would typically update the product in a database
            return NoContent(); // 204 No Content
        }

        [HttpPatch("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductModel product)
        {
            var model = _productService.UpdateProduct(productId, product);
            return Ok(model); // 204 No Content
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            return Ok(productId);
        }
    }
}
