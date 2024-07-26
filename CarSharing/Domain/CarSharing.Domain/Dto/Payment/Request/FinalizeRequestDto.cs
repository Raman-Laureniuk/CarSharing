namespace CarSharing.Domain.Dto.Payment.Request
{
    public class FinalizeRequestDto
    {
        public string TransactionId { get; set; }
        public decimal FinalizeAmount { get; set; }
    }
}
