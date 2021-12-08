using Microsoft.EntityFrameworkCore;
using taxi_fare_backend.Data.Model;
using taxi_fare_backend.Database.Model;

namespace taxi_fare_backend.Database
{
    public class TaxiDbContext : DbContext
    {
        #region DbContextRegion

        public static readonly DbContextOptions<TaxiDbContext> ContextOptions;

        static TaxiDbContext()
        {
            ContextOptions = new DbContextOptionsBuilder<TaxiDbContext>()
                .UseInMemoryDatabase(databaseName: "MyTravelDb")
                .Options;
        }

        public TaxiDbContext() : base(ContextOptions)
        { }

        #endregion DbContextRegion

        public DbSet<Driver> Driver { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Taxi> Taxi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Driver)
                .WithOne(d => d.Vehicle)
                .HasForeignKey<Driver>(v => v.VehicleId);
        }
    }
}