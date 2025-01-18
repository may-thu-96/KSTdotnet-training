using KSTdotnet_training.DataBase.Models;
using KSTdotnet_training.Domain.Features.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KSTdotnet_training.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsServiceController : ControllerBase
    {
        private readonly IBlogService _blogsService;

        public BlogsServiceController(IBlogService blogsService)
        {
            _blogsService = blogsService;
        }

        //public BlogsServiceController()
        //{
        //    _blogsService = new BlogService();
        //}

        [HttpGet]
        public IActionResult GetBlog()
        {
            var lst = _blogsService.GetBlogs();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = _blogsService.GetByIDBlogs(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            var item=_blogsService.CreateBlogs(blog);

            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, TblBlog blog)
        {
            var item = _blogsService.UpdateBlogs(id,blog);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPatch]
        public IActionResult PatchBlog(int id, TblBlog blog)
        {
            var item = _blogsService.PatchBlogs(id, blog);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int id)
        {
            var item = _blogsService.DeleteBlogs(id);

            if (item is null)
            {
                return NotFound();
            }
            
            return Ok(item);
        }
    }
}
