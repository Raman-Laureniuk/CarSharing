namespace CarSharing.WebApi.Management.Messages.Client.Request
{
    using System;

    public class DeactivateClientRequestMessage
    {
        public Guid ClientId { get; set; }
    }
}
