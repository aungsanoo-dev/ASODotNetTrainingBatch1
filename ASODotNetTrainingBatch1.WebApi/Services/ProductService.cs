using ASODotNetTrainingBatch1.Shared;
using ASODotNetTrainingBatch1.WebApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace ASODotNetTrainingBatch1.WebApi.Services
{
    // Business Logic Layer + Data Access Layer

    // Request => Request Model
    // Response => Model
    public class ProductService : IProductService
    {
        private readonly IDbV2Service _dapperService;

        public ProductService(IDbV2Service dapperService)
        {
            _dapperService = dapperService;
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

        public ResponseModel GetProducts(int pageNo, int pageSize)
        {
            string query = @"Select * from Products 
                            ORDER BY ProductID
                            OFFSET ((@PageNo - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";
            var lst = _dapperService.Query<ProductModel>(query,
                new
                {
                    PageNo = pageNo,
                    PageSize = pageSize
                });
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
            //if (string.IsNullOrEmpty(requestModel.ProductName.Trim()))
            //{

            //}

            if (requestModel.ProductName.IsNullOrEmptyV2())
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Product name is required."
                };
            }

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

            #region Check Fields

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

            #endregion

            #region Remove Last Comma

            if (fields.Length > 0)
            {
                fields = fields.Substring(0, fields.Length - 1);
            }

            #endregion

            ResponseModel model = UpdateProduct(requestModel, fields);

            return model;
        }

        private ResponseModel UpdateProduct(ProductModel requestModel, string fields)
        {
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
            return model;
        }
    }
}
