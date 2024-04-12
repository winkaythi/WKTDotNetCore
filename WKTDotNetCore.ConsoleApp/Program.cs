// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using WKTDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");


//npm
//pub.dev
//nuget
//SqlConnection

//Ctrl + . => Sugesstion
//F10 =>
//F11
//F9 => Breakpoint

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "DESKTOP-7NM9PQ7";
//stringBuilder.InitialCatalog = "DotNetTrainingBatch4"; //DBName
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
////SqlConnection connection = new SqlConnection("Data Source = DESKTOP-7NM9PQ7; Initial Catalog=DotNetTrainingBatch4;User ID= sa;Password=sa@123");
//connection.Open();
//Console.WriteLine("Connection Open");

//string query = "select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection Close");

////dataset => datatable
////datatable => datarow
////datarow => datacolumn

//foreach(DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blo Id => " + dr["BlogId"]);
//    Console.WriteLine("Blo Title => " + dr["BlogTitle"]);
//    Console.WriteLine("Blo Author => " + dr["BlogAuthor"]);
//    Console.WriteLine("Blo Content => " + dr["BlogContent"]);
//    Console.WriteLine("------------------------------------");
//}

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title","author","content");
//adoDotNetExample.Update(13, "test title", "test author wkt", "test content");
//adoDotNetExample.Delete(13);
adoDotNetExample.Edit(13);
adoDotNetExample.Edit(12);
 
Console.ReadKey();

//Ado.Net Read 