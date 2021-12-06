using System;

namespace taxi_fare_backend.Database.Model.Relationships
{
    public class DriverVehicle
    {
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }

        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}