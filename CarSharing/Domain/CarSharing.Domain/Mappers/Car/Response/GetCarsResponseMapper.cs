namespace CarSharing.Domain.Mappers.Car.Response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Tools.Extensions;

    internal static class GetCarsResponseMapper
    {
        public static CarDto ToCarDto(this Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            return new CarDto()
            {
                Model = car.Model,
                Year = car.Year,
                Color = car.Color,
                PlateNumber = car.PlateNumber,
                PricePerHour = car.Tariff.PricePerHour,
                Latitude = car.Coordinates.Latitude,
                Longitude = car.Coordinates.Longitude
            };
        }

        public static List<CarDto> ToCarDto(this IEnumerable<Car> cars)
        {
            return cars
                .OrEmptyIfNull()
                .Select(ToCarDto)
                .ToList();
        }
        
        public static GetCarsResponseDto ToGetCarsResponseDto(this IEnumerable<Car> cars)
        {
            return new GetCarsResponseDto()
            {
                Cars = cars.ToCarDto()
            };
        }
    }
}
