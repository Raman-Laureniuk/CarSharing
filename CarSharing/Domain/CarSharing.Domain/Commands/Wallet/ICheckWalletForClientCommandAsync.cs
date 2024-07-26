namespace CarSharing.Domain.Commands.Wallet
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;

    internal interface ICheckWalletForClientCommandAsync : ICommandAsync<CheckWalletForClientRequestDto, CheckWalletForClientResponseDto>
    {
    }
}
