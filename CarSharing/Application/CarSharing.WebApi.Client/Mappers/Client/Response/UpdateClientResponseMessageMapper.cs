namespace CarSharing.WebApi.Client.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Client.Messages.Client.Response;

    internal static class UpdateClientResponseMessageMapper
    {
        public static UpdateClientResponseMessage ToUpdateClientResponseMessage(this UpdateClientResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new UpdateClientResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
