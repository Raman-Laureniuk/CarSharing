namespace CarSharing.WebApi.Management.Messages.Tariff.Request
{
    using System.Text.Json.Serialization;

    public class AddTariffRequestMessage
    {
        [JsonPropertyName("pricePerHour")]
        [JsonRequired]
        public decimal PricePerHour { get; set; }
    }
}
