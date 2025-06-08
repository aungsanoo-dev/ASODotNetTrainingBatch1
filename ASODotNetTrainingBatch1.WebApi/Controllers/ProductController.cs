using ASODotNetTrainingBatch1.Shared;
using ASODotNetTrainingBatch1.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ASODotNetTrainingBatch1.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public ProductController()
        {
            SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".\\SQL2022Express",
                InitialCatalog = "DotNetTrainingBatch1",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            _dapperService = new DapperService(_sqlConnectionStringBuilder);
        }

        [HttpGet()]
        public IActionResult GetProducts()
        {
            var lst = _dapperService.Query<ProductModel>("select * from tbl_Product");
            var data = new
            {
                IsSuccess = true,
                Message = "Success.",
                Data = lst,
            };
            return Ok(data);
        }

        [HttpGet("Edit")]
        [HttpGet("{id}")]
        public IActionResult GetProducts(int id)
        {
            string query = "select * from tbl_Product where ProductId=@ProductId";
            var lst = _dapperService.Query<ProductModel>(query, new 
            { 
                ProductId = id 
            });
            if(lst.Count == 0)
            {
                return NotFound(new 
                { 
                    IsSuccess = false, 
                    Message = "Product not found." 
                });
            }
            var data = new
            {
                IsSuccess = true,
                Message = "Success.",
                Data = lst[0],
            };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateProducts([FromBody] ProductModel product)
        {
            product.CreatedDateTime = DateTime.Now;
            product.CreatedBy = 1; 
            string query = @"
                insert into tbl_Product(
                ProductName, 
                ProductCategoryId, 
                Price, Quantity, 
                CreatedDateTime, 
                CreatedBy)
            values( 
                @ProductName, 
                @ProductCategoryId, 
                @Price, 
                @Quantity, 
                @CreatedDateTime, 
                @CreatedBy)";
            int result = _dapperService.Execute(query, product);
            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success." : "Fail.",
            };
            return Ok(data);
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
