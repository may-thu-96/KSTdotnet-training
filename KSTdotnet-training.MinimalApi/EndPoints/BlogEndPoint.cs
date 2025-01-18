

using KSTdotnet_training.DataBase.Models;
using KSTdotnet_training.Domain.Features.Blog;
using Microsoft.AspNetCore.Mvc;

namespace KSTdotnet_training.MinimalApi.EndPoints
{
    public static class BlogEndPoint
    {
        public static void UseBlogEndPoint(this IEndpointRouteBuilder app)
        {

            app.MapGet("/blogs", ([FromServices] AppDbContext db) =>
            {
               // AppDbContext db = new AppDbContext();
                var lst = db.TblBlogs.AsNoTracking().ToList();
                return Results.Ok(lst);
            }).WithName("GetBlog")
            .WithOpenApi();

            app.MapGet("/blogs/{id}", ([FromServices] AppDbContext db,int id) =>
            {
               // AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }
                return Results.Ok(item);
            }).WithName("GetByIDBlog")
            .WithOpenApi();

            app.MapPost("/blogs", ([FromServices] AppDbContext db,TblBlog blog) =>
            {
               // AppDbContext db = new AppDbContext();
                db.TblBlogs.Add(blog);
                db.SaveChanges();
                return Results.Ok(blog);
            }).WithName("CreateBlog")
            .WithOpenApi();

            app.MapPut("/blogs/{id}", ([FromServices] AppDbContext db,int id, TblBlog blog) =>
            {
               // AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return Results.Ok();
            }).WithName("UpdateBlog")
            .WithOpenApi();

            app.MapDelete("/blogs/{id}", ([FromServices] AppDbContext db,int id) =>
            {
               // AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
                return Results.Ok();
            }).WithName("DeleteBlog")
            .WithOpenApi();

        }
    }
}
