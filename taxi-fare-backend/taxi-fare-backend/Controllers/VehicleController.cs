using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taxi_fare_backend.Database;
using taxi_fare_backend.Database.Model;
using taxi_fare_backend.DTO;

namespace taxi_fare_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly TaxiDbContext db;

        public VehicleController(TaxiDbContext db)
        {
            this.db = db;
        }

        // GET: /vehicles
        [HttpGet]
        [Produces(typeof(VehicleDTO))]
        public async Task<IActionResult> GetVehicle()
        {
            try
            {
                ICollection<Vehicle> vehicles = await db.Vehicle.Include(x => x.Drivers).ToArrayAsync();
                return Ok(vehicles.Select(x => new VehicleDTO(x)));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: /vehicles/[Guid]
        [HttpGet("{id}")]
        [Produces(typeof(VehicleDTO))]
        public async Task<IActionResult> GetVehicle(Guid id)
        {
            try
            {
                var vehicle = await db.Vehicle.Include(x => x.Drivers).FirstOrDefaultAsync(vehicle => vehicle.Id == id);
                if (vehicle == null) { return NotFound(); }
                return Ok(new VehicleDTO(vehicle));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: /vehicles/[Guid]
        [HttpPut("{id}")]
        [Produces(typeof(VehicleDTO))]
        public async Task<IActionResult> Put(Guid id, [FromBody] VehicleDTO data)
        {
            try
            {
                var vehicle = await db.Vehicle.FirstOrDefaultAsync(vehicle => vehicle.Id == id);

                if (vehicle == null) { return NotFound(); }
                vehicle.VehicleType = data.VehicleType;
                await db.SaveChangesAsync();

                return await GetVehicle(vehicle.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Produces(typeof(VehicleDTO))]
        public async Task<IActionResult> Post([FromBody] VehicleDTO data)
        {
            try
            {
                var vehicle = new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    VehicleType = data.VehicleType,
                    Drivers = data.Drivers.Length != 0 ? data.Drivers.Select(x => 
                    new Driver()
                    {
                        Name = x.Name,
                        Surname = x.Surname,
                        Email = x.Email,
                    }).ToList() : null
                };

                db.Vehicle.Add(vehicle);
                await db.SaveChangesAsync();
                return await GetVehicle(vehicle.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(VehicleDTO))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var vehicle = await db.Vehicle.FirstOrDefaultAsync(vehicle => vehicle.Id == id);
                if (vehicle == null) { return NotFound(); }
                db.Vehicle.Remove(vehicle);
                await db.SaveChangesAsync();
                return Ok(new VehicleDTO(vehicle));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}