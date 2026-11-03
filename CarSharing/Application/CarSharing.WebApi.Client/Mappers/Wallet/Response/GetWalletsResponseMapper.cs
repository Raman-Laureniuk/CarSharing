namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;
    using CarSharing.WebApi.Common.Mappers;
    using Microsoft.AspNetCore.Mvc;

    internal static class GetWalletsResponseMapper
    {
        public static GetWalletsResponseMessage ToGetWalletsResponseMessage(this GetWalletsResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new GetWalletsResponseMessage()
            {
                Wallets = dto.Wallets.ToWalletResponseMessage()
            };
        }

        public static ActionResult<GetWalletsResponseMessage> ToActionResult(this Result<GetWalletsResponseDto> result)
        {
            return result.ToActionResult(ToGetWalletsResponseMessage);
        }
    }
}
