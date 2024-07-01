namespace CarSharing.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Wallet
    {
        public int Id { get; set; }
        
        public Guid ClientId { get; set; }
        public string EncryptedWalletData { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<CarUsage> CarUsages { get; set; }
    }
}
