namespace CarSharing.Domain.Dto.Payment.Request
{
    public class AuthorizeRequestDto
    {
        public string EncryptedWalletData { get; set; }
        public decimal AuthorizeAmount { get; set; }
    }
}
