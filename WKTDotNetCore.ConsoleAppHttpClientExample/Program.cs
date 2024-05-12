// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using WKTDotNetCore.ConsoleAppHttpClientExample;

Console.WriteLine("Hello, World!");

//Console App - Client (Frontend)
//ASP.Net Core WebAPI - Server (Backend)

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7117/api/blog"); 

//if(response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//    List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
//    foreach(var blog in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(blog));
//        Console.WriteLine($"Title => {blog.BlogTitle}");
//        Console.WriteLine($"Author => {blog.BlogAuthor}");
//        Console.WriteLine($"Content => {blog.BlogContent}");
//    }
//
//
//}

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();