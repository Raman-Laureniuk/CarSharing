namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class AddWalletResponseMessageMapper
    {
        public static AddWalletResponseMessage ToAddWalletResponseMessage(this AddWalletResponseDto addWalletResponseDto)
        {
            if (addWalletResponseDto == null)
            {
                return null;
            }

            return new AddWalletResponseMessage()
            {
                WalletId = addWalletResponseDto.WalletId
            };
        }
    }
}
