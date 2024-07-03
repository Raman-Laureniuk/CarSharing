namespace CarSharing.Domain.Mappers.Wallet.Request
{
    using System;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Entities;

    internal static class AddWalletRequestMapper
    {
        public static Wallet ToWalletEntity(this AddWalletRequestDto addWalletRequestDto)
        {
            if (addWalletRequestDto == null)
            {
                throw new ArgumentNullException(nameof(addWalletRequestDto));
            }

            return new Wallet()
            {
                ClientId = addWalletRequestDto.ClientId,
                EncryptedWalletData = addWalletRequestDto.EncryptedWalletData
            };
        }
    }
}
