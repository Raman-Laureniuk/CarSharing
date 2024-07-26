namespace CarSharing.WebApi.Client.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Client.Messages.Client.Response;

    internal static class AddClientResponseMapper
    {
        public static AddClientResponseMessage ToAddClientResponseMessage(this AddClientResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new AddClientResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
