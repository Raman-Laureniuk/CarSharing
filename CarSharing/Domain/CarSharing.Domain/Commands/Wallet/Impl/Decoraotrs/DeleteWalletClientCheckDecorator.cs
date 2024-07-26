namespace CarSharing.Domain.Commands.Wallet.Impl.Decoraotrs
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Wallet;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;

    internal class DeleteWalletClientCheckDecorator : IDeleteWalletCommandAsync
    {
        private readonly ICheckWalletForClientCommandAsync _checkWalletForClientCommand;
        private readonly IDeleteWalletCommandAsync _decoratee;

        public DeleteWalletClientCheckDecorator(ICheckWalletForClientCommandAsync checkWalletForClientCommand,
            IDeleteWalletCommandAsync decoratee)
        {
            _checkWalletForClientCommand = checkWalletForClientCommand ?? throw new ArgumentNullException(nameof(checkWalletForClientCommand));
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public async Task<DeleteWalletResponseDto> ExecuteAsync(DeleteWalletRequestDto request)
        {
            if (request != null)
            {
                await ThrowIfWalletIsNotClients(request.ClientId, request.WalletId);
            }

            return await _decoratee.ExecuteAsync(request);
        }

        private async Task ThrowIfWalletIsNotClients(Guid clientId, int walletId)
        {
            bool isClientsWallet = await IsClientsWallet(clientId, walletId);

            if (!isClientsWallet)
            {
                throw new ArgumentException($"Wallet {walletId} doesn't belong to client {clientId}.");
            }
        }

        private async Task<bool> IsClientsWallet(Guid clientId, int walletId)
        {
            CheckWalletForClientRequestDto request = new CheckWalletForClientRequestDto()
            {
                ClientId = clientId,
                WalletId = walletId
            };

            CheckWalletForClientResponseDto response = await _checkWalletForClientCommand.ExecuteAsync(request);

            return response?.DoesWalletBelongToClient ?? false;
        }
    }
}
