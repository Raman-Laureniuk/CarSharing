namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using System.Text.Json.Serialization;

    public class DeleteTariffResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
