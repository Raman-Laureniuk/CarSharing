namespace CarSharing.WebApi.Geo.Messages.Response
{
    using System.Text.Json.Serialization;

    public class AddOrUpdateCoordinatesResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
