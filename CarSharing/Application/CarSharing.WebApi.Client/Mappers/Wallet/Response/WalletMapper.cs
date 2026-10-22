namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;

    internal static class WalletMapper
    {
        public static WalletResponseMessage ToWalletResponseMessage(this WalletDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new WalletResponseMessage()
            {
                WalletId = dto.WalletId,
                ClientId = dto.ClientId
            };
        }

        public static List<WalletResponseMessage> ToWalletResponseMessage(this IEnumerable<WalletDto> dto)
        {
            return dto
                .OrEmptyIfNull()
                .Select(ToWalletResponseMessage)
                .ToList();
        }
    }
}
