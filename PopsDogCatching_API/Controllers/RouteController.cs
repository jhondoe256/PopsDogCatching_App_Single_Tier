using PopsDogCatching_API.Models;
using PopsDogCatching_API.Models.Data_POCOs.Routes;
using PopsDogCatching_API.Models.DbContexts;
using PopsDogCatching_API.Models.RouteModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PopsDogCatching_API.Controllers
{
    public class RouteController : ApiController
    {
        private readonly PopsDogCatchingDbContext _context = new PopsDogCatchingDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(RouteCreate route)
        {
            if (route is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = new Route
            {
                Address = route.Description,
                Description =route.Description
            };

            //look for an employee w/n the database that matches the employee id from the route variable
            var employee = await _context.Employees.FindAsync(route.EmployeeID);

            if (employee != null)
            {
                entity.Employees.Add(employee);
            }

            _context.Routes.Add(entity);

            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok("Route was successfully Added");
            }
            else
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var route = await _context.Routes.FindAsync(id);
            return Ok(route);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var routes = await _context.Routes.ToListAsync();
           
            return Ok(routes);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Route newRouteData, [FromUri] int id)
        {
            if (id < 1 || id != newRouteData.ID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldRoute = await _context.Routes.SingleOrDefaultAsync(r => r.ID == id);

            if (oldRoute is null)
            {
                return NotFound();
            }

            oldRoute.Address = newRouteData.Address;
            oldRoute.Description = newRouteData.Description;
            // oldRoute.Employees = newRouteData.Employees;

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("Route Updated!");
            }
            else
            {
                return InternalServerError();

            }

        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id<1)
            {
                return BadRequest("Invalid Id.");
            }
            var route = await _context.Routes.SingleOrDefaultAsync(r => r.ID == id);

            if (route is null)
            {
                return NotFound();
            }

            if (await _context.SaveChangesAsync()==1)
            {
                _context.Routes.Remove(route);
                return Ok($"Route with the ID: {route.ID} was removed.");
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Route/AddEmployeeToRoute/{routeID:int}/{employeeId:int}")]
        public async Task<IHttpActionResult> Post([FromUri]int routeID,[FromUri] int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee is null)
            {
                return NotFound();
            }
            var route = await _context.Routes.SingleOrDefaultAsync(r => r.ID == routeID);
            if (route != null)
            {
                route.Employees.Add(employee);
                employee.Routes.Add(route);
                if (await _context.SaveChangesAsync()>0)
                {
                    return Ok($"{employee.FullName} was Added to route: {route.Description}");
                }
            }
            return InternalServerError();

        }
    
    }
}