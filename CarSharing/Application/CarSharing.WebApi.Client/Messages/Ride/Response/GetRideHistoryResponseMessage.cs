namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class GetRideHistoryResponseMessage
    {
        [JsonPropertyName("rides")]
        public List<RideResponseMessage> Rides { get; set; }
    }
}
