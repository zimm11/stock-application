using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StockApplication.Models;

namespace StockApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public class DbFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("StockApplicationDb");

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }

        //public ApplicationDbContext(DbContextOptions options) : base(options)
        //{
        //}



        //public DbSet<Stock> Stocks { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

    }
}
