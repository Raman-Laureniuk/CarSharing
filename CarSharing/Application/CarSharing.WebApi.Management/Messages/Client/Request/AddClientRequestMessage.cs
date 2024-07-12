namespace CarSharing.WebApi.Management.Messages.Client.Request
{
    public class AddClientRequestMessage
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
