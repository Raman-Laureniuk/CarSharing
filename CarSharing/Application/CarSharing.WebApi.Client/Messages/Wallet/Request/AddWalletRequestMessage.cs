namespace CarSharing.WebApi.Client.Messages.Wallet.Request
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AddWalletRequestMessage
    {
        [JsonProperty("encryptedWalletData", Required = Required.Always)]
        public string EncryptedWalletData { get; set; }
    }
}
