namespace CarSharing.Domain.Dto.Wallet.Request
{
    using System;

    public class CheckWalletForClientRequestDto
    {
        public int WalletId { get; set; }
        public Guid ClientId { get; set; }
    }
}
