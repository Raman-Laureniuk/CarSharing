namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Include)]
    public class GetCarsResponseMessage
    {
        [JsonProperty("cars", Required = Required.AllowNull)]
        public List<CarMessage> Cars { get; set; }
    }
}
