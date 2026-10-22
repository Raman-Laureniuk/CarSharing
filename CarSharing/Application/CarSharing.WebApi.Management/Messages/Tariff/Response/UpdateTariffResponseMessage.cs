namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using System.Text.Json.Serialization;

    public class UpdateTariffResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
