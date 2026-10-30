namespace CarSharing.Domain.Commands.Wallet.Impl.Decoraotrs
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Wallet;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Tools.Result;

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

        public async Task<Result> ExecuteAsync(DeleteWalletRequestDto request)
        {
            if (request != null)
            {
                await ThrowIfWalletIsNotClients(request.ClientId, request.WalletId).ConfigureAwait(false);  // TODO: Return failed result.
            }

            return await _decoratee.ExecuteAsync(request).ConfigureAwait(false);
        }

        private async Task ThrowIfWalletIsNotClients(Guid clientId, int walletId)
        {
            bool isClientsWallet = await IsClientsWallet(clientId, walletId).ConfigureAwait(false);

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

            Result<CheckWalletForClientResponseDto> result = await _checkWalletForClientCommand.ExecuteAsync(request).ConfigureAwait(false);

            return result.Value?.DoesWalletBelongToClient ?? false;  // TODO: Check result status.
        }
    }
}
