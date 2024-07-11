namespace CarSharing.WebApi.Client.Messages.Wallet.Request
{
    using System;

    public class AddWalletRequestMessage
    {
        public Guid ClientId { get; set; }
        public string EncryptedWalletData { get; set; }
    }
}
