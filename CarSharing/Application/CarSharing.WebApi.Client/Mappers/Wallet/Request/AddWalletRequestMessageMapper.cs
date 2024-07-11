namespace CarSharing.WebApi.Client.Mappers.Wallet.Request
{
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.WebApi.Client.Messages.Wallet.Request;

    internal static class AddWalletRequestMessageMapper
    {
        public static AddWalletRequestDto ToAddWalletRequestDto(this AddWalletRequestMessage addWalletRequestMessage)
        {
            if (addWalletRequestMessage == null)
            {
                return null;
            }

            return new AddWalletRequestDto()
            {
                ClientId = addWalletRequestMessage.ClientId,
                EncryptedWalletData = addWalletRequestMessage.EncryptedWalletData
            };
        }
    }
}
