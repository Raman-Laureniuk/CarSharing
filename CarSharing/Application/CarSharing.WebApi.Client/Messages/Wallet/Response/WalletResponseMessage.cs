namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class WalletResponseMessage
    {
        [JsonPropertyName("walletId")]
        public int WalletId { get; set; }

        [JsonPropertyName("clientId")]
        public Guid ClientId { get; set; }
    }
}
