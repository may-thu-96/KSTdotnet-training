using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp3
{
    public interface IBlogApi
    {
        [Get("/api/blogs")]

        Task<List<BlogModel>> GetBlog();

        Task<BlogModel> GetBlog(int id);

        Task<BlogModel> CreateBlog(BlogModel blog);
        Task<BlogModel> UpdateBlog(int id, BlogModel blog);
    }
    //public interface IGitHubApi
    //{
    //    [Get("/users/{user}")]
    //    Task<User> GetUser(string user);
    //}

}
public  class BlogModel
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}