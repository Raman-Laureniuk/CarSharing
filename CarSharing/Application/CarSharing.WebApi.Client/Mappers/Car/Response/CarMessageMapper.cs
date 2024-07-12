namespace CarSharing.WebApi.Client.Mappers.Car.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Client.Messages.Car.Response;

    internal static class CarMessageMapper
    {
        public static CarMessage ToCarMessage(this CarDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new CarMessage()
            {
                CarId = dto.CarId,
                Model = dto.Model,
                Year = dto.Year,
                Color = dto.Color,
                PlateNumber = dto.PlateNumber,
                PricePerHour = dto.PricePerHour,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };
        }

        public static List<CarMessage> ToCarMessage(this IEnumerable<CarDto> dto)
        {
            return dto
                .OrEmptyIfNull()
                .Select(ToCarMessage)
                .ToList();
        }
    }
}
