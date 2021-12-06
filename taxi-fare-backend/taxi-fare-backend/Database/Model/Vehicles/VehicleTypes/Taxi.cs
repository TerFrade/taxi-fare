﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taxi_fare_backend.Database.Model
{
    public class Taxi
    {
         public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int BaseFarePrice { get; set; }
        public int BaseFareDistance { get; set; }
    }
}