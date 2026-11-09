namespace CarSharing.Domain.Commands.Ride.Start.Impl.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride.Start;
    using CarSharing.Domain.Dto.CarControl.Request;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Providers.CarControl;
    using CarSharing.Domain.Tools.Result;

    internal class StartRideCarControlDecorator : IStartRideCommandAsync
    {
        private readonly ICarControlProvider _carControlProvider;
        private readonly IStartRideCommandAsync _decoratee;

        public StartRideCarControlDecorator(ICarControlProvider carControlProvider,
            IStartRideCommandAsync decoratee)
        {
            _carControlProvider = carControlProvider ?? throw new ArgumentNullException(nameof(carControlProvider));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<Result<StartRideResponseDto>> ExecuteAsync(StartRideRequestDto request)
        {
            Result<StartRideResponseDto> result = await _decoratee.ExecuteAsync(request).ConfigureAwait(false);

            if (request != null && result.IsSuccess)
            {
                await _carControlProvider.UnlockCarAsync(new UnlockRequestDto()
                {
                    CarId = request.CarId
                }).ConfigureAwait(false);
            }

            return result;
        }
    }
}
