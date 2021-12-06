using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace taxi_fare_backend.Database.Model
{
    public class Driver
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}