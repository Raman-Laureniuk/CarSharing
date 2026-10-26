namespace CarSharing.WebApi.Client.Messages.Wallet.Request
{
    using System.Text.Json.Serialization;
    using System.ComponentModel.DataAnnotations;

    public class AddWalletRequestMessage
    {
        [JsonPropertyName("encryptedWalletData")]
        [JsonRequired]
        [Required]
        public string EncryptedWalletData { get; set; }
    }
}
