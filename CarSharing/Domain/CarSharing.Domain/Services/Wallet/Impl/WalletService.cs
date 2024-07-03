namespace CarSharing.Domain.Services.Wallet.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Wallet;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;

    internal class WalletService : IWalletService
    {
        private readonly IAddWalletCommandAsync _addWalletCommand;
        private readonly IDeleteWalletCommandAsync _deleteWalletCommand;
        private readonly IGetWalletsCommandAsync _getWalletsCommand;

        public WalletService(IAddWalletCommandAsync addWalletCommand,
            IDeleteWalletCommandAsync deleteWalletCommand,
            IGetWalletsCommandAsync getWalletsCommand)
        {
            _addWalletCommand = addWalletCommand ?? throw new ArgumentNullException(nameof(addWalletCommand));
            _deleteWalletCommand = deleteWalletCommand ?? throw new ArgumentNullException(nameof(deleteWalletCommand));
            _getWalletsCommand = getWalletsCommand ?? throw new ArgumentNullException(nameof(getWalletsCommand));
        }

        public Task<AddWalletResponseDto> AddWalletAsync(AddWalletRequestDto request)
        {
            return _addWalletCommand.ExecuteAsync(request);
        }

        public Task<DeleteWalletResponseDto> DeleteWalletAsync(DeleteWalletRequestDto request)
        {
            return _deleteWalletCommand.ExecuteAsync(request);
        }

        public Task<GetWalletsResponseDto> GetWalletsAsync(GetWalletsRequestDto request)
        {
            return _getWalletsCommand.ExecuteAsync(request);
        }
    }
}
