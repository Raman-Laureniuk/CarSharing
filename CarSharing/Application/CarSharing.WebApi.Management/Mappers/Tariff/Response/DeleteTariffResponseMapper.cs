namespace CarSharing.WebApi.Management.Mappers.Tariff.Response
{
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;

    internal static class DeleteTariffResponseMapper
    {
        public static DeleteTariffResponseMessage ToDeleteTariffResponseMessage(this DeleteTariffResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new DeleteTariffResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
