namespace CarSharing.Domain.Commands.Ride.End.Impl.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride.End;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Exceptions;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class EndRideCheckDecorator : IEndRideCommandAsync
    {
        private IRideRepositoryFactory _repoFactory;
        private readonly IEndRideCommandAsync _decoratee;

        public EndRideCheckDecorator(IRideRepositoryFactory repoFactory,
            IEndRideCommandAsync decoratee)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<EndRideResponseDto> ExecuteAsync(EndRideRequestDto request)
        {
            if (request != null)
            {
                await CheckRideAsync(request.RideId, request.ClientId).ConfigureAwait(false);
            }

            return await _decoratee.ExecuteAsync(request).ConfigureAwait(false);
        }

        private async Task CheckRideAsync(int rideId, Guid clientId)
        {
            Ride ride = await GetRideAsync(rideId).ConfigureAwait(false);

            if (ride.ClientId != clientId)
            {
                throw new ArgumentException($"Ride {rideId} doesn't belong to client {clientId}.");
            }

            if (ride.Status != RideStatus.Active)
            {
                throw new WrongStatusException($"Ride {ride.RideId} has wrong status {ride.Status}.");
            }
        }

        private async Task<Ride> GetRideAsync(int rideId)
        {
            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                return await repo.GetByIdAsync(rideId).ConfigureAwait(false);
            }
        }
    }
}
