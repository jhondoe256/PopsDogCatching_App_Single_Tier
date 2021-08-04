using PDC_API_02.Models.Employees;
using PDC_API_02.Models.Routes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PDC_API_02.Models.Employee_Routes
{
    public class Employee_Route
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(Route))]
        public int RouteID { get; set; }
        public virtual Route Route { get; set; }
    }
}