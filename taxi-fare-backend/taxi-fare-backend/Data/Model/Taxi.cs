using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.Data.Model
{
    public class Taxi
    {
        [Key] public Guid VehicleId { get; set; }
        [Required, ForeignKey("VehicleId")] public Vehicle Vehicle { get; set; }
        public float BaseFarePrice { get; set; }
        public float BaseFareDistance { get; set; }
    }
}
