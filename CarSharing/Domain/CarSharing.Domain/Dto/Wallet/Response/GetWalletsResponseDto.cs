namespace CarSharing.Domain.Dto.Wallet.Response
{
    using System.Collections.Generic;

    public class GetWalletsResponseDto
    {
        public List<WalletDto> Wallets { get; set; }
    }
}
