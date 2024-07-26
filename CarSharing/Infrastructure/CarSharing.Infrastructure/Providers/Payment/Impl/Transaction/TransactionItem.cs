namespace CarSharing.Infrastructure.Providers.Payment.Impl.Transaction
{
    internal class TransactionItem
    {
        public string TransactionId { get; set; }
        public decimal AuthorizeAmount { get; set; }
        public decimal? FinalizeAmount { get; set; }
        public string EncryptedWalletData { get; set; }
    }
}
