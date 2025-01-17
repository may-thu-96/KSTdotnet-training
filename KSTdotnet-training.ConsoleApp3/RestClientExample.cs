using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KSTdotnet_training.ConsoleApp3
{
    public class RestClientExample
    {
        private readonly RestClient _client;
        private readonly string _url = "https://jsonplaceholder.typicode.com/posts";

        public RestClientExample()
        {
            _client = new RestClient();
        }

        public async Task ReadAsync()
        {
            RestRequest Request = new RestRequest(_url,Method.Get);

            var respond = await _client.GetAsync(Request);

            if (respond.IsSuccessStatusCode)
            {
                var jsonStr =  respond.Content!;

                Console.WriteLine(jsonStr);
            }
        }

        public async Task EditAsync(int id)
        {
            RestRequest Request = new RestRequest($"{_url}/{id}", Method.Get);

            var respond = await _client.GetAsync(Request);

            if (respond.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            if (respond.IsSuccessStatusCode)
            {
                var jsonStr =  respond.Content!;

                Console.WriteLine(jsonStr);
            }

        }

        public async Task CreateAsync(int id, int userId, string title, string body)
        {
            PostModel requestModel = new PostModel()
            {
                id = id,
                userId = userId,
                title = title,
                body = body
            };

            RestRequest request = new RestRequest(_url, Method.Post);

            request.AddJsonBody(requestModel); 

            var respond = await _client.PostAsync(request);
            if (respond.IsSuccessStatusCode)
            {
                var jsonStr =  respond.Content!;
                Console.WriteLine(jsonStr);
            }


        }

        public async Task UpdateAsync(int id, int userId, string title, string body)
        {
            PostModel requestModel = new PostModel()
            {
                id = id,
                userId = userId,
                title = title,
                body = body
            };

            RestRequest request = new RestRequest($"{_url}/{id}", Method.Post);

            request.AddJsonBody(requestModel);

            var respond = await _client.PatchAsync(request);
            if (respond.IsSuccessStatusCode)
            {
                var jsonStr = respond.Content!;
                Console.WriteLine(jsonStr);
            }
             


        }

        public async Task DeleteAsync(int id)
        {
            RestRequest request = new RestRequest($"{_url}/{id}", Method.Delete);

            var respond = await _client.DeleteAsync(request);

            if (respond.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            if (respond.IsSuccessStatusCode)
            {
                var jsonStr =  respond.Content!;

                Console.WriteLine(jsonStr);
            }

        }
    }

}
 