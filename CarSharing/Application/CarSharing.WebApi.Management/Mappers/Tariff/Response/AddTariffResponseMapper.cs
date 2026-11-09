namespace CarSharing.WebApi.Management.Mappers.Tariff.Response
{
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Common.Mappers;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;
    using Microsoft.AspNetCore.Mvc;

    internal static class AddTariffResponseMapper
    {
        public static AddTariffResponseMessage ToAddTariffResponseMessage(this AddTariffResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new AddTariffResponseMessage()
            {
                TariffId = dto.TariffId
            };
        }

        public static ActionResult<AddTariffResponseMessage> ToActionResult(this Result<AddTariffResponseDto> result)
        {
            return result.ToActionResult(ToAddTariffResponseMessage);
        }
    }
}
