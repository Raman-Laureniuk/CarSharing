namespace CarSharing.Domain.Mappers.Coordinates.Request
{
    using System;
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Entities;

    internal static class AddOrUpdateCoordinatesRequestMapper
    {
        public static CarCoordinates ToCarCoordinates(this AddOrUpdateCoordinatesRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
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
