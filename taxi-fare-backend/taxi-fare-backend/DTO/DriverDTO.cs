using System;
using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.DTO
{
    public class DriverDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Guid? VehicleId { get; set; }

        public DriverDTO()
        { }

        public DriverDTO(Driver data)
        {
            Id = data.Id;
            Name = data.Name;
            Surname = data.Surname;
            Email = data.Email;
            VehicleId = data.VehicleId;
        }
    }
}