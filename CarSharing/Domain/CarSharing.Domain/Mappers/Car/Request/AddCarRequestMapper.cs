namespace CarSharing.Domain.Mappers.Car.Request
{
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Entities;

    internal static class AddCarRequestMapper
    {
        public static Car ToCarEntity(this AddCarRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Car()
            {
                Model = dto.Model,
                Year = dto.Year,
                Color = dto.Color,
                PlateNumber = dto.PlateNumber,
                TariffId = dto.TariffId
            };
        }
    }
}
