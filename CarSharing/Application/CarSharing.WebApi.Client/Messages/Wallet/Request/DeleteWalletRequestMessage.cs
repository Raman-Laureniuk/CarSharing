namespace CarSharing.WebApi.Client.Messages.Wallet.Request
{
    using System;

    public class DeleteWalletRequestMessage
    {
        public int WalletId { get; set; }
        public Guid ClientId { get; set; }
    }
}
