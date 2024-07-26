namespace CarSharing.Domain.Dto.Wallet.Request
{
    using System;

    public class DeleteWalletRequestDto
    {
        public int WalletId { get; set; }
        public Guid ClientId { get; set; }
    }
}
