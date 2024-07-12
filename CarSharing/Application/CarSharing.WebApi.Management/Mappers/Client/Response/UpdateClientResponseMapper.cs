namespace CarSharing.WebApi.Management.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Response;

    internal static class UpdateClientResponseMapper
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
