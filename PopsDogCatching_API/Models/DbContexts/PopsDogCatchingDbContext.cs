using PopsDogCatching_API.Models.Dogs;
using PopsDogCatching_API.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models.DbContexts
{
    public class PopsDogCatchingDbContext : DbContext
    {
        public PopsDogCatchingDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}