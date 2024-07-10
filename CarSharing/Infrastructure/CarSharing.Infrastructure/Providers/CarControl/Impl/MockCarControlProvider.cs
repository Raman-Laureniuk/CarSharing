namespace CarSharing.Infrastructure.Providers.CarControl.Impl
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.CarControl.Request;
    using CarSharing.Domain.Dto.CarControl.Response;
    using CarSharing.Domain.Providers.CarControl;

    public class MockCarControlProvider : ICarControlProvider
    {
        public Task<LockResponseDto> LockCarAsync(LockRequestDto request)
        {
            return Task.FromResult(new LockResponseDto()
            {
                Success = true
            });
        }

        public Task<UnlockResponseDto> UnlockCarAsync(UnlockRequestDto request)
        {
            return Task.FromResult(new UnlockResponseDto()
            {
                Success = true
            });
        }
    }
}
