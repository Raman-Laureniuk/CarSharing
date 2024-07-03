namespace CarSharing.Domain.Mappers.Coordinates.Request
{
    using System;
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Entities;

    internal static class AddOrUpdateCoordinatesRequestMapper
    {
        public static CarCoordinates ToCarCoordinates(this AddOrUpdateCoordinatesRequestDto addOrUpdateCoordinatesRequestDto)
        {
            if (addOrUpdateCoordinatesRequestDto == null)
            {
                throw new ArgumentNullException(nameof(addOrUpdateCoordinatesRequestDto));
            }

            return new CarCoordinates()
            {
                CarId = addOrUpdateCoordinatesRequestDto.CarId,
                Latitude = addOrUpdateCoordinatesRequestDto.Latitude,
                Longitude = addOrUpdateCoordinatesRequestDto.Longitude
            };
        }
    }
}
