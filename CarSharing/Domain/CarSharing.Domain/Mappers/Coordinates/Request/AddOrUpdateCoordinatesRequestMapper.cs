namespace CarSharing.Domain.Mappers.Coordinates.Request
{
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Entities;

    internal static class AddOrUpdateCoordinatesRequestMapper
    {
        public static CarCoordinates ToCarCoordinates(this AddOrUpdateCoordinatesRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new CarCoordinates()
            {
                CarId = dto.CarId,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };
        }
    }
}
