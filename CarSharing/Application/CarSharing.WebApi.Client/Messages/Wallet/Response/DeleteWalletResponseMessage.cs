namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class DeleteWalletResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
