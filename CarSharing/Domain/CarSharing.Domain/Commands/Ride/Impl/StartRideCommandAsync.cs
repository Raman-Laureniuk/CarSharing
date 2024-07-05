namespace CarSharing.Domain.Commands.Ride.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride;
    using CarSharing.Domain.Commands.Wallet;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Exceptions.Ride;
    using CarSharing.Domain.Mappers.Ride.Request;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class StartRideCommandAsync : IStartRideCommandAsync
    {
        private readonly IGetWalletsCommandAsync _getWalletsCommand;
        private readonly IRideRepositoryFactory _repoFactory;

        public StartRideCommandAsync(IGetWalletsCommandAsync getWalletsCommand,
            IRideRepositoryFactory repoFactory)
        {
            _getWalletsCommand = getWalletsCommand ?? throw new ArgumentNullException(nameof(getWalletsCommand));
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<StartRideResponseDto> ExecuteAsync(StartRideRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await ThrowIfWalletIsNotClients(request.ClientId, request.WalletId);  // TODO: move to decorator.

            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                List<Ride> activeRides = await repo.GetRidesForCarAsync(request.ClientId, RideStatus.Active);

                if (activeRides?.Any() ?? false)
                {
                    throw new CarInUseException($"Car {request.CarId} is already in use.");
                }

                Ride ride = request.ToRideEntity();

                await repo.CreateAsync(ride, true);

                return new StartRideResponseDto()
                {
                    Success = true,
                    RideId = ride.Id,
                    StartDateUtc = ride.StartDateUtc
                };
            }
        }

        private async Task<bool> IsClientsWallet(Guid clientId, int walletId)
        {
            GetWalletsRequestDto request = new GetWalletsRequestDto()
            {
                ClientId = clientId
            };

            GetWalletsResponseDto walletsResponse = await _getWalletsCommand.ExecuteAsync(request);

            return walletsResponse
                ?.Wallets
                ?.Select(x => x.WalletId)
                .Contains(walletId) ?? false;
        }

        private async Task ThrowIfWalletIsNotClients(Guid clientId, int walletId)
        {
            bool isClientsWallet = await IsClientsWallet(clientId, walletId);

            if (!isClientsWallet)
            {
                throw new ArgumentException($"Wallet {walletId} doesn't belong to client {clientId}.");
            }
        }
    }
}
