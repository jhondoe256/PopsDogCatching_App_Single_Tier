using PDC_API_02.Models.Dogs;
using PDC_API_02.Models.Employee_Routes;
using PDC_API_02.Models.Employees;
using PDC_API_02.Models.Routes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PDC_API_02.Models.DbContexts
{
    public class PDC_DbContext:DbContext
    {
        public PDC_DbContext() : base("DefaultConnection")
        {
        }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Employee_Route> Employee_Routes { get; set; }
    }
}