namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Include)]
    public class GetWalletsResponseMessage
    {
        [JsonProperty("wallets", Required = Required.AllowNull)]
        public List<WalletMessage> Wallets { get; set; }
    }
}
