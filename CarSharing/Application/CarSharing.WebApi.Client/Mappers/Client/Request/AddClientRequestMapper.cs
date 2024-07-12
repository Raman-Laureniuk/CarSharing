namespace CarSharing.WebApi.Client.Mappers.Client.Request
{
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.WebApi.Client.Messages.Client.Request;

    internal static class AddClientRequestMapper
    {
        public static AddClientRequestDto ToAddClientRequestDto(this AddClientRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new AddClientRequestDto()
            {
                Name = message.Name,
                Surname = message.Surname,
                LicenseNumber = message.LicenseNumber,
                PhoneNumber = message.PhoneNumber,
                Email = message.Email
            };
        }
    }
}
