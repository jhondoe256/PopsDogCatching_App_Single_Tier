using PopsDogCatching_API.Models.Data_POCOs.Dogs;
using PopsDogCatching_API.Models.DbContexts;
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
    public class BreedController : ApiController
    {
        private readonly PopsDogCatchingDbContext _context = new PopsDogCatchingDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Breed breed)
        {
            if (breed is null)
            {
                return BadRequest("Insufficient Data.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Breeds.Add(breed);
            if (await _context.SaveChangesAsync()>0)
            {
                return Ok($"Dog Breed: {breed.BreedName} was successfully added to the database!");
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var breeds = await _context.Breeds.ToListAsync();
            return Ok(breeds);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var breed = await _context.Breeds.FindAsync(id);
            if (breed is null)
            {
                return NotFound();
            }
            return Ok(breed);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Breed newBreedData)
        {
            if (id !=newBreedData.ID)
            {
                return BadRequest("Invalid ID.");
            }
            if (newBreedData is null)
            {
                return BadRequest("Insufficient Data.");
            }
            if (ModelState.IsValid ==false)
            {
                return BadRequest(ModelState);
            }
            var breed = await _context.Breeds.FindAsync(id);
            if (breed is null)
            {
                return NotFound();
            }
            breed.BreedName = newBreedData.BreedName;
            breed.Section = newBreedData.Section;
            breed.Country = newBreedData.Country;

            if (await _context.SaveChangesAsync() >0)
            {
                return Ok($"Breed was updated.");
            }
            else
            {
                return InternalServerError();
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            var breed = await _context.Breeds.FindAsync(id);
            if (breed is null)
            {
                return NotFound();
            }
            _context.Breeds.Remove(breed);
            if (await _context.SaveChangesAsync() >0)
            {
                return Ok("Breed was successfully Removed from the database");
            }
            return InternalServerError();
        }
    }
}
