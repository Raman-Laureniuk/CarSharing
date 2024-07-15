namespace CarSharing.Domain.Mappers.Tariff.Request
{
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Entities;

    internal static class AddTariffRequestMapper
    {
        public static Tariff ToTariffEntity(this AddTariffRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Tariff()
            {
                PricePerHour = dto.PricePerHour
            };
        }
    }
}
