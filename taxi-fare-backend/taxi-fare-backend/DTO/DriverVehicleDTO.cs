using taxi_fare_backend.Database.Model;
using taxi_fare_backend.Database.Model.Relationships;

namespace taxi_fare_backend.DTO
{
    public class DriverVehicleDTO
    {
        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }

        public DriverVehicleDTO()
        { }

        public DriverVehicleDTO(DriverVehicle data)
        {
            Driver = data.Driver;
            Vehicle = data.Vehicle;
        }
    }
}