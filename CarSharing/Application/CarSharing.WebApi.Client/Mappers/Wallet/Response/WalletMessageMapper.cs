namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class WalletMessageMapper
    {
        public static WalletMessage ToWalletMessage(this WalletDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new WalletMessage()
            {
                WalletId = dto.WalletId,
                ClientId = dto.ClientId
            };
        }

        public static List<WalletMessage> ToWalletMessage(this IEnumerable<WalletDto> dto)
        {
            return dto
                .OrEmptyIfNull()
                .Select(ToWalletMessage)
                .ToList();
        }
    }
}
