using KSTdotnet_training.DataBase.Models;
using KSTdotnet_training.Domain.Features.Blog;
using KSTdotnet_training.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

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
                ViewBag.isSuccess = true;
                ViewBag.Message = "Blog Created Successfully.";

                TempData["isSuccess"] = true;
                TempData["Message"] = "Blog Created Successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.isSuccess = false;
                ViewBag.Message = ex.ToString();

                TempData["isSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }

            return RedirectToAction("Index"); //ok
            //var lst = _blogService.GetBlogs();//ok
            //return View("Index", lst);
        }

        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            _blogService.DeleteBlogs(id);

            return RedirectToAction("Index");
        }

        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var blog = _blogService.GetByIDBlogs(id);
            BlogRequestModel requestModel = new BlogRequestModel()
            {
                Id = blog.BlogId,
                Author = blog.BlogAuthor,
                Title = blog.BlogTitle,
                Content = blog.BlogContent,
            };
            return View("BlogEdit", requestModel);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogRequestModel requestModel)
        {
            try
            {
                _blogService.UpdateBlogs(id,new TblBlog
                {
                    BlogTitle = requestModel.Title,
                    BlogAuthor = requestModel.Author,
                    BlogContent = requestModel.Content
                });
                //ViewBag.isSuccess = true;
                //ViewBag.Message = "Blog Updated Successfully.";

                TempData["isSuccess"] = true;
                TempData["Message"] = "Blog Updated Successfully.";
            }
            catch (Exception ex)
            {
                //ViewBag.isSuccess = false;
                //ViewBag.Message = ex.ToString();

                TempData["isSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }

            return RedirectToAction("Index");  
        }

    }
}
