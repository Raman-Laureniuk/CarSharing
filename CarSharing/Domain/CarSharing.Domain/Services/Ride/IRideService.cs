namespace CarSharing.Domain.Services.Ride
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Tools.Result;

    public interface IRideService
    {
        Task<Result<StartRideResponseDto>> StartRideAsync(StartRideRequestDto request);
        Task<Result<EndRideResponseDto>> EndRideAsync(EndRideRequestDto request);
        Task<Result<GetRideHistoryResponseDto>> GetRideHistoryAsync(GetRideHistoryRequestDto request);
    }
}
