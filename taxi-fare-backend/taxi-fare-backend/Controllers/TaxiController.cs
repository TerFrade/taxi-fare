using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taxi_fare_backend.Data.Model;
using taxi_fare_backend.Database;
using taxi_fare_backend.Database.Model;
using taxi_fare_backend.DTO;

namespace taxi_fare_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        private readonly TaxiDbContext db;

        public TaxiController(TaxiDbContext db)
        {
            this.db = db;
        }

        // GET: /Taxi
        [HttpGet]
        [Produces(typeof(TaxiDTO))]
        public async Task<IActionResult> GetTaxi()
        {
            try
            {
                ICollection<Taxi> taxis = await db.Taxi.Include(x => x.Vehicle).Include(x => x.Vehicle.Driver).ToArrayAsync();
                return Ok(taxis.Select(x => new TaxiDTO(x)));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: /Taxi/[Guid]
        [HttpGet("{id}")]
        [Produces(typeof(TaxiDTO))]
        public async Task<IActionResult> GetTaxi(Guid id)
        {
            try
            {
                var taxi = await db.Taxi.Include(x => x.Vehicle).Include(x => x.Vehicle.Driver).FirstOrDefaultAsync(taxi => taxi.VehicleId == id);
                if (taxi == null) { return NotFound(); }
                return Ok(new TaxiDTO(taxi));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: /Taxi/[Guid]
        [HttpPut("{id}")]
        [Produces(typeof(TaxiDTO))]
        public async Task<IActionResult> Put(Guid id, [FromBody] TaxiDTO data)
        {
            try
            {
                var taxi = await db.Taxi.Include(x => x.Vehicle).ThenInclude(x => x.Driver).FirstOrDefaultAsync(taxi => taxi.VehicleId == id);

                if (taxi == null) { return NotFound(); }

                taxi.BaseFarePrice = data.BaseFarePrice;
                taxi.BaseFareDistance = data.BaseFareDistance;
                taxi.Vehicle.Driver = data.Driver != null ? await db.Driver.FirstOrDefaultAsync(driver => driver.Id == data.Driver.Id) : null;

                await db.SaveChangesAsync();

                return await GetTaxi(taxi.VehicleId);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Produces(typeof(TaxiDTO))]
        public async Task<IActionResult> Post([FromBody] TaxiDTO data)
        {
            try
            {
                Guid id = Guid.NewGuid();
                var taxi = new Taxi()
                {
                    VehicleId = id,
                    BaseFarePrice = data.BaseFarePrice,
                    BaseFareDistance = data.BaseFareDistance,
                    Vehicle = new Vehicle()
                    {
                        Id = id,
                        VehicleType = VehicleType.Taxi,
                        Driver = data.Driver != null ? await db.Driver.FirstAsync(driver => driver.Id == data.Driver.Id) : null
                    }
                };

                db.Taxi.Add(taxi);
                await db.SaveChangesAsync();
                return await GetTaxi(id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(TaxiDTO))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var taxi = await db.Taxi.Include(x => x.Vehicle).FirstOrDefaultAsync(taxi => taxi.VehicleId == id);
                if (taxi == null) { return NotFound(); }
                db.Taxi.Remove(taxi);
                await db.SaveChangesAsync();
                return Ok(new TaxiDTO(taxi));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}