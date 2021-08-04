using PDC_API_02.Models.Employee_Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDC_API_02.Models.Routes
{
    public class Route
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual List<Employee_Route> EmployeesOnRoute { get; set; } = new List<Employee_Route>();
    }
}