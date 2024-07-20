namespace CarSharing.WebApi.Client.Mappers.Wallet.Request
{
    using System;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.WebApi.Client.Messages.Wallet.Request;

    internal static class AddWalletRequestMapper
    {
        public static AddWalletRequestDto ToAddWalletRequestDto(this AddWalletRequestMessage message, Guid clientId)
        {
            if (message == null)
            {
                return null;
            }

            return new AddWalletRequestDto()
            {
                ClientId = clientId,
                EncryptedWalletData = message.EncryptedWalletData
            };
        }
    }
}
