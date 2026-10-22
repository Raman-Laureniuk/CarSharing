namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using System.Text.Json.Serialization;

    public class AddTariffResponseMessage
    {
        [JsonPropertyName("tariffId")]
        public int TariffId { get; set; }
    }
}
