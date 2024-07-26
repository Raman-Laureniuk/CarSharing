namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Include)]
    public class GetRideHistoryResponseMessage
    {
        [JsonProperty("rides", Required = Required.AllowNull)]
        public List<RideMessage> Rides { get; set; }
    }
}
