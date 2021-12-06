using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taxi_fare_backend.Database;
using taxi_fare_backend.Database.Model;
using taxi_fare_backend.DTO;

namespace taxi_fare_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly TaxiDbContext db;

        public DriverController(TaxiDbContext db)
        {
            this.db = db;
        }

        // GET: /Drivers
        [HttpGet]
        [Produces(typeof(DriverDTO))]
        public async Task<IActionResult> GetDriver()
        {
            try
            {
                ICollection<Driver> drivers = db.Driver.ToArray();
                return Ok(drivers.Select(x => new DriverDTO(x)));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: /Drivers/[Guid]
        [HttpGet("{id}")]
        [Produces(typeof(DriverDTO))]
        public async Task<IActionResult> GetDriver(Guid id)
        {
            try
            {
                var driver =  db.Driver.FirstOrDefault(driver => driver.Id == id);
                if (driver == null) { return NotFound(); }
                return Ok(new DriverDTO(driver));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: /Drivers/[Guid]
        [HttpPut("{id}")]
        [Produces(typeof(DriverDTO))]
        public async Task<IActionResult> Put(Guid id, [FromBody] DriverDTO data)
        {
            try
            {
                var driver =  db.Driver.FirstOrDefault(driver => driver.Id == id);

                if (driver == null) { return NotFound(); }

                driver.Name = data.Name;
                driver.Surname = data.Surname;
                driver.Email = data.Email;

                await db.SaveChangesAsync();

                return await GetDriver(driver.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Produces(typeof(DriverDTO))]
        public async Task<IActionResult> Post([FromBody] DriverDTO data)
        {
            try
            {
                if (db.Driver.FirstOrDefault(driver => driver.Email == data.Email) != null) { return StatusCode(409, "Driver with this email already exists!"); }
                var driver = new Driver()
                {
                    Id = Guid.NewGuid(),
                    Name = data.Name,
                    Surname = data.Surname,
                    Email = data.Email,
                    Vehicles = data.Vehicles.Length != 0 ? data.Vehicles
                    .Select(driver => new Vehicle()
                    {
                        Id = driver.Id,
                    }).ToList() : null
                };
                db.Driver.Add(driver);
                await db.SaveChangesAsync();
                return await GetDriver(driver.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(DriverDTO))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var driver = db.Driver.FirstOrDefault(driver => driver.Id == id);
                if (driver == null) { return NotFound(); }
                db.Driver.Remove(driver);
                await db.SaveChangesAsync();
                return Ok(new DriverDTO(driver));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}
