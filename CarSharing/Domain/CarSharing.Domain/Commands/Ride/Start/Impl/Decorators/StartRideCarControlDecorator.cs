namespace CarSharing.Domain.Commands.Ride.Start.Impl.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride.Start;
    using CarSharing.Domain.Dto.CarControl.Request;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Providers.CarControl;

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

        public async Task<StartRideResponseDto> ExecuteAsync(StartRideRequestDto request)
        {
            StartRideResponseDto response = await _decoratee.ExecuteAsync(request).ConfigureAwait(false);

            if (request != null && response?.Success == true)
            {
                await _carControlProvider.UnlockCarAsync(new UnlockRequestDto()
                {
                    CarId = request.CarId
                }).ConfigureAwait(false);
            }

            return response;
        }
    }
}
