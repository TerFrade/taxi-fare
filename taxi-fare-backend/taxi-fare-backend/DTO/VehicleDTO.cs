using System;
using System.Linq;
using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.DTO
{
    public class VehicleDTO
    {
        public Guid Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public DriverDTO[] Drivers { get; set; }

        public VehicleDTO()
        { }

        public VehicleDTO(Vehicle data)
        {
            Id = data.Id;
            VehicleType = data.VehicleType;
            if (data.Drivers != null)
                Drivers = data.Drivers.Select(x => new DriverDTO(x)).ToArray();
        }
    }
}