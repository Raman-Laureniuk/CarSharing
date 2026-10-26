namespace CarSharing.WebApi.Management.Messages.Tariff.Request
{
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class UpdateTariffRequestMessage
    {
        [JsonPropertyName("tariffId")]
        [JsonRequired]
        [ForbidDefaultValue]
        public int TariffId { get; set; }

        [JsonPropertyName("pricePerHour")]
        [JsonRequired]
        [ForbidDefaultValue]
        public decimal PricePerHour { get; set; }
    }
}
