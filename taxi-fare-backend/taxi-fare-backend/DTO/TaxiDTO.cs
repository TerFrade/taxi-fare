using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.DTO
{
    public class TaxiDTO
    {
        public Vehicle Vehicle { get; set; }
        public int BaseFarePrice { get; set; }
        public int BaseFareDistance { get; set; }

        public TaxiDTO()
        {
        }

        public TaxiDTO(Taxi data)
        {
            Vehicle = data.Vehicle;
            BaseFarePrice = data.BaseFarePrice;
            BaseFareDistance = data.BaseFareDistance;
        }
    }
}