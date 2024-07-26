namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class WalletMessage
    {
        [JsonProperty("walletId", Required = Required.Always)]
        public int WalletId { get; set; }

        [JsonProperty("clientId", Required = Required.Always)]
        public Guid ClientId { get; set; }
    }
}
