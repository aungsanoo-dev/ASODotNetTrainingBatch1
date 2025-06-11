﻿using ASODotNetTrainingBatch1.Shared;

namespace ASODotNetTrainingBatch1.WebApi.Services
{
    public class ProductCategoryService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbV2Service _dbService;

        public ProductCategoryService(IConfiguration configuration, IDbV2Service dbService)
        {
            _configuration = configuration;
            _dbService = dbService;
        }
    }
}
