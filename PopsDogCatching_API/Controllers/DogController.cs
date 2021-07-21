using PopsDogCatching_API.Models.DbContexts;
using PopsDogCatching_API.Models.Dogs;
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
    public class DogController : ApiController
    {
        private readonly PopsDogCatchingDbContext _context = new PopsDogCatchingDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(Dog dog)
        {
            if (dog is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var breed = await _context.Breeds.FindAsync(dog.BreedID);

            dog.Breed = breed;
            dog.CaptureDate = DateTime.UtcNow;
            _context.Dogs.Add(dog);

            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok($"Dog: {dog.Name} was Added to the databse!");
            }
            else
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            //var dogs = await _context.Dogs.Include(d => d.Breed).ToListAsync();
            var dogs = await _context.Dogs.ToListAsync();
            return Ok(dogs);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var dog = await _context.Dogs.FindAsync(id);

            if (dog is null)
            {
                return NotFound();
            }
            return Ok(dog);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Dog newDogData)
        {
            if (id!=newDogData.ID)
            {
                return BadRequest("Invalid ID");
            }
            if (newDogData is null)
            {
                return BadRequest("Insufficient Data.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dog = await _context.Dogs.FindAsync(id);
            if (dog is null)
            {
                return NotFound();
            }

            dog.Name = newDogData.Name;
            dog.DateOfBirth = newDogData.DateOfBirth;
            dog.CaptureDate = newDogData.CaptureDate;
            dog.BreedID = newDogData.BreedID;
            dog.HasChipIdentification = newDogData.HasChipIdentification;
            dog.HasCollarIdentification = newDogData.HasCollarIdentification;
            dog.WasFoundInjured = newDogData.WasFoundInjured;
            dog.DogTemperment = newDogData.DogTemperment;
            dog.DogInjurySeverity = newDogData.DogInjurySeverity;

            if (await _context.SaveChangesAsync() >0)
            {
                return Ok("Dog Updated");
            }
            else
            {
                return InternalServerError();
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            var dog = await _context.Dogs.FindAsync(id);

            if (dog is null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dog);

            if (await _context.SaveChangesAsync()>0)
            {
                return Ok("Dog was successfull Removed from the database.");
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
