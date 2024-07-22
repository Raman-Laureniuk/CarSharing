namespace CarSharing.WebApi.Management.Messages.Client.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Include)]
    public class GetClientsResponseMessage
    {
        [JsonProperty("clients", Required = Required.AllowNull)]
        public List<ClientMessage> Clients { get; set; }
    }
}
