using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace taxi_fare_backend.Database.Model
{
    public class Taxi
    {
        [ForeignKey("Vehicle")] public Guid TaxiId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public int BaseFarePrice { get; set; }
        public int BaseFareDistance { get; set; }
    }
}