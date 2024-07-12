namespace CarSharing.WebApi.Client.Mappers.Client.Request
{
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.WebApi.Client.Messages.Client.Request;

    internal static class UpdateClientRequestMapper
    {
        public static UpdateClientRequestDto ToUpdateClientRequestDto(this UpdateClientRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new UpdateClientRequestDto()
            {
                ClientId = message.ClientId,
                Name = message.Name,
                Surname = message.Surname,
                LicenseNumber = message.LicenseNumber,
                PhoneNumber = message.PhoneNumber,
                Email = message.Email
            };
        }
    }
}
