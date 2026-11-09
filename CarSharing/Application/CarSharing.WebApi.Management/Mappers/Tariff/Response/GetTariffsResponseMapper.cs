namespace CarSharing.WebApi.Management.Mappers.Tariff.Response
{
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Common.Mappers;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;
    using Microsoft.AspNetCore.Mvc;

    internal static class GetTariffsResponseMapper
    {
        public static GetTariffsResponseMessage ToGetTariffsResponseMessage(this GetTariffsResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new GetTariffsResponseMessage()
            {
                Tariffs = dto.Tariffs.ToTariffResponseMessage()
            };
        }

        public static ActionResult<GetTariffsResponseMessage> ToActionResult(this Result<GetTariffsResponseDto> result)
        {
            return result.ToActionResult(ToGetTariffsResponseMessage);
        }
    }
}
