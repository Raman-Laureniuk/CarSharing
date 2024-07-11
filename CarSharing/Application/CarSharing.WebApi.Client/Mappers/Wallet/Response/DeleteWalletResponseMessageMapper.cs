namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class DeleteWalletResponseMessageMapper
    {
        public static DeleteWalletResponseMessage ToDeleteWalletResponseMessage(this DeleteWalletResponseDto deleteWalletResponseDto)
        {
            if (deleteWalletResponseDto == null)
            {
                return null;
            }

            return new DeleteWalletResponseMessage()
            {
                Success = deleteWalletResponseDto.Success
            };
        }
    }
}
