namespace CarSharing.Repository.Entity.Configuration
{
    using CarSharing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.HasKey(x => x.TariffId).IsClustered(true);

            builder.Property(x => x.TariffId).HasColumnName("TariffId").IsRequired(true).ValueGeneratedOnAdd();
            builder.Property(x => x.PricePerHour).HasColumnName("PricePerHour").IsRequired(true).HasPrecision(9, 2);

            builder.HasMany(x => x.Cars).WithOne(x => x.Tariff).HasForeignKey(x => x.TariffId).IsRequired().HasPrincipalKey(x => x.TariffId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.ToTable("dbo.Tariffs");
        }
    }
}
