using System;
using System.Linq;
using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.DTO
{
    public class VehicleDTO
    {
        public Guid Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public DriverVehicleDTO[] DriverVehicles { get; set; }

        public VehicleDTO()
        {
        }

        public VehicleDTO(Vehicle data)
        {
            Id = data.Id;
            VehicleType = data.VehicleType;
            if (data.DriverVehicles != null)
                DriverVehicles = data.DriverVehicles.Select(x => new DriverVehicleDTO(x)).ToArray();
        }
    }
}