namespace CarSharing.Repository.Entity.Configuration
{
    using CarSharing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId).IsClustered(false);

            builder.Property(x => x.ClientId).HasColumnName("ClientId").IsRequired(true).ValueGeneratedNever();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired(true).HasMaxLength(50).IsFixedLength(false).IsUnicode(true);
            builder.Property(x => x.Surname).HasColumnName("Surname").IsRequired(true).HasMaxLength(50).IsFixedLength(false).IsUnicode(true);
            builder.Property(x => x.LicenseNumber).HasColumnName("LicenseNumber").IsRequired(true).HasMaxLength(50).IsFixedLength(false).IsUnicode(true);
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").IsRequired(true).HasMaxLength(50).IsFixedLength(false).IsUnicode(false);
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired(true).HasMaxLength(100).IsFixedLength(false).IsUnicode(false);
            builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired(true);

            builder.HasMany(x => x.Wallets).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired(true).HasPrincipalKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Rides).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired(true).HasPrincipalKey(x => x.ClientId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasIndex(x => x.Surname).IsClustered(false);
            builder.HasIndex(x => x.LicenseNumber).IsClustered(false);
            builder.HasIndex(x => x.PhoneNumber).IsClustered(false);
            builder.HasIndex(x => x.Email).IsClustered(false);
            builder.HasIndex(x => x.IsActive).IsClustered(false);

            builder.ToTable("dbo.Clients");
        }
    }
}
