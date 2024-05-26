using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace STMDotNetCore.ConsoleAppRefitExample;

public interface IBlogApi
{
    [Get("/api/blog")]
    Task<List<BlogModel>> GetBlogs();

    [Get("/api/blog/{id}")]
    Task<BlogModel> GetBlog(int id);

    [Post("/api/blog")]
    Task<string> CreateBlog(BlogModel blog);

    [Put("/api/blog")]
    Task<string> UpdateBlog(int id, BlogModel blog);

    [Delete("/api/blog/{id}")]
    Task<BlogModel> DeleteBlog(int id);
}

public class BlogModel
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}