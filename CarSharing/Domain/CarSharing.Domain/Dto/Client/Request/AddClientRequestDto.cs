namespace CarSharing.Domain.Dto.Client.Request
{
    public class AddClientRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
