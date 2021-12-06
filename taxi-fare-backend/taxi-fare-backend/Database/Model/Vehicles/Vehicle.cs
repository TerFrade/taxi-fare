using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using taxi_fare_backend.Database.Model.Relationships;

namespace taxi_fare_backend.Database.Model
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public ICollection<DriverVehicle> DriverVehicles { get; set; }
        public Taxi Taxi { get; set; }
    }

    public enum VehicleType
    {
        Taxi,
        Bus,
        Train
    }
}