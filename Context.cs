using DanielsCodingChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DanielsCodingChallenge
{
    public class Context : DbContext
    {
        public Context()
        { }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }



    }
}
