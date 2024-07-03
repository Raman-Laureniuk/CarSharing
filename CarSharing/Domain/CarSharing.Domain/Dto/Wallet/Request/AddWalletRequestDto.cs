namespace CarSharing.Domain.Dto.Wallet.Request
{
    using System;

    public class AddWalletRequestDto
    {
        public Guid ClientId { get; set; }
        public string EncryptedWalletData { get; set; }
    }
}
