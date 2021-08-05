using PopsDogCatching_API.Models.Data_POCOs.Employees.ENUMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models.EmployeeModels
{
    public class EmployeeCreate
    {
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public PositionType Position { get; set; }

        public int? RouteID { get; set; }
    }
}