namespace CarSharing.Domain.Dto.Payment.Request
{
    public class FinalizeRequestDto
    {
        public string AuthorizeToken { get; set; }
        public decimal FinalizeAmount { get; set; }
    }
}
