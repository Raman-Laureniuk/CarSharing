namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AddTariffResponseMessage
    {
        [JsonProperty("tariffId", Required = Required.Always)]
        public int TariffId { get; set; }
    }
}
