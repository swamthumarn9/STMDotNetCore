using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STMDotNetCore.RestApi.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using STMDotNetCore.Shared;
using System.Reflection.Metadata;

namespace STMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            var lst = _dapperService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            //string query = "select * from tbl_blog where blogId = @blogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id}).FirstOrDefault();

            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor       
           ,@BlogContent)";
                        
            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
                SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
                WHERE BlogId = @BlogId";
            
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found.");
            }

            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, "; 
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";
            }

            if(conditions.Length > 0)
            {
                return NotFound("No Data to Update");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }

            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            //using IDbConnection db=new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var result = db.Execute(query, new BlogModel { BlogId = id });
            var result = _dapperService.Execute(query, new BlogModel { BlogId = id });

            string message = result > 0 ? "Delete Successful" : "Delete Failed.";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where blogId = @blogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });

            return item;
        }
    }
}
