namespace CarSharing.Domain.Commands.Ride.End.Impl.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride.End;
    using CarSharing.Domain.Dto.CarControl.Request;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Providers.CarControl;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class EndRideCarControlDecorator : IEndRideCommandAsync
    {
        private readonly IRideRepositoryFactory _repoFactory;
        private readonly ICarControlProvider _carControlProvider;
        private readonly IEndRideCommandAsync _decoratee;

        public EndRideCarControlDecorator(IRideRepositoryFactory repoFactory,
            ICarControlProvider carControlProvider,
            IEndRideCommandAsync decoratee)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
            _carControlProvider = carControlProvider ?? throw new ArgumentNullException(nameof(carControlProvider));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<EndRideResponseDto> ExecuteAsync(EndRideRequestDto request)
        {
            try
            {
                return await _decoratee.ExecuteAsync(request);
            }
            finally
            {
                if (request != null)
                {
                    Guid carId = await GetCarIdAsync(request.RideId);

                    await _carControlProvider.LockCarAsync(new LockRequestDto()
                    {
                        CarId = carId
                    });
                }
            }
        }

        private async Task<Guid> GetCarIdAsync(int rideId)
        {
            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                Ride ride = await repo.GetByIdAsync(rideId);

                return ride.CarId;
            }
        }
    }
}
