namespace CarSharing.WebApi.Geo.Mappers.Response
{
    using CarSharing.Domain.Dto.Coordinates.Response;
    using CarSharing.WebApi.Geo.Messages.Response;

    internal static class AddOrUpdateCoordinatesResponseMapper
    {
        public static AddOrUpdateCoordinatesResponseMessage ToAddOrUpdateCoordinatesResponseMessage(this AddUpdateCoordinatesResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new AddOrUpdateCoordinatesResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
