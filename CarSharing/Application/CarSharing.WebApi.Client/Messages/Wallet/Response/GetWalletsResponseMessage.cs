namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class GetWalletsResponseMessage
    {
        [JsonPropertyName("wallets")]
        public List<WalletResponseMessage> Wallets { get; set; }
    }
}
