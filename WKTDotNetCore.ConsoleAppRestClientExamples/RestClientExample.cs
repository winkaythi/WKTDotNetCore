using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;

namespace WKTDotNetCore.ConsoleAppRestClientExamples
{
    internal class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7117"));
        private readonly string _blogEndpoint = "api/blog";
        public async Task RunAsync()
        {
            await ReadAsync();
            // await EditAsync(1);
            // await EditAsync(100);
            //await EditAsync(3014);
            //await CreateAsync("title", "authorkt", "content win");
            //await UpdateAsync(3014, "title1", "authorkt", "content win");
            //await EditAsync(3014);
        }
        private async Task ReadAsync()
        {
            //RestRequest restRequest = new RestRequest(_blogEndpoint);
            //var response = await _client.GetAsync(restRequest);
            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr);
                List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Content => {item.BlogContent}");
                }
            }
        }
        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            
            if (response.IsSuccessStatusCode)
            {
                string jsonStr =response.Content!;
                Console.WriteLine(jsonStr);
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;

                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");

            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
        private async Task CreateAsync(string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            }; //C# Object
           var restRequest = new RestRequest(_blogEndpoint, Method.Post);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(restRequest);
          
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
                //other process

            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
                //error message
                //break
            }
        }
        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            }; //C# Object
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            var response = await _client.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
