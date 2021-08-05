using PopsDogCatching_API.Models.Data_POCOs.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models.Data_POCOs.Routes
{
    public class Route
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}