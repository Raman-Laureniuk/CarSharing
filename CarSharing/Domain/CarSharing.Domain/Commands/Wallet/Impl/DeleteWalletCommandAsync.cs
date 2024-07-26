namespace CarSharing.Domain.Commands.Wallet.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Repository.Wallet;
    using CarSharing.Domain.RepositoryFactory.Wallet;

    internal class DeleteWalletCommandAsync : IDeleteWalletCommandAsync
    {
        private readonly IWalletRepositoryFactory _repoFactory;

        public DeleteWalletCommandAsync(IWalletRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<DeleteWalletResponseDto> ExecuteAsync(DeleteWalletRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (IWalletRepository repo = _repoFactory.CreateRepository())
            {
                await repo.DeleteAsync(request.WalletId, true);
            }

            return new DeleteWalletResponseDto()
            {
                Success = true
            };
        }
    }
}
