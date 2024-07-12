namespace CarSharing.WebApi.Geo.Mappers.Request
{
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.WebApi.Geo.Messages.Request;

    internal static class AddOrUpdateCoordinatesRequestMapper
    {
        public static AddOrUpdateCoordinatesRequestDto ToAddOrUpdateCoordinatesRequestDto(this AddOrUpdateCoordinatesRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new AddOrUpdateCoordinatesRequestDto()
            {
                CarId = message.CarId,
                Latitude = message.Latitude,
                Longitude = message.Longitude
            };
        }
    }
}
