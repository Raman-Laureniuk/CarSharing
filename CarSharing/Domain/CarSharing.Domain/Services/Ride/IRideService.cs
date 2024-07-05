namespace CarSharing.Domain.Services.Ride
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;

    public interface IRideService
    {
        Task<StartRideResponseDto> StartRideAsync(StartRideRequestDto request);
        Task<EndRideResponseDto> EndRideAsync(EndRideRequestDto request);
        Task<GetRideHistoryResponseDto> GetRideHistoryAsync(GetRideHistoryRequestDto request);
    }
}
