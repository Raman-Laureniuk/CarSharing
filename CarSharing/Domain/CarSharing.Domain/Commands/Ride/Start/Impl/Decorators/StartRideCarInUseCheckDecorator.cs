namespace CarSharing.Domain.Commands.Ride.Start.Impl.Decorators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride.Start;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Exceptions.Ride;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class StartRideCarInUseCheckDecorator : IStartRideCommandAsync
    {
        private readonly IRideRepositoryFactory _repoFactory;
        private readonly IStartRideCommandAsync _decoratee;

        public StartRideCarInUseCheckDecorator(IRideRepositoryFactory repoFactory,
            IStartRideCommandAsync decoratee)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<StartRideResponseDto> ExecuteAsync(StartRideRequestDto request)
        {
            if (request != null)
            {
                await ThrowIfCarInUse(request.CarId);
            }

            return await _decoratee.ExecuteAsync(request);
        }

        private async Task ThrowIfCarInUse(Guid carId)
        {
            bool isCarInUse = await IsCarInUse(carId);

            if (isCarInUse)
            {
                throw new CarInUseException($"Car {carId} is already in use.");
            }
        }

        private async Task<bool> IsCarInUse(Guid carId)
        {
            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                List<Ride> activeRides = await repo.GetRidesForCarAsync(carId, RideStatus.Active);

                return activeRides.Any();
            }
        }
    }
}
