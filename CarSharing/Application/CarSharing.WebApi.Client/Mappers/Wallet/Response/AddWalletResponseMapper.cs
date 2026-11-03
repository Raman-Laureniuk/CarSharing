namespace CarSharing.WebApi.Client.Mappers.Wallet.Response
{
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;
    using CarSharing.WebApi.Common.Mappers;
    using Microsoft.AspNetCore.Mvc;

    internal static class AddWalletResponseMapper
    {
        public static AddWalletResponseMessage ToAddWalletResponseMessage(this AddWalletResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new AddWalletResponseMessage()
            {
                WalletId = dto.WalletId
            };
        }

        public static ActionResult<AddWalletResponseMessage> ToActionResult(this Result<AddWalletResponseDto> result)
        {
            return result.ToActionResult(ToAddWalletResponseMessage);
        }
    }
}
