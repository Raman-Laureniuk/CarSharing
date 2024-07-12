namespace CarSharing.WebApi.Management.Messages.Client.Response
{
    using System.Collections.Generic;

    public class GetClientsResponseMessage
    {
        public List<ClientMessage> Clients { get; set; }
    }
}
