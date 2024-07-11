namespace CarSharing.Domain.Dto.Wallet.Response
{
    using System;

    public class CheckWalletForClientResponseDto
    {
        public Guid ClientId { get; set; }
        public int WalletId { get; set; }
        public bool DoesWalletBelongToClient { get; set; }
    }
}
