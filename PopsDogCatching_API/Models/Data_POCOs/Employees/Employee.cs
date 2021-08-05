using PopsDogCatching_API.Models.Data_POCOs.Employees.ENUMs;
using PopsDogCatching_API.Models.Data_POCOs.Routes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models.Data_POCOs.Employees
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

        public virtual List<Route> Routes { get; set; } = new List<Route>();
    }
}