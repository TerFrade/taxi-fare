using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.DTO
{
    public class TaxiDTO : VehicleDTO
    {
        public int BaseFarePrice { get; set; }
        public int BaseFareDistance { get; set; }

        public TaxiDTO()
        { }

        public TaxiDTO(Taxi data) : base(data?.Vehicle)
        {
            if (data == null) { return; }
            BaseFarePrice = data.BaseFarePrice;
            BaseFareDistance = data.BaseFareDistance;
        }
    }
}