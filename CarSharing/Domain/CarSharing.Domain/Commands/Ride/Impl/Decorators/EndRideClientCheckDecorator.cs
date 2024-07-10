namespace CarSharing.Domain.Commands.Ride.Impl.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class EndRideClientCheckDecorator : IEndRideCommandAsync
    {
        private IRideRepositoryFactory _repoFactory;
        private readonly IEndRideCommandAsync _decoratee;

        public EndRideClientCheckDecorator(IRideRepositoryFactory repoFactory,
            IEndRideCommandAsync decoratee)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<EndRideResponseDto> ExecuteAsync(EndRideRequestDto request)
        {
            if (request != null)
            {
                await ThrowIfWrongClient(request.RideId, request.ClientId);
            }

            return await _decoratee.ExecuteAsync(request);
        }

        private async Task ThrowIfWrongClient(int rideId, Guid clientId)
        {
            Guid rideClientId = await GetRideClientId(rideId);

            if (rideClientId != clientId)
            {
                throw new ArgumentException($"Ride {rideId} doesn't belong to client {clientId}.");
            }
        }

        private async Task<Guid> GetRideClientId(int rideId)
        {
            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                Ride ride = await repo.GetByIdAsync(rideId);

                return ride.ClientId;
            }
        }
    }
}
