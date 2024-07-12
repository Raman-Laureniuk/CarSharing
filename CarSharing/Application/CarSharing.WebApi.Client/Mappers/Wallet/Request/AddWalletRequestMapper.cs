namespace CarSharing.WebApi.Client.Mappers.Wallet.Request
{
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.WebApi.Client.Messages.Wallet.Request;

    internal static class AddWalletRequestMapper
    {
        public static AddWalletRequestDto ToAddWalletRequestDto(this AddWalletRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new AddWalletRequestDto()
            {
                ClientId = message.ClientId,
                EncryptedWalletData = message.EncryptedWalletData
            };
        }
    }
}
