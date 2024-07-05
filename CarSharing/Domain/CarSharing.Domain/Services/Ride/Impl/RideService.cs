namespace CarSharing.Domain.Services.Ride.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;

    internal class RideService : IRideService
    {
        private readonly IStartRideCommandAsync _startRideCommand;
        private readonly IEndRideCommandAsync _endRideCommand;
        private readonly IGetRideHistoryCommandAsync _getRideHistoryCommand;

        public RideService(IStartRideCommandAsync startRideCommand,
            IEndRideCommandAsync endRideCommand,
            IGetRideHistoryCommandAsync getRideHistoryCommand)
        {
            _startRideCommand = startRideCommand ?? throw new ArgumentNullException(nameof(startRideCommand));
            _endRideCommand = endRideCommand ?? throw new ArgumentNullException(nameof(endRideCommand));
            _getRideHistoryCommand = getRideHistoryCommand ?? throw new ArgumentNullException(nameof(getRideHistoryCommand));
        }

        public Task<StartRideResponseDto> StartRideAsync(StartRideRequestDto request)
        {
            return _startRideCommand.ExecuteAsync(request);
        }

        public Task<EndRideResponseDto> EndRideAsync(EndRideRequestDto request)
        {
            return _endRideCommand.ExecuteAsync(request);
        }

        public Task<GetRideHistoryResponseDto> GetRideHistoryAsync(GetRideHistoryRequestDto request)
        {
            return _getRideHistoryCommand.ExecuteAsync(request);
        }
    }
}
