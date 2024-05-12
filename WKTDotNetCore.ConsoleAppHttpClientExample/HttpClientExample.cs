﻿using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace WKTDotNetCore.ConsoleAppHttpClientExample
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7117") };
        private readonly string _blogEndpoint = "api/blog";
        public async Task RunAsync()
        {
            // await ReadAsync();
            // await EditAsync(1);
            // await EditAsync(100);
            //await EditAsync(3014);
            //await CreateAsync("title", "authorkt", "content win");
            await UpdateAsync(3014, "title1", "authorkt", "content win");
            await EditAsync(3014);
        }
        private async Task ReadAsync()
        {

            var response = await _client.GetAsync(_blogEndpoint);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
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
            var response = await _client.GetAsync($"{_blogEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;
               
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Content => {item.BlogContent}");

            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        private async Task CreateAsync(string title,string author,string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            }; //C# Object
            string blogJson = JsonConvert.SerializeObject(blogDto);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_blogEndpoint,httpContent);
            if(response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                //other process

            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                //error message
                //break
            }
        }
        private async Task UpdateAsync(int id,string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            }; //C# Object
            string blogJson = JsonConvert.SerializeObject(blogDto);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_blogEndpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
