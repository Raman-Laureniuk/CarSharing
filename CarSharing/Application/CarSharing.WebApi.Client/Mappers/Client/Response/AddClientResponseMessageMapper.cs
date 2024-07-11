namespace CarSharing.WebApi.Client.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Client.Messages.Client.Response;

    internal static class AddClientResponseMessageMapper
    {
        public static AddClientResponseMessage ToAddClientResponseMessage(this AddClientResponseDto addClientResponseDto)
        {
            if (addClientResponseDto == null)
            {
                return null;
            }

            return new AddClientResponseMessage()
            {
                ClientId = addClientResponseDto.ClientId
            };
        }
    }
}
