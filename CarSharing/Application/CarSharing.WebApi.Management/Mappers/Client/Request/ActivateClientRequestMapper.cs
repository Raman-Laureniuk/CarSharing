namespace CarSharing.WebApi.Management.Mappers.Client.Request
{
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.WebApi.Management.Messages.Client.Request;

    internal static class ActivateClientRequestMapper
    {
        public static ActivateClientRequestDto ToActivateClientRequestDto(this ActivateClientRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new ActivateClientRequestDto()
            {
                ClientId = message.ClientId
            };
        }
    }
}
