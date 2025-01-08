

namespace KSTdotnet_training.MinimalApi.EndPoints
{
    public static class BlogEndPoint
    {
        public static void UseBlogEndPoint(this IEndpointRouteBuilder app)
        {

            app.MapGet("/blogs", () =>
            {
                AppDbContext db = new AppDbContext();
                var lst = db.TblBlogs.AsNoTracking().ToList();
                return Results.Ok(lst);
            }).WithName("GetBlog")
            .WithOpenApi();

            app.MapGet("/blogs/{id}", (int id) =>
            {
                AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No Data Found.");
                }
                return Results.Ok(item);
            }).WithName("GetByIDBlog")
            .WithOpenApi();

            app.MapPost("/blogs", (TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                db.TblBlogs.Add(blog);
                db.SaveChanges();
                return Results.Ok(blog);
            }).WithName("CreateBlog")
            .WithOpenApi();

            app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
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

            app.MapDelete("/blogs/{id}", (int id) =>
            {
                AppDbContext db = new AppDbContext();
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
