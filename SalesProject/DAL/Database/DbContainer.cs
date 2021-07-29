using Microsoft.EntityFrameworkCore;
using SalesProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.DAL.Database
{
    public class DbContainer : DbContext
    {
        public DbContainer(DbContextOptions<DbContainer> opt) : base (opt)
        {
                
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
