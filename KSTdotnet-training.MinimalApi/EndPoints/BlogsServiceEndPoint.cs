using KSTdotnet_training.Domain.Features.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace KSTdotnet_training.MinimalApi.EndPoints
{
    public static class BlogsServiceEndPoint
    {
        public static void UseBlogsServiceEndPoint(this IEndpointRouteBuilder app)
        {

            app.MapGet("/blogs", ([FromServices] IBlogService blogsService) =>
            {
                //BlogsService blogsService = new BlogsService();

                var lst = blogsService.GetBlogs();

                return Results.Ok(lst);

            }).WithName("GetBlog")
            .WithOpenApi();

            app.MapGet("/blogs/{id}", ([FromServices] IBlogService blogsService,int id) =>
            {
               // BlogsService blogsService = new BlogsService();

                var item = blogsService.GetByIDBlogs(id);

                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }

                return Results.Ok(item);

            }).WithName("GetByIDBlog")
            .WithOpenApi();

            app.MapPost("/blogs", ([FromServices] IBlogService blogsService,TblBlog blog) =>
            {
               // BlogsService blogsService = new BlogsService();

                var item = blogsService.CreateBlogs(blog);

                return Results.Ok(item);

            }).WithName("CreateBlog")
            .WithOpenApi();

            app.MapPut("/blogs/{id}", ([FromServices] IBlogService blogsService,int id, TblBlog blog) =>
            {
               // BlogsService blogsService = new BlogsService();

                var item = blogsService.UpdateBlogs(id, blog);


                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }

                return Results.Ok(item);

            }).WithName("UpdateBlog")
            .WithOpenApi();

            app.MapDelete("/blogs/{id}", ([FromServices] IBlogService blogsService,int id) =>
            {
               // BlogsService blogsService = new BlogsService();

                var item = blogsService.DeleteBlogs(id);


                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }

                return Results.Ok(item);

            }).WithName("DeleteBlog")
            .WithOpenApi();

        }
    }
}
