namespace CarSharing.Domain.Dto.Client.Request
{
    using System;

    public class AddClientRequestDto
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
