namespace CarSharing.WebApi.Management.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Response;

    internal static class DeactivateClientResponseMapper
    {
        public static DeactivateClientResponseMessage ToDeactivateClientResponseMessage(this DeactivateClientResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new DeactivateClientResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
