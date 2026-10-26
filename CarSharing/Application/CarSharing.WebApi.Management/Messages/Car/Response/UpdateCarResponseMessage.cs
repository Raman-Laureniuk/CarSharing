namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System.Text.Json.Serialization;

    public class UpdateCarResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
