namespace CarSharing.WebApi.Client.Mappers.Wallet.Request
{
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.WebApi.Client.Messages.Wallet.Request;

    internal static class GetWalletsRequestMessageMapper
    {
        public static GetWalletsRequestDto ToGetWalletsRequestDto(this GetWalletsRequestMessage getWalletsRequestMessage)
        {
            if (getWalletsRequestMessage == null)
            {
                return null;
            }

            return new GetWalletsRequestDto()
            {
                ClientId = getWalletsRequestMessage.ClientId
            };
        }
    }
}
