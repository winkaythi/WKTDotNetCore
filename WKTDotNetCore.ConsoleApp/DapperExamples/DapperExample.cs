using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WKTDotNetCore.ConsoleApp.Dtos;
using WKTDotNetCore.ConsoleApp.Services;

namespace WKTDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(13);
            //Create("title", "author", "content");
            //Update(1012, "test title 2", "test author wkt 2", "test content 2");
            Delete(1012);
        }
        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();

            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("________________________________");

            }
        }
        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from tbl_blog where blogid = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);


        }
        private void Create(string title, string author, string content)
        {
            var Item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
            @BlogAuthor,
            @BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, Item);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }
        private void Update(int id, string title, string author, string content)
        {
            var Item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";


            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, Item);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            var Item = new BlogDto
            {
                BlogId = id,

            };
            string query = @"Delete [dbo].[Tbl_Blog]
 WHERE BlogId = @BlogId";


            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, Item);
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
