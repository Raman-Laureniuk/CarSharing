namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System.Text.Json.Serialization;

    public class DeleteCarResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
