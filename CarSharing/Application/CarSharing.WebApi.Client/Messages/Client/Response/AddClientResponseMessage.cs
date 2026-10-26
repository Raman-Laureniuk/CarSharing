namespace CarSharing.WebApi.Client.Messages.Client.Response
{
    using System.Text.Json.Serialization;

    public class AddClientResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
