namespace CarSharing.WebApi.Client.Mappers.Wallet.Request
{
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.WebApi.Client.Messages.Wallet.Request;

    internal static class DeleteWalletRequestMessageMapper
    {
        public static DeleteWalletRequestDto ToDeleteWalletRequestDto(this DeleteWalletRequestMessage deleteWalletRequestMessage)
        {
            if (deleteWalletRequestMessage == null)
            {
                return null;
            }

            return new DeleteWalletRequestDto()
            {
                WalletId = deleteWalletRequestMessage.WalletId
            };
        }
    }
}
