using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogManager _blogManager;

        public BlogController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        [HttpGet("blogList")]
        public IActionResult GetAllBlog()
        {
            var blog = _blogManager.GetAllBlog();
            if (blog != null)
            {
                return Ok(new { status = 200, message = blog });
            }
            return BadRequest();
        }


        [HttpPost("addBlog")]
        public IActionResult Add(BlogDTO blogDTO)
        {
            var result = _blogManager.AddBlog(blogDTO);
            if (result.Success)
                return Ok(new { status = 200, message = result });
            return BadRequest(new { status = 400, message = result });
        }

        [HttpDelete("deleteBlog")]
        public IActionResult Delete(int Id)
        {
            var result = _blogManager.DeleteBlog(Id);
            if (result.Success)
            {
                return Ok(new { status = 200, message = result.Message });
            }
            return BadRequest(new { status = 200, message = result.Message });
        }

        [HttpPost("updateBLog")]
        public IActionResult Update(BlogDTO blogDTO)
        {
            var result = _blogManager.UpdateBlog(blogDTO);
            if (result.Success)
            {
                return Ok(new { status = 200, message = result });
            }
            return BadRequest(new { Status = 400, message = result });
        }

        [HttpGet("byIdBlog")]
        public IActionResult GetById(int Id)
        {
            var result = _blogManager.GetById(Id);
            if (result.Success)
            {
                return Ok(new { status = 200, message = result });
            }
            return BadRequest(new { Status = 200, message = result });
        }

    }
}
