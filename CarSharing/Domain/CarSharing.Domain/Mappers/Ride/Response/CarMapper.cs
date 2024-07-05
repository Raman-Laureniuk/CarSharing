namespace CarSharing.Domain.Mappers.Ride.Response
{
    using System;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;

    internal static class CarMapper
    {
        public static CarDto ToCarDto(this Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            return new CarDto()
            {
                CarId = car.Id,
                Model = car.Model,
                Color = car.Color,
                PlateNumber = car.PlateNumber
            };
        }
    }
}
