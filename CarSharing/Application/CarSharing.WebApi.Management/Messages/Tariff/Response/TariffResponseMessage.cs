namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using System.Text.Json.Serialization;

    public class TariffResponseMessage
    {
        [JsonPropertyName("tariffId")]
        public int TariffId { get; set; }

        [JsonPropertyName("pricePerHour")]
        public decimal PricePerHour { get; set; }
    }
}
