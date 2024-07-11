namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class WalletMessageMapper
    {
        public static WalletMessage ToWalletMessage(this WalletDto walletDto)
        {
            if (walletDto == null)
            {
                return null;
            }

            return new WalletMessage()
            {
                WalletId = walletDto.WalletId,
                ClientId = walletDto.ClientId
            };
        }

        public static List<WalletMessage> ToWalletMessage(this IEnumerable<WalletDto> walletDto)
        {
            return walletDto
                .OrEmptyIfNull()
                .Select(ToWalletMessage)
                .ToList();
        }
    }
}
