namespace CarSharing.WebApi.Management.Messages.Tariff.Request
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AddTariffRequestMessage
    {
        [JsonProperty("pricePerHour", Required = Required.Always)]
        public decimal PricePerHour { get; set; }
    }
}
