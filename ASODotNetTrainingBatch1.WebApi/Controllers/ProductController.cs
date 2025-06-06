using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASODotNetTrainingBatch1.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            // Simulate fetching products from a database or service
            var products = new List<string> { "Product1", "Product2", "Product3" };
            
            // Return the list of products as a JSON response
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] string productName)
        {
            // Simulate creating a product
            if (string.IsNullOrEmpty(productName))
            {
                return BadRequest("Product name cannot be empty.");
            }
            // Here you would typically save the product to a database
            return CreatedAtAction(nameof(GetProducts), new { name = productName }, productName);
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

        [HttpPatch]
        public IActionResult UpdateProduct([FromBody] string productName)
        {
            // Simulate partial update of a product
            if (string.IsNullOrEmpty(productName))
            {
                return BadRequest("Product name cannot be empty.");
            }
            // Here you would typically update the product in a database
            return NoContent(); // 204 No Content
        }
    }
}
