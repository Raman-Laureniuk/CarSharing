namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System.Text.Json.Serialization;

    public class AddWalletResponseMessage
    {
        [JsonPropertyName("walletId")]
        public int WalletId { get; set; }
    }
}
