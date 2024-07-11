namespace CarSharing.WebApi.Client.Messages.Wallet.Response
{
    using System.Collections.Generic;

    public class GetWalletsResponseMessage
    {
        public List<WalletMessage> Wallets { get; set; }
    }
}
