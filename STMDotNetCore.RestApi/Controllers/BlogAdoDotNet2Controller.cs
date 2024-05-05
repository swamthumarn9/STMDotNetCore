using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STMDotNetCore.RestApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using STMDotNetCore.Shared;
using System.Security.Cryptography;

namespace STMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";            

            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _doDotNetService.Query<BlogModel>(query, parameters);

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            //SqlConnection connection = new SqlConnection( ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            //connection.Close();

            if(item is null)
            {
                return NotFound("No Data Found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult PostBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor       
           ,@BlogContent)";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
            );

            string message = result > 0 ? "Saving Successful." : "Saving Filed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is not null)
            {
                blog.BlogId = id;
                string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId = @BlogId";

                int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", blog.BlogId),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
            );

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";
                return Ok(message);
            }
            else
            {
                return NotFound("No data found.");
            }
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBlogs(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is not null)
            {
                blog.BlogId = id;
                string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId = @BlogId";
                int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", blog.BlogId),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );
                //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
                //connection.Open();
                //SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@BlogId", blog.BlogId);
                //cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
                //cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
                //cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
                //int result = cmd.ExecuteNonQuery();
                //connection.Close();

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";
                return Ok(message);
            }
            else
            {
                return NotFound("No data found.");
            }
        }   

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {            
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", id)
                );

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }

        private BlogModel FindById(int id)
        {
            string query = "select * from tbl_blog where blogId = @blogId";
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            return item;
        }

    }
}
