using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp3
{
    public class RefitExample
    {
        public async void Run()
        {
            var BlogApi = RestService.For<IBlogApi>("https://localhost:7184");
            var lst = await BlogApi.GetBlog();
            foreach (var blog in lst)
            {
                Console.WriteLine(blog.BlogTitle);
            }

            //GetBlogByID
            try
            {
                var item = BlogApi.GetBlog(1);
            }
            catch (ApiException ex)
            {
               if( ex.StatusCode== System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("No Data Found.");
                }
            }
            //CreateBlog
            BlogModel blogModel = new BlogModel()
            {
                BlogId=1,
                BlogTitle= "test Title",
                BlogAuthor= "test Author",
                BlogContent= "test Content"

            };
            var createdata = await BlogApi.CreateBlog(blogModel);
            Console.WriteLine(createdata.BlogTitle);

            //UpdateBlog
            try
            {
                var Updatedata = await BlogApi.UpdateBlog(10, new BlogModel()
                {
                    BlogId = 1,
                    BlogTitle = "test Title",
                    BlogAuthor = "test Author",
                    BlogContent = "test Content"

                });
            }
            catch(ApiException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("No Data Found.");
                }

            }
           

        }
    }
}
