namespace CarSharing.Repository.Entity.Configuration
{
    using CarSharing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CarCoordinatesConfiguration : IEntityTypeConfiguration<CarCoordinates>
    {
        public void Configure(EntityTypeBuilder<CarCoordinates> builder)
        {
            builder.HasKey(x => x.CarId).IsClustered(false);

            builder.Property(x => x.CarId).HasColumnName("CarId").IsRequired(true).ValueGeneratedNever();
            builder.Property(x => x.Latitude).HasColumnName("Latitude").IsRequired(true).HasPrecision(9, 6);
            builder.Property(x => x.Longitude).HasColumnName("Longitude").IsRequired(true).HasPrecision(9, 6);

            builder.HasOne(x => x.Car).WithOne(x => x.Coordinates).HasForeignKey<CarCoordinates>(x => x.CarId).HasPrincipalKey<Car>(x => x.CarId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.Latitude, x.Longitude }).IsClustered(false);

            builder.ToTable("CarCoordinates");
        }
    }
}
