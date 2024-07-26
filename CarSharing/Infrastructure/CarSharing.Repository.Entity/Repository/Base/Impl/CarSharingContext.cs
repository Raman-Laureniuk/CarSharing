namespace CarSharing.Repository.Entity.Repository.Base.Impl
{
    using System.Diagnostics;
    using CarSharing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class CarSharingContext : DbContext
    {
        public CarSharingContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(x => Debug.Write(x));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarSharingContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCoordinates> CarCoordinates { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
