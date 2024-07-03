namespace CarSharing.Domain.Dto.Wallet.Response
{
    using System;

    public class WalletDto
    {
        public Guid ClientId { get; set; }
        public string EncryptedWalletData { get; set; }
    }
}
