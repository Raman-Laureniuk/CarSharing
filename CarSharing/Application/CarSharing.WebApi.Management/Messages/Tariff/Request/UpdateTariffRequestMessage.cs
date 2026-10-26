namespace CarSharing.WebApi.Management.Messages.Tariff.Request
{
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class UpdateTariffRequestMessage
    {
        [JsonPropertyName("tariffId")]
        [JsonRequired]
        [RequiredNotDefaultValue]
        public int TariffId { get; set; }

        [JsonPropertyName("pricePerHour")]
        [JsonRequired]
        [RequiredNotDefaultValue]
        public decimal PricePerHour { get; set; }
    }
}
