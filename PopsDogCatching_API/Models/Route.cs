using PopsDogCatching_API.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models
{
    public class Route
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int? EmployeeID { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}