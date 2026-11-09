namespace CarSharing.Domain.Commands.Wallet
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Wallet.Request;

    internal interface IDeleteWalletCommandAsync : ICommandAsync<DeleteWalletRequestDto>
    {
    }
}
