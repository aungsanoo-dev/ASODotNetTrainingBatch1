using ASODotNetTrainingBatch1.Shared;
using ASODotNetTrainingBatch1.WebApi.Model;
using Microsoft.Data.SqlClient;

namespace ASODotNetTrainingBatch1.WebApi.Services
{
    // Business Logic Layer + Data Access Layer
    public class ProductService
    {
        private readonly DapperService _dapperService;

        public ProductService()
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

        public ResponseModel GetProducts()
        {
            var lst = _dapperService.Query<ProductModel>("select * from tbl_Product");
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success.",
                Data = lst,
            };
            return model;
        }

        public ResponseModel GetProductById(int id)
        {
            string query = "select * from tbl_Product where ProductId=@ProductId";
            var lst = _dapperService.Query<ProductModel>(query, new 
            { 
                ProductId = id 
            });
            if (lst.Count == 0)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Product not found."
                };
            }
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success.",
                Data = lst[0], // Assuming you want to return a single product
            };
            return model;
        }

        public ResponseModel CreateProduct(ProductModel requestModel)
        {
            requestModel.CreatedDateTime = DateTime.Now;
            requestModel.CreatedBy = 1;
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
            int result = _dapperService.Execute(query, requestModel);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success." : "Fail.",
            };
            return model;
        }

        public ResponseModel UpdateProduct(int productId, ProductModel requestModel)
        {
            requestModel.ProductId = productId;
            string fields = string.Empty;

            // " ", null, ""
            if (requestModel.ProductName != null && !string.IsNullOrEmpty(requestModel.ProductName.Trim()))
            {
                fields += "[ProductName] = @ProductName,";
            }
            if (requestModel.ProductCategoryId != null && requestModel.ProductCategoryId > 0)
            {
                fields += "[ProductCategoryId] = @ProductCategoryId,";
            }
            if (requestModel.Price != null && requestModel.Price > 0)
            {
                fields += "[Price] = @Price,";
            }
            if (requestModel.Quantity != null && requestModel.Quantity > 0)
            {
                fields += "[Quantity] = @Quantity,";
            }

            if (fields.Length == 0)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "No fields to update."
                };
            }

            if (fields.Length > 0)
            {
                fields = fields.Substring(0, fields.Length - 1);
            }

            string query = $@"UPDATE [dbo].[Tbl_Product]
                SET 
                {fields}
                ,[ModifiedDateTime] = @ModifiedDateTime
                ,[ModifiedBy] = @ModifiedBy
                WHERE ProductId = @ProductId";

            int result = _dapperService.Execute(query, requestModel);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success." : "Fail.",
            };

            return model; // 204 No Content
        }
    }
}
