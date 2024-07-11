namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System;

    public class WalletMessage
    {
        public int WalletId { get; set; }
        public Guid ClientId { get; set; }
    }
}
