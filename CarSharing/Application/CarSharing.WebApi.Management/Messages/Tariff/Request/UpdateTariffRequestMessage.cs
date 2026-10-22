namespace CarSharing.WebApi.Management.Messages.Tariff.Request
{
    using System.Text.Json.Serialization;

    public class UpdateTariffRequestMessage
    {
        [JsonPropertyName("tariffId")]
        [JsonRequired]
        public int TariffId { get; set; }

        [JsonPropertyName("pricePerHour")]
        [JsonRequired]
        public decimal PricePerHour { get; set; }
    }
}
