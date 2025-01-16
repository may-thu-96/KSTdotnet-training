using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.MapGet("/birds", () =>
{
    string folderPath = "Data/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdsRespondModel>(jsonStr)!;

    return (Results.Ok(result.Tbl_Bird));
})
.WithName("GetBirds")
.WithOpenApi();


app.MapGet("/birds/{id}", (int id) =>
{
    string folderPath = "Data/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdsRespondModel>(jsonStr)!;
     
    var item = result.Tbl_Bird.FirstOrDefault(x => x.Id == id);

    if (item is null ) return Results.BadRequest("No Data Found.");

                       return (Results.Ok(item));
})
.WithName("GetByIDBirds")
.WithOpenApi();

app.MapPost("/birds",(BirdModel requestModel)=>
{
    string folderPath = "Data/Birds.json"; 
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdsRespondModel>(jsonStr)!;

    requestModel.Id= result.Tbl_Bird.Count == 0 ? 1 :  result.Tbl_Bird.Max(x => x.Id) + 1;
    result.Tbl_Bird.Add(requestModel);

    var JsonStrToWrite = JsonConvert.SerializeObject(result);
    File.WriteAllText(folderPath,JsonStrToWrite);

    return (Results.Ok(requestModel));
})
.WithName("CreateBirds")
.WithOpenApi();

app.MapPut("/birds/{id}", (int id,BirdModel requestModel)=>
{
    string folderPath = "Data/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdsRespondModel>(jsonStr)!;

    var item = result.Tbl_Bird.FirstOrDefault(x => x.Id == id);
    if (item is null) return Results.BadRequest("No Data Found.");

    item.BirdMyanmarName = requestModel.BirdMyanmarName;
    item.BirdEnglishName = requestModel.BirdEnglishName;
    item.Description = requestModel.Description;
    item.ImagePath = requestModel.ImagePath;

    var JsonStrToWrite = JsonConvert.SerializeObject(result);
    File.WriteAllText(folderPath, JsonStrToWrite);

    return (Results.Ok(requestModel));
})
.WithName("UpdateBirds")
.WithOpenApi();

app.MapDelete("/birds/{id}",(int id)=>
{
    string folderPath = "Data/Birds.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdsRespondModel>(jsonStr)!;

    var item = result.Tbl_Bird.FirstOrDefault(x => x.Id == id);
    if (item is null) return Results.BadRequest("No Data Found.");

    result.Tbl_Bird.Remove(item);

    var JsonStrToWrite = JsonConvert.SerializeObject(result);
    File.WriteAllText(folderPath, JsonStrToWrite);

    return (Results.Ok("Delete Successful..."));

})
.WithName("DeleteBirds")
.WithOpenApi();
app.Run();



public class BirdsRespondModel
{
    public List<BirdModel> Tbl_Bird { get; set; }
}

public class BirdModel
{
    public int Id { get; set; }

    public string BirdMyanmarName { get; set; }

    public string BirdEnglishName { get; set; }

    public string Description { get; set; }

    public string ImagePath { get; set; }
}

