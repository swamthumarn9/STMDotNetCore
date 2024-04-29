using STMDotNetCore.ConsoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCoreExample
    {
        private readonly AppDbContext _dbContext=new AppDbContext();
        public void Run()
        {
            Edit(11);
        }

        private void Read()
        {
            var list = _dbContext.Blogs.ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("----------------------------");
            }
        }

        private void Edit(int id)
        {
            var item =_dbContext.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

            item.BlogTitle = "T2";
            item.BlogAuthor = "A2";
            item.BlogContent = "C2";

            Update(item.BlogId, item.BlogTitle, item.BlogAuthor, item.BlogContent);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            item.BlogId = id;
            item.BlogTitle = title;
            item.BlogAuthor=author;
            item.BlogContent=content;

            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message);
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            _dbContext.Blogs.Add(item);
            int result = _dbContext.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            _dbContext.Blogs.Remove(item);
            int result = _dbContext.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
