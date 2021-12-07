using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taxi_fare_backend.Database.Model
{
    public class Driver
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Guid VehicleId { get; set; }
        [ForeignKey("VehicleId"), Required] public virtual Vehicle Vehicle { get; set; }
    }
}