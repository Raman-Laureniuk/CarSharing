namespace CarSharing.WebApi.Client.Messages.Wallet.Request
{
    using System;

    public class AddWalletRequestMessage
    {
        public Guid ClientId { get; set; }  // TODO: Remove ClientId after auth implementation
        public string EncryptedWalletData { get; set; }
    }
}
