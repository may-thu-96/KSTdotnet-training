using KSTdotnet_training.Domain.Features.Blog;
using System.Reflection.Metadata;

namespace KSTdotnet_training.MinimalApi.EndPoints
{
    public static class BlogsServiceEndPoint
    {
        public static void UseBlogEndPoint(this IEndpointRouteBuilder app)
        {

            app.MapGet("/blogs", () =>
            {
                BlogsService blogsService = new BlogsService();

                var lst = blogsService.GetBlogs();

                return Results.Ok(lst);

            }).WithName("GetBlog")
            .WithOpenApi();

            app.MapGet("/blogs/{id}", (int id) =>
            {
                BlogsService blogsService = new BlogsService();

                var item = blogsService.GetByIDBlogs(id);

                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }

                return Results.Ok(item);

            }).WithName("GetByIDBlog")
            .WithOpenApi();

            app.MapPost("/blogs", (TblBlog blog) =>
            {
                BlogsService blogsService = new BlogsService();

                var item = blogsService.CreateBlogs(blog);

                return Results.Ok(item);

            }).WithName("CreateBlog")
            .WithOpenApi();

            app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
            {
                BlogsService blogsService = new BlogsService();

                var item = blogsService.UpdateBlogs(id, blog);


                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }

                return Results.Ok(item);

            }).WithName("UpdateBlog")
            .WithOpenApi();

            app.MapDelete("/blogs/{id}", (int id) =>
            {
                BlogsService blogsService = new BlogsService();

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
