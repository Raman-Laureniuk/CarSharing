namespace CarSharing.WebApi.Management.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Response;

    internal static class ActivateClientResponseMapper
    {
        public static ActivateClientResponseMessage ToActivateClientResponseMessage(this ActivateClientResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ActivateClientResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
