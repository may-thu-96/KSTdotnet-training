
using KSTdotnet_training.DataBase.Models;
using KSTdotnet_training.Domain.Features.Blog;
using KSTdotnet_training.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KSTdotnet_training.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var lst = _blogService.GetBlogs();

            return View(lst);
        }
        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogRequestModel requestModel)
        {
            try
            {
                _blogService.CreateBlogs(new TblBlog
                {
                    BlogTitle = requestModel.Title,
                    BlogAuthor = requestModel.Author,
                    BlogContent = requestModel.Content
                });
                TempData["isSuccess"] = true;
                TempData["Message"] = "Blog Create Successfully.";
            }
            catch (Exception ex)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            try
            {
                _blogService.DeleteBlogs(id);
                TempData["isSuccess"] = true;
                TempData["Message"] = "Blog Delete Successfully.";
            }
            catch (Exception ex)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = ex.Message;

            }


            return RedirectToAction("Index");

        }
        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
           
               var blog= _blogService.GetByIDBlogs(id);
                
            BlogRequestModel requestModel = new BlogRequestModel()
            {
                ID = blog.BlogId,
                Title = blog.BlogTitle,
                Author = blog.BlogAuthor,
                Content = blog.BlogContent
            };

            return View("BlogEdit", requestModel);

        }

        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogRequestModel requestModel)
        {
            try
            {
                _blogService.UpdateBlogs(id, new TblBlog()
                {
                    BlogTitle = requestModel.Title,
                    BlogAuthor = requestModel.Author,
                    BlogContent = requestModel.Content
                });

                TempData["isSuccess"] = true;
                TempData["Message"] = "Blog Update Successfully.";
            }
            catch (Exception ex)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = ex.Message;

            }

            return RedirectToAction("Index");
        }
    }
}
