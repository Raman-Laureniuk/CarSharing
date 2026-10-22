namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class TariffResponseMessage
    {
        [JsonProperty("tariffId", Required = Required.Always)]
        public int TariffId { get; set; }

        [JsonProperty("pricePerHour", Required = Required.Always)]
        public decimal PricePerHour { get; set; }
    }
}
