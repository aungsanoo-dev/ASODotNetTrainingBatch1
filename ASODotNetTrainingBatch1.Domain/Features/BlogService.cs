using ASODotNetTrainingBatch1.Domain.Models;
using ASODotNetTrainingBatch1.Project1.Databases.Models;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASODotNetTrainingBatch1.Domain.Features
{
    public class BlogService
    {
        private readonly AppDbContext _dbContext;

        public BlogService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseModel GetBlogs()
        {
            try
            {
                var lst = _dbContext.TblBlogs.ToList();
                return new ResponseModel(true, "Success", lst);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.ToString());
            }
        }

        public ResponseModel GetBlogs(int pageNo, int pageSize)
        {
            try
            {
                var lst = _dbContext.TblBlogs
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
                return new ResponseModel(true, "Success", lst);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.ToString());
            }
        }

        public ResponseModel CreateBlog(TblBlog blog)
        {
            try
            {
                _dbContext.TblBlogs.Add(blog);
                _dbContext.SaveChanges();
                return new ResponseModel(true, "Success", blog);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.ToString());
            }
        }



    }
}
