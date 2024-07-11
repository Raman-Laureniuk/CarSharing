namespace CarSharing.WebApi.Client.Mappers.Client.Request
{
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.WebApi.Client.Messages.Client.Request;

    internal static class UpdateClientRequestMessageMapper
    {
        public static UpdateClientRequestDto ToUpdateClientRequestDto(this UpdateClientRequestMessage updateClientRequestMessage)
        {
            if (updateClientRequestMessage == null)
            {
                return null;
            }

            return new UpdateClientRequestDto()
            {
                ClientId = updateClientRequestMessage.ClientId,
                Name = updateClientRequestMessage.Name,
                Surname = updateClientRequestMessage.Surname,
                LicenseNumber = updateClientRequestMessage.LicenseNumber,
                PhoneNumber = updateClientRequestMessage.PhoneNumber,
                Email = updateClientRequestMessage.Email
            };
        }
    }
}
