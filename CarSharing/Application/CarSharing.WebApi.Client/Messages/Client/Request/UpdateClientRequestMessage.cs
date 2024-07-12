﻿namespace CarSharing.WebApi.Client.Messages.Client.Request
{
    using System;

    public class UpdateClientRequestMessage
    {
        public Guid ClientId { get; set; }  // TODO: Remove ClientId after auth implementation
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
