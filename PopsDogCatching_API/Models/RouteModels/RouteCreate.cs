using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models.RouteModels
{
    public class RouteCreate
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public int? EmployeeID { get; set; }
    }
}