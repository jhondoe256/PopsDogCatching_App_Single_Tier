﻿using PopsDogCatching_API.Models.DbContexts;
using PopsDogCatching_API.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsDogCatching_API.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly PopsDogCatchingDbContext _context = new PopsDogCatchingDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(Employee employee)
        {
            if (!ModelState.IsValid || employee is null)
            {
                return BadRequest();
            }

            var route = await _context.Routes.FindAsync(employee.RouteID);
            if (route != null)
            {
                employee.Routes.Add(route);

                route.EmployeeID = employee.ID;
                route.Employees.Add(employee);
            }

            _context.Employees.Add(employee);
            if (await _context.SaveChangesAsync()>0)
            {
                return Ok($"Employee: {employee.FullName} was Added to the database!");
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var employees = await _context.Employees.ToListAsync();
            foreach (var e in employees)
            {
                e.Routes.Add(await _context.Routes.FindAsync(e.RouteID));
            }
            return Ok(employees);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Employee newEmployeeData)
        {
            //check if the ids match...
            if (id != newEmployeeData.ID )
            {
                return BadRequest("Invalid ID entry");
            }

            //check if newEmployeeData is valid... All 'Required Fields are accounted for'
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //check if the newEmployeeData is not 'nothing'
            if (newEmployeeData is null)
            {
                return BadRequest("Empty Data Error.");
            }
            
            //Find an existing employee...
            var employee = await _context.Employees.FindAsync(id);
            
            //if that employee doesn't exist
            if (employee is null)
            {
                return NotFound();
            }

            //update employee w/ newemployeeData values
            employee.FirstName = newEmployeeData.FirstName;
            employee.LastName = newEmployeeData.LastName;
            employee.Position = newEmployeeData.Position;

            //check to see if changes were made...
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok("Employee was updated!");
            }
            else
            {
                //if no changes could be made...
                return InternalServerError();
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);

            if (await _context.SaveChangesAsync() >0)
            {
                return Ok($"Employee was successfully Removed from the database.");
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
