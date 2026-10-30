namespace CarSharing.Domain.Services.Tariff
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Tools.Result;

    public interface ITariffService
    {
        Task<Result<AddTariffResponseDto>> AddTariffAsync(AddTariffRequestDto request);
        Task<Result> UpdateTariffAsync(UpdateTariffRequestDto request);
        Task<Result> DeleteTariffAsync(DeleteTariffRequestDto request);
        Task<Result<GetTariffsResponseDto>> GetTariffsAsync(GetTariffsRequestDto request);
        Result<CalculatePriceResponseDto> CalculatePrice(CalculatePriceRequestDto request);
    }
}
