namespace CarSharing.Domain.Dto.Tariff.Response
{
    using System.Collections.Generic;

    public class GetTariffsResponseDto
    {
        public List<TariffDto> Tariffs { get; set; }
    }
}
