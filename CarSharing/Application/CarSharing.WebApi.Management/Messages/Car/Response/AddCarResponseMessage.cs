namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class AddCarResponseMessage
    {
        [JsonPropertyName("carId")]
        public Guid CarId { get; set; }
    }
}
