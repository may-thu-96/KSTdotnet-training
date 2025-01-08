// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");


var blog = new BlogModel()
{
    ID = 1,
    Title = "Test Title",
    Author = "Test Author",
    Content = "Test Content"
};

//var Jsonstr = JsonConvert.SerializeObject(blog,Formatting.Indented);
var Jsonstr = blog.ToJson();
Console.WriteLine(Jsonstr);

string Jsonstr2 = """{"iD": 1, "title": "Test Title",  "author": "Test Author", "content": "Test Content"}""";

BlogModel blog2  = JsonConvert.DeserializeObject<BlogModel>(Jsonstr2);

Console.WriteLine(blog2.Title);


public class BlogModel
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; } 
}

public static class Extension
{
    public static string ToJson(this object obj)
    {
        var Jsonstr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return Jsonstr;

    }
}