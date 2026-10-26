namespace CarSharing.WebApi.Client.Messages.Car.Response
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class GetCarsResponseMessage
    {
        [JsonPropertyName("cars")]
        public List<CarResponseMessage> Cars { get; set; }
    }
}
