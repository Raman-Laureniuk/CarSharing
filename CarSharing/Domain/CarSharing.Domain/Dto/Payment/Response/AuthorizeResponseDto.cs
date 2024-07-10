namespace CarSharing.Domain.Dto.Payment.Response
{
    public class AuthorizeResponseDto
    {
        public bool Success { get; set; }
        public string TransactionId { get; set; }
    }
}
