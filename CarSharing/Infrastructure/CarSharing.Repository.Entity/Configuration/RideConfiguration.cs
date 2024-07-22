namespace CarSharing.Repository.Entity.Configuration
{
    using CarSharing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class RideConfiguration : IEntityTypeConfiguration<Ride>
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
            builder.HasKey(x => x.RideId).IsClustered(true);

            builder.Property(x => x.RideId).HasColumnName("RideId").IsRequired(true).ValueGeneratedOnAdd();
            builder.Property(x => x.ClientId).HasColumnName("ClientId").IsRequired(true);
            builder.Property(x => x.WalletId).HasColumnName("WalletId").IsRequired(true);
            builder.Property(x => x.CarId).HasColumnName("CarId").IsRequired(true);
            builder.Property(x => x.StartDateUtc).HasColumnName("StartDateUtc").IsRequired(true).HasPrecision(7);
            builder.Property(x => x.EndDateUtc).HasColumnName("EndDateUtc").IsRequired(false).HasPrecision(7);
            builder.Property(x => x.TotalAmount).HasColumnName("TotalAmount").IsRequired(false).HasPrecision(9, 2);  // TODO: Round TotalAmount on save.
            builder.Property(x => x.Status).HasColumnName("Status").IsRequired(true);

            builder.HasOne(x => x.Client).WithMany(x => x.Rides).HasForeignKey(x => x.ClientId).IsRequired(true).HasPrincipalKey(x => x.ClientId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(x => x.Wallet).WithMany(x => x.Rides).HasForeignKey(x => x.WalletId).IsRequired(true).HasPrincipalKey(x => x.WalletId).OnDelete(DeleteBehavior.ClientNoAction);  // TODO: Client will not be able to delete wallet if wallet is in history.
            builder.HasOne(x => x.Car).WithMany(x => x.Rides).HasForeignKey(x => x.CarId).IsRequired(true).HasPrincipalKey(x => x.CarId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasIndex(x => x.ClientId).IsClustered(false);
            builder.HasIndex(x => x.WalletId).IsClustered(false);
            builder.HasIndex(x => x.CarId).IsClustered(false);

            builder.ToTable("dbo.Rides");
        }
    }
}
