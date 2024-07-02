namespace CarSharing.Domain.Mappers.Car.Request
{
    using System;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Entities;

    internal static class AddCarRequestMapper
    {
        public static Car ToCarEntity(this AddCarRequestDto addCarRequestDto)
        {
            if (addCarRequestDto == null)
            {
                throw new ArgumentNullException(nameof(addCarRequestDto));
            }

            return new Car()
            {
                Model = addCarRequestDto.Model,
                Year = addCarRequestDto.Year,
                Color = addCarRequestDto.Color,
                PlateNumber = addCarRequestDto.PlateNumber,
                TariffId = addCarRequestDto.TariffId
            };
        }
    }
}
