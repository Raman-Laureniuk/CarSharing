namespace CarSharing.Domain.Entities
{
    using System;

    public class CarUsage
    {
        public int Id { get; set; }

        public Guid ClientId { get; set; }
        public int WalletId { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public decimal? TotalAmount { get; set; }
        public int StatusId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual Car Car { get; set; }
        public virtual CarUsageStatus Status { get; set; }
    }
}
