using PDC_API_02.Models.Employee_Routes;
using PDC_API_02.Models.Employees.ENUMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDC_API_02.Models.Employees
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public PositionType Position { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public virtual List<Employee_Route> EmployeeRoutes { get; set; } = new List<Employee_Route>();
    }
}