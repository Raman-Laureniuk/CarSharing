namespace CarSharing.WebApi.Management.Messages.Client.Response
{
    using System.Text.Json.Serialization;

    public class ActivateClientResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
