using KSTdotnet_training.DataBase.Models;

namespace KSTdotnet_training.Domain.Features.Blog
{
    public interface IBlogService
    {
        TblBlog CreateBlogs(TblBlog blog);
        bool? DeleteBlogs(int id);
        List<TblBlog> GetBlogs();
        TblBlog GetByIDBlogs(int id);
        TblBlog PatchBlogs(int id, TblBlog blog);
        TblBlog UpdateBlogs(int id, TblBlog blog);
    }
}