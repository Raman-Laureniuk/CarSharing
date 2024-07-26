namespace CarSharing.WebApi.Management.Messages.Tariff.Request
{
    using Newtonsoft.Json;

    [JsonObject]
    public class UpdateTariffRequestMessage
    {
        [JsonProperty("tariffId", Required = Required.Always)]
        public int TariffId { get; set; }

        [JsonProperty("pricePerHour", Required = Required.Always)]
        public decimal PricePerHour { get; set; }
    }
}
