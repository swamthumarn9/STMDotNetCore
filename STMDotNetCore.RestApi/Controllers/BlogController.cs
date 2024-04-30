using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STMDotNetCore.RestApi.Db;

namespace STMDotNetCore.RestApi.Controllers
{
    // https://localhost:3000   => domain url
    //  api/blog => end point
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly AppDbContext _context;
        public BlogController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if(item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Create");
        }

        [HttpPut]   // update entire Object 
        public IActionResult Update()
        {
            return Ok("Update");
        }

        [HttpPatch]     // update each 
        public IActionResult Patch()
        {
            return Ok("Patch");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete");
        }

        
    }
}
