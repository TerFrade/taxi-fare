using System;
using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.DTO
{
    public class VehicleDTO
    {
        public Guid Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public DriverDTO Driver { get; set; }

        public VehicleDTO()
        { }

        public VehicleDTO(Vehicle data)
        {
            Id = data.Id;
            VehicleType = data.VehicleType;
            if (data.Driver != null)
                Driver = new DriverDTO(data.Driver);
        }
    }
}