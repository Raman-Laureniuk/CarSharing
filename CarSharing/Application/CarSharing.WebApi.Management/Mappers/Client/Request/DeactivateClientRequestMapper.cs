namespace CarSharing.WebApi.Management.Mappers.Client.Request
{
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.WebApi.Management.Messages.Client.Request;

    internal static class DeactivateClientRequestMapper
    {
        public static DeactivateClientRequestDto ToDeactivateClientRequestDto(this DeactivateClientRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new DeactivateClientRequestDto()
            {
                ClientId = message.ClientId
            };
        }
    }
}
