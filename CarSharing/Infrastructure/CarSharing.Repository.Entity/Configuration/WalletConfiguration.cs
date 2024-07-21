namespace CarSharing.Repository.Entity.Configuration
{
    using CarSharing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.WalletId);

            builder.Property(x => x.WalletId).HasColumnName("WalletId").IsRequired(true).ValueGeneratedOnAdd();
            builder.Property(x => x.ClientId).HasColumnName("ClientId").IsRequired(true);
            builder.Property(x => x.EncryptedWalletData).HasColumnName("EncryptedWalletData").IsRequired(true).HasMaxLength(200).IsFixedLength(false).IsUnicode(false);

            builder.HasOne(x => x.Client).WithMany(x => x.Wallets).HasForeignKey(x => x.ClientId).IsRequired(true).HasPrincipalKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Rides).WithOne(x => x.Wallet).HasForeignKey(x => x.WalletId).IsRequired(true).HasPrincipalKey(x => x.WalletId).OnDelete(DeleteBehavior.ClientNoAction);  // TODO: Client will not be able to delete wallet if wallet is in history.

            builder.ToTable("dbo.Wallets");
        }
    }
}
