namespace CarSharing.WebApi.Management.Messages.Client.Response
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class GetClientsResponseMessage
    {
        [JsonPropertyName("clients")]
        public List<ClientResponseMessage> Clients { get; set; }
    }
}
