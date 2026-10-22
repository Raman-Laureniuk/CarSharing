namespace CarSharing.WebApi.Client.Messages.Wallet.Request
{
    using System.Text.Json.Serialization;

    public class AddWalletRequestMessage
    {
        [JsonPropertyName("encryptedWalletData")]
        [JsonRequired]
        public string EncryptedWalletData { get; set; }
    }
}
