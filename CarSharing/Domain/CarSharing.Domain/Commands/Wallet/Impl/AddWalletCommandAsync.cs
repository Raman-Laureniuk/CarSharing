namespace CarSharing.Domain.Commands.Wallet.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Wallet.Request;
    using CarSharing.Domain.Repository.Wallet;
    using CarSharing.Domain.RepositoryFactory.Wallet;

    internal class AddWalletCommandAsync : IAddWalletCommandAsync
    {
        private readonly IWalletRepositoryFactory _repoFactory;

        public AddWalletCommandAsync(IWalletRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<AddWalletResponseDto> ExecuteAsync(AddWalletRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Wallet wallet = request.ToWalletEntity();

            using (IWalletRepository repo = _repoFactory.CreateRepository())
            {
                await repo.CreateAsync(wallet, true);
            }

            return new AddWalletResponseDto()
            {
                WalletId = wallet.WalletId
            };
        }
    }
}
