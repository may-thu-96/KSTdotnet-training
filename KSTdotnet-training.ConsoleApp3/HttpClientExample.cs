using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KSTdotnet_training.ConsoleApp3
{
    public class HttpClientExample
    {
        private readonly HttpClient _client;
        private readonly string _url = "https://jsonplaceholder.typicode.com/posts";

        public HttpClientExample()
        {
            _client = new HttpClient();
        }

        public async Task ReadAsync()
        {
            var respond = await _client.GetAsync(_url);

            if (respond.IsSuccessStatusCode)
            {
                var jsonStr = await respond.Content.ReadAsStringAsync();

                Console.WriteLine(jsonStr);
            }
        }

        public async Task EditAsync(int id)
        {
            var respond = await _client.GetAsync($"{_url}/{id}");

            if (respond.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            if (respond.IsSuccessStatusCode)
            {
                var jsonStr = await respond.Content.ReadAsStringAsync();

                Console.WriteLine(jsonStr);
            }

        }

        public async Task CreateAsync(int id, int userId, string title, string body)
        {
            PostModel requestModel = new PostModel()
            {
                userId = userId,
                title = title,
                body = body
            };

            var json = JsonConvert.SerializeObject(requestModel);
            var content = new StringContent(json, Encoding.UTF8, Application.Json);
            var respond = await _client.PostAsync(_url, content);
            if (respond.IsSuccessStatusCode)
            {
                var jsonStr = await respond.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }


        }

        public async Task UpdateAsync(int id, int userId, string title, string body)
        {
            PostModel requestModel = new PostModel()
            {
                userId = userId,
                title = title,
                body = body
            };

            var json = JsonConvert.SerializeObject(requestModel);
            var content = new StringContent(json, Encoding.UTF8, Application.Json);
            var respond = await _client.PatchAsync($"{_url}/{id}", content);
            if (respond.IsSuccessStatusCode)
            {
                var jsonStr = await respond.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }


        }

        public async Task DeleteAsync(int id)
        {
            var respond = await _client.DeleteAsync($"{_url}/{id}");

            if (respond.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            if (respond.IsSuccessStatusCode)
            {
                var jsonStr = await respond.Content.ReadAsStringAsync();

                Console.WriteLine(jsonStr);
            }

        }
    }

}
public class PostModel
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}