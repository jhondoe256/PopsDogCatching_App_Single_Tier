using PDC_API_02.Models.DbContexts;
using PDC_API_02.Models.Employee_Routes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PDC_API_02.Controllers
{
    public class EmployeeRouteController : ApiController
    {
        private readonly PDC_DbContext _context = new PDC_DbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Employee_Route employee_Route)
        {
            if (employee_Route is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.ID == employee_Route.EmployeeID);
            if (employee is null)
            {
                return NotFound();
            }
            employee_Route.Employee = employee;


            var route = await _context.Routes.SingleOrDefaultAsync(r => r.ID == employee_Route.RouteID);
            if (route is null)
            {
                return NotFound();
            }
            employee_Route.Route = route;

            employee.EmployeeRoutes.Add(employee_Route);
            route.EmployeesOnRoute.Add(employee_Route);

            _context.Employee_Routes.Add(employee_Route);

            if (await _context.SaveChangesAsync()>0)
            {
                return Ok("Route Assignment has been Created!");
            }
            else
            {
                return InternalServerError();
            }

        }
    }
}
