using STMDotNetCore.RestApiWithNLayer.Db;

namespace STMDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;

        public DA_Blog()
        {
            _context = new AppDbContext();
        }

        public void GetBlogs()
        {
            var lst= _context.Blogs.ToList();
        }
    }
}
