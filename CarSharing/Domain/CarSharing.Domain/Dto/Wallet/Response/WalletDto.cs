namespace CarSharing.Domain.Dto.Wallet.Response
{
    using System;

    public class WalletDto
    {
        public int WalletId { get; set; }
        public Guid ClientId { get; set; }
        public string EncryptedWalletData { get; set; }
    }
}
