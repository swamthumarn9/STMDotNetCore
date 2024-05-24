﻿using Microsoft.EntityFrameworkCore;
using STMDotNetCore.ConsoleApp.Dtos;
using STMDotNetCore.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace STMDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
