namespace CarSharing.Domain.Providers.Payment
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Payment.Request;
    using CarSharing.Domain.Dto.Payment.Response;

    public interface IPaymentProvider
    {
        Task<AuthorizeResponseDto> AuthorizeAsync(AuthorizeRequestDto request);
        Task<FinalizeResponseDto> FinalizeAsync(FinalizeRequestDto request);
        Task<CancelResponseDto> CancelAsync(CancelRequestDto request);
    }
}
