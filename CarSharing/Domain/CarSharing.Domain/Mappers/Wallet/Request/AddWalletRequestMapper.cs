namespace CarSharing.Domain.Mappers.Wallet.Request
{
    using System;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Entities;

    internal static class AddWalletRequestMapper
    {
        public static Wallet ToWalletEntity(this AddWalletRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Wallet()
            {
                ClientId = dto.ClientId,
                EncryptedWalletData = dto.EncryptedWalletData
            };
        }
    }
}
