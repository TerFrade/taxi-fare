﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using taxi_fare_backend.Data.Model;

namespace taxi_fare_backend.Database.Model
{
    public class Vehicle
    {
        [Key] public Guid Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public Taxi Taxi { get; set; }
    }

    public enum VehicleType
    {
        Taxi,
        Bus,
        Train
    }
}