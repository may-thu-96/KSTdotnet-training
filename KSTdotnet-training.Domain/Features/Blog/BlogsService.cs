using KSTdotnet_training.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.Domain.Features.Blog
{
    public class BlogsService
    {
        private readonly AppDbContext _db;

        public BlogsService()
        {
            _db = new AppDbContext();
        }

        public List<TblBlog> GetBlogs()
        {
            var lst = _db.TblBlogs.AsNoTracking().ToList();

            return lst;
        }

        public TblBlog GetByIDBlogs(int id)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
             
            return item;
        }

        public TblBlog CreateBlogs(TblBlog blog)
        {
            _db.TblBlogs.Add(blog);
            _db.SaveChanges();

            return blog;
        }
        public TblBlog UpdateBlogs(int id, TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return null;
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return blog;
        }

        public TblBlog PatchBlogs(int id, TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }


            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return blog;
        }

        public bool? DeleteBlogs(int id)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return null;

            }
            _db.Entry(item).State = EntityState.Deleted;
            int result= _db.SaveChanges();

            return result>0;
        }
         

    }
}
