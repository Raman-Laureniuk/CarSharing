namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AddWalletResponseMessage
    {
        [JsonProperty("walletId", Required = Required.Always)]
        public int WalletId { get; set; }
    }
}
