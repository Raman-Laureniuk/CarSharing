namespace CarSharing.Domain.Mappers.Wallet.Response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Tools.Extensions;

    internal static class GetWalletsResponseMapper
    {
        public static WalletDto ToWalletDto(this Wallet wallet)
        {
            if (wallet == null)
            {
                throw new ArgumentNullException(nameof(wallet));
            }

            return new WalletDto()
            {
                ClientId = wallet.ClientId,
                EncryptedWalletData = wallet.EncryptedWalletData
            };
        }

        public static List<WalletDto> ToWalletDto(this IEnumerable<Wallet> wallets)
        {
            return wallets
                .OrEmptyIfNull()
                .Select(ToWalletDto)
                .ToList();
        }

        public static GetWalletsResponseDto ToGetWalletsResponseDto(this IEnumerable<Wallet> wallets)
        {
            return new GetWalletsResponseDto()
            {
                Wallets = wallets.ToWalletDto()
            };
        }
    }
}
