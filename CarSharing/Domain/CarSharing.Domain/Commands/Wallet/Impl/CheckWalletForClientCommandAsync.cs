namespace CarSharing.Domain.Commands.Wallet.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Wallet;
    using CarSharing.Domain.RepositoryFactory.Wallet;

    internal class CheckWalletForClientCommandAsync : ICheckWalletForClientCommandAsync
    {
        private readonly IWalletRepositoryFactory _repoFactory;

        public CheckWalletForClientCommandAsync(IWalletRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<CheckWalletForClientResponseDto> ExecuteAsync(CheckWalletForClientRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Wallet wallet = await GetWalletAsync(request.WalletId);

            bool doesWalletBelongToClient = wallet?.ClientId == request.ClientId;

            return new CheckWalletForClientResponseDto()
            {
                ClientId = request.ClientId,
                WalletId = request.WalletId,
                DoesWalletBelongToClient = doesWalletBelongToClient
            };
        }

        private async Task<Wallet> GetWalletAsync(int walletId)
        {
            using (IWalletRepository repo = _repoFactory.CreateRepository())
            {
                return await repo.GetByIdAsync(walletId);
            }
        }
    }
}
