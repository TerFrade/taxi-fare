using taxi_fare_backend.Data.Model;

namespace taxi_fare_backend.DTO
{
    public class TaxiDTO : VehicleDTO
    {
        public float BaseFarePrice { get; set; }
        public float BaseFareDistance { get; set; }

        public TaxiDTO()
        { }

        public TaxiDTO(Taxi data) : base(data?.Vehicle)
        {
            BaseFarePrice = data.BaseFarePrice;
            BaseFareDistance = data.BaseFareDistance;
        }
    }
}
