// See https://aka.ms/new-console-template for more information
using STMDotNetCore.ConsoleApp.AdoDotNetExample;
using STMDotNetCore.ConsoleApp.DapperExamples;
using STMDotNetCore.ConsoleApp.EFCoreExamples;
using System.Data;
using System.Data.SqlClient;

//Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder= new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "STM\\MSSQLSERVER2022";  //server name
//stringBuilder.InitialCatalog = "FirstConsoleApp";   // database name
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "root";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
////Data Source=STM\MSSQLSERVER2022;Initial Catalog=FirstConsoleApp;User ID=sa;Password=root
//connection.Open();
//Console.WriteLine("Connection Open");

//string query = "select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt=new DataTable();
//sqlDataAdapter.Fill(dt);

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id =>" + dr["BlogId"]);
//    Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
//    Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
//    Console.WriteLine("--------------------------------");
//}

//connection.Close();
//Console.WriteLine("Connection Close");


// Ado.Net Read
// CRUD

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Delete(8);
//adoDotNetExample.Update(9, "test title", "test author", "test content");
//adoDotNetExample.Edit(1);


//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadKey();