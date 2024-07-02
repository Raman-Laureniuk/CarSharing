namespace CarSharing.Domain.Services.Tariff
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;

    public interface ITariffService
    {
        Task<AddTariffResponseDto> AddTariffAsync(AddTariffRequestDto request);
        Task<UpdateTariffResponseDto> UpdateTariffAsync(UpdateTariffRequestDto request);
        Task<DeleteTariffResponseDto> DeleteTariffAsync(DeleteTariffRequestDto request);
        Task<GetTariffsResponseDto> GetTariffsAsync(GetTariffsRequestDto request);
    }
}
