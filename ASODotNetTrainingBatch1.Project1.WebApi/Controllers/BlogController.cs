﻿using ASODotNetTrainingBatch1.Domain.Features;
using ASODotNetTrainingBatch1.Project1.Databases.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASODotNetTrainingBatch1.Project1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var model = _blogService.GetBlogs();
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetBlogs(int pageNo = 1, int pageSize = 10)
        {
            var model = _blogService.GetBlogs(pageNo, pageSize);
            return Ok(model);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetBlog(int id)
        //{
        //    var item = _dbContext.TblBlogs.FirstOrDefault(x => x.BlogId == id);
        //    if (item == null)
        //    {
        //        return BadRequest("Blog not found");
        //    }
        //    //return Ok(item);
        //    return StatusCode(200, item);
        //}

        [HttpPost]
        public IActionResult CreateBlog([FromBody] TblBlog blog)
        {

            return StatusCode(201, "Blog Created.");
        }
    }

}
