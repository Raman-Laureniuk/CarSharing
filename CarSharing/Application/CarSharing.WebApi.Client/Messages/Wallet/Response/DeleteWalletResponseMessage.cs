namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System.Text.Json.Serialization;

    public class DeleteWalletResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
