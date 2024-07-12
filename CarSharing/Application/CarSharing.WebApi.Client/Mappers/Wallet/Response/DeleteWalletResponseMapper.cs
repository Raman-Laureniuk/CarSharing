namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class DeleteWalletResponseMapper
    {
        public static DeleteWalletResponseMessage ToDeleteWalletResponseMessage(this DeleteWalletResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new DeleteWalletResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
