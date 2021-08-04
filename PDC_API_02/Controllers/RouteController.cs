using PDC_API_02.Models.DbContexts;
using PDC_API_02.Models.Routes;
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
    public class RouteController : ApiController
    {
        private readonly PDC_DbContext _context = new PDC_DbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(Route route)
        {
            if (route is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Routes.Add(route);

            if (await _context.SaveChangesAsync()==1)
            {
                return Ok($"Route withe the ID: {route.ID} was Created.");
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
            if (id < 1)
            {
                return BadRequest("Invalid Id.");
            }
            var route = await _context.Routes.SingleOrDefaultAsync(r => r.ID == id);

            if (route is null)
            {
                return NotFound();
            }

                _context.Routes.Remove(route);
            if (await _context.SaveChangesAsync() >0)
            {
                return Ok($"Route with the ID: {route.ID} was removed.");
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
