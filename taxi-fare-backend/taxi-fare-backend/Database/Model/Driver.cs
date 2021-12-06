using System.Collections.Generic;
using taxi_fare_backend.Database.Model.Relationships;

namespace taxi_fare_backend.Database.Model
{
    public class Driver
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<DriverVehicle> DriverVehicles { get; set; }
    }
}