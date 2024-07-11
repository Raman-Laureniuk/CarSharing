namespace CarSharing.WebApi.Client.Mappers.Client.Request
{
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.WebApi.Client.Messages.Client.Request;

    internal static class AddClientRequestMessageMapper
    {
        public static AddClientRequestDto ToAddClientRequestDto(this AddClientRequestMessage AddClientRequestMessage)
        {
            if (AddClientRequestMessage == null)
            {
                return null;
            }

            return new AddClientRequestDto()
            {
                Name = AddClientRequestMessage.Name,
                Surname = AddClientRequestMessage.Surname,
                LicenseNumber = AddClientRequestMessage.LicenseNumber,
                PhoneNumber = AddClientRequestMessage.PhoneNumber,
                Email = AddClientRequestMessage.Email
            };
        }
    }
}
