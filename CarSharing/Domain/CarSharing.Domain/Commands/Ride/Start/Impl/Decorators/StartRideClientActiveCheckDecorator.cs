namespace CarSharing.Domain.Commands.Ride.Start.Impl.Decorators
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride.Start;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Exceptions;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;

    internal class StartRideClientActiveCheckDecorator : IStartRideCommandAsync
    {
        private readonly IClientRepositoryFactory _repoFactory;
        private readonly IStartRideCommandAsync _decoratee;

        public StartRideClientActiveCheckDecorator(IClientRepositoryFactory repoFactory,
            IStartRideCommandAsync decoratee)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<StartRideResponseDto> ExecuteAsync(StartRideRequestDto request)
        {
            if (request != null)
            {
                await ThrowIfClientNotActive(request.ClientId).ConfigureAwait(false);
            }

            return await _decoratee.ExecuteAsync(request).ConfigureAwait(false);
        }

        private async Task ThrowIfClientNotActive(Guid clientId)
        {
            bool isClientActive = await IsClientActive(clientId).ConfigureAwait(false);

            if (!isClientActive)
            {
                throw new ClientNotActiveException($"Client {clientId} is not active.");
            }
        }

        private async Task<bool> IsClientActive(Guid clientId)
        {
            using (IClientRepository repo = _repoFactory.CreateRepository())
            {
                Client client = await repo.GetByIdAsync(clientId).ConfigureAwait(false);

                if (client == null)
                {
                    throw new NotFoundException($"Client {clientId} not found.");
                }

                return client.IsActive;
            }
        }
    }
}
