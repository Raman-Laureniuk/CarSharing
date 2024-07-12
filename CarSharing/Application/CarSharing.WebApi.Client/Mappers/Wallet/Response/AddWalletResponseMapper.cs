namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class AddWalletResponseMapper
    {
        public static AddWalletResponseMessage ToAddWalletResponseMessage(this AddWalletResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new AddWalletResponseMessage()
            {
                WalletId = dto.WalletId
            };
        }
    }
}
