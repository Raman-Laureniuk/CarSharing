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
        private readonly ICheckWalletForClientCommandAsync _checkWalletForClientCommand;

        public WalletService(IAddWalletCommandAsync addWalletCommand,
            IDeleteWalletCommandAsync deleteWalletCommand,
            IGetWalletsCommandAsync getWalletsCommand,
            ICheckWalletForClientCommandAsync checkWalletForClientCommand)
        {
            _addWalletCommand = addWalletCommand ?? throw new ArgumentNullException(nameof(addWalletCommand));
            _deleteWalletCommand = deleteWalletCommand ?? throw new ArgumentNullException(nameof(deleteWalletCommand));
            _getWalletsCommand = getWalletsCommand ?? throw new ArgumentNullException(nameof(getWalletsCommand));
            _checkWalletForClientCommand = checkWalletForClientCommand ?? throw new ArgumentNullException(nameof(checkWalletForClientCommand));
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

        public Task<CheckWalletForClientResponseDto> CheckWalletForClientAsync(CheckWalletForClientRequestDto request)
        {
            return _checkWalletForClientCommand.ExecuteAsync(request);
        }
    }
}
