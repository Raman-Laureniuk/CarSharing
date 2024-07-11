namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class GetWalletsResponseMessageMapper
    {
        public static GetWalletsResponseMessage ToGetWalletsResponseMessage(this GetWalletsResponseDto getWalletsResponseDto)
        {
            if (getWalletsResponseDto == null)
            {
                return null;
            }

            return new GetWalletsResponseMessage()
            {
                Wallets = getWalletsResponseDto.Wallets.ToWalletMessage()
            };
        }
    }
}
