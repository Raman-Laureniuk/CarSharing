namespace CarSharing.Domain.Dto.Client.Response
{
    using System;

    public class ClientDto
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsBlocked { get; set; }
    }
}
