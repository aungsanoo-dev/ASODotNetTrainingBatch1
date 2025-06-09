using ASODotNetTrainingBatch1.Shared;
using ASODotNetTrainingBatch1.WebApi.Model;
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

        [HttpPatch("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductModel product)
        {
            product.ProductId = productId;
            string fields = string.Empty;

            // " ", null, ""
            if (product.ProductName != null && !string.IsNullOrEmpty(product.ProductName.Trim()))
            {
                fields += "[ProductName] = @ProductName,";
            }
            if (product.ProductCategoryId != null && product.ProductCategoryId > 0 )
            {
                fields += "[ProductCategoryId] = @ProductCategoryId,";
            }
            if (product.Price != null && product.Price > 0)
            {
                fields += "[Price] = @Price,";
            }
            if (product.Quantity != null && product.Quantity > 0)
            {
                fields += "[Quantity] = @Quantity,";
            }

            if(fields.Length == 0)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = "No fields to update."
                });
            }

            if(fields.Length > 0)
            {
                fields = fields.Substring(0, fields.Length - 1);
            }

            string query = $@"UPDATE [dbo].[Tbl_Product]
                SET 
                {fields}
                ,[ModifiedDateTime] = @ModifiedDateTime
                ,[ModifiedBy] = @ModifiedBy
                WHERE ProductId = @ProductId";

            int result = _dapperService.Execute(query, product);
            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success." : "Fail.",
            };

            return Ok(data); // 204 No Content
        }
    }
}
