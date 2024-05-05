using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STMDotNetCore.RestApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace STMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            //List<BlogModel> list = new List<BlogModel>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    BlogModel blog= new BlogModel();
            //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);
            //    list.Add(blog);
            //}
            //return Ok(list);

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";
            SqlConnection connection = new SqlConnection( ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };

            return Ok(dt);
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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor" , blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close() ;

            string message = result > 0 ? "Saving Successful." : "Saving Filed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            int item = FindById(id);
            if (item > 0)
            {
                blog.BlogId = id;
                string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId = @BlogId";
                SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BlogId", id);
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
                int result = cmd.ExecuteNonQuery();
                connection.Close();

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
            //if (id == null)
            //{
            //    return NotFound("No Data Found.");
            //}
            //else
            //{
            //    blog.BlogId = id;
            //}
            int item = FindById(id);
            if (item > 0)
            {
                string conditions = string.Empty;
                SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
                connection.Open();

                if (!string.IsNullOrEmpty(blog.BlogTitle))
                {
                    conditions += "[BlogTitle] = @BlogTitle, ";
                }
                if (!string.IsNullOrEmpty(blog.BlogAuthor))
                {
                    conditions += "[BlogAuthor] = @BlogAuthor, ";
                }
                if (!string.IsNullOrEmpty(blog.BlogContent))
                {
                    conditions += "[BlogContent] = @BlogContent, ";
                }
                if (conditions.Length == 0)
                {
                    return NotFound("No data found.");
                }
                conditions = conditions.Substring(0, conditions.Length - 2);

                string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET 
                {conditions} 
                         WHERE BlogId = @BlogId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BlogId", id);
                if (!string.IsNullOrEmpty(blog.BlogTitle))
                {
                    command.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
                }
                if (!string.IsNullOrEmpty(blog.BlogAuthor))
                {
                    command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
                }
                if (!string.IsNullOrEmpty(blog.BlogContent))
                {
                    command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                int result = command.ExecuteNonQuery();

                connection.Close();


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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }

        private int FindById(int id)
        {
            string query = "select * from tbl_blog where blogId = @blogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();            

            return result;
        }

    }
}
