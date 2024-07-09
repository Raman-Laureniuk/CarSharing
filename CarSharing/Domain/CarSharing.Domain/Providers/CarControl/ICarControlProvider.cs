namespace CarSharing.Domain.Providers.CarControl
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.CarControl.Request;
    using CarSharing.Domain.Dto.CarControl.Response;

    internal interface ICarControlProvider
    {
        Task<LockResponseDto> LockCarAsync(LockRequestDto request);
        Task<UnlockResponseDto> UnlockCarAsync(UnlockRequestDto request);
    }
}
