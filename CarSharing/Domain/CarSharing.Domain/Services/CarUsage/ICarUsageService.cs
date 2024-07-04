namespace CarSharing.Domain.Services.CarUsage
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.CarUsage.Request;
    using CarSharing.Domain.Dto.CarUsage.Response;

    public interface ICarUsageService
    {
        Task<StartUsageResponseDto> StartUsageAsync(StartUsageRequestDto request);
        Task<EndUsageResponseDto> EndUsageAsync(EndUsageRequestDto request);
        Task<GetUsageHistoryResponseDto> GetUsageHistoryAsync(GetUsageHistoryReuqestDto request);
    }
}
