namespace CarSharing.Repository.Entity.Configuration
{
    using CarSharing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.CarId).IsClustered(false);

            builder.Property(x => x.CarId).HasColumnName("CarId").IsRequired(true).ValueGeneratedNever();
            builder.Property(x => x.Model).HasColumnName("Model").IsRequired(true).HasMaxLength(200).IsFixedLength(false).IsUnicode(true);
            builder.Property(x => x.Year).HasColumnName("Year").IsRequired(true);
            builder.Property(x => x.Color).HasColumnName("Color").IsRequired(true).HasMaxLength(100).IsFixedLength(false).IsUnicode(true);
            builder.Property(x => x.PlateNumber).HasColumnName("PlateNumber").IsRequired(true).HasMaxLength(50).IsFixedLength(false).IsUnicode(true);
            builder.Property(x => x.TariffId).HasColumnName("TariffId").IsRequired(true);

            builder.HasOne(x => x.Tariff).WithMany(x => x.Cars).HasForeignKey(x => x.TariffId).IsRequired(true).HasPrincipalKey(x => x.TariffId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(x => x.Coordinates).WithOne(x => x.Car).HasForeignKey<CarCoordinates>(x => x.CarId).IsRequired(true).HasPrincipalKey<Car>(x => x.CarId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Rides).WithOne(x => x.Car).HasForeignKey(x => x.CarId).IsRequired(true).HasPrincipalKey(x => x.CarId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasIndex(x => x.TariffId).IsClustered(false);

            builder.ToTable("dbo.Cars");
        }
    }
}
