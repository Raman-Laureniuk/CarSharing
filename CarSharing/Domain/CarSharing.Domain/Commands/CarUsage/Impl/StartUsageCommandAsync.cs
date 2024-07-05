namespace CarSharing.Domain.Commands.CarUsage.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Wallet;
    using CarSharing.Domain.Constants;
    using CarSharing.Domain.Dto.CarUsage.Request;
    using CarSharing.Domain.Dto.CarUsage.Response;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Exceptions.CarUsage;
    using CarSharing.Domain.Mappers.CarUsage.Request;
    using CarSharing.Domain.Repository.CarUsage;
    using CarSharing.Domain.RepositoryFactory.CarUsage;

    internal class StartUsageCommandAsync : IStartUsageCommandAsync
    {
        private readonly IGetWalletsCommandAsync _getWalletsCommand;
        private readonly ICarUsageRepositoryFactory _repoFactory;

        public StartUsageCommandAsync(IGetWalletsCommandAsync getWalletsCommand,
            ICarUsageRepositoryFactory repoFactory)
        {
            _getWalletsCommand = getWalletsCommand ?? throw new ArgumentNullException(nameof(getWalletsCommand));
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<StartUsageResponseDto> ExecuteAsync(StartUsageRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await ThrowIfWalletIsNotClients(request.ClientId, request.WalletId);  // TODO: move to decorator.

            using (ICarUsageRepository repo = _repoFactory.CreateRepository())
            {
                List<CarUsage> activeCarUsages = await repo.GetCarUsages(request.ClientId, CarUsageStatusNameKeys.ACTIVE);

                if (activeCarUsages.Any())
                {
                    throw new CarInUseException($"Car {request.CarId} is already in use.");
                }

                CarUsage carUsage = request.ToCarUsageEntity();

                await repo.CreateAsync(carUsage, true);

                return new StartUsageResponseDto()
                {
                    Success = true,
                    CarUsageId = carUsage.Id,
                    StartUsageTimeUtc = carUsage.StartDateUtc
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
