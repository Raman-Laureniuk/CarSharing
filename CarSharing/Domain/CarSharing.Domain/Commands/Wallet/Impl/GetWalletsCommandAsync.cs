namespace CarSharing.Domain.Commands.Wallet.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Wallet.Response;
    using CarSharing.Domain.Repository.Wallet;
    using CarSharing.Domain.RepositoryFactory.Wallet;

    internal class GetWalletsCommandAsync : IGetWalletsCommandAsync
    {
        private readonly IWalletRepositoryFactory _repoFactory;

        public GetWalletsCommandAsync(IWalletRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<GetWalletsResponseDto> ExecuteAsync(GetWalletsRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (IWalletRepository repo = _repoFactory.CreateRepository())
            {
                List<Wallet> wallets = await repo.GetWalletsForClient(request.ClientId).ConfigureAwait(false);

                return wallets.ToGetWalletsResponseDto();
            }
        }
    }
}
