namespace CarSharing.Repository.Entity.Repository.Base.Impl
{
    using System;
    using System.Diagnostics;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Providers.Config;
    using Microsoft.EntityFrameworkCore;

    internal class CarSharingContext : DbContext
    {
        private readonly IConfigProvider _configProvider;
        
        public CarSharingContext(IConfigProvider configProvider)
            : base()
        {
            _configProvider = configProvider ?? throw new ArgumentNullException(nameof(configProvider));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configProvider.GetSetting("CarSharing.Repository.Entity.ConnectionString");
            optionsBuilder.UseSqlServer(connectionString);

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
