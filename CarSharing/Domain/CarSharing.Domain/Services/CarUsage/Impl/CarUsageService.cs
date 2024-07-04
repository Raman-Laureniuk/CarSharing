namespace CarSharing.Domain.Services.CarUsage.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.CarUsage;
    using CarSharing.Domain.Dto.CarUsage.Request;
    using CarSharing.Domain.Dto.CarUsage.Response;

    internal class CarUsageService : ICarUsageService
    {
        private readonly IStartUsageCommandAsync _startUsageCommand;
        private readonly IEndUsageCommandAsync _endUsageCommand;
        private readonly IGetUsageHistoryCommandAsync _getUsageHistoryCommand;

        public CarUsageService(IStartUsageCommandAsync startUsageCommand,
            IEndUsageCommandAsync endUsageCommand,
            IGetUsageHistoryCommandAsync getUsageHistoryCommand)
        {
            _startUsageCommand = startUsageCommand ?? throw new ArgumentNullException(nameof(startUsageCommand));
            _endUsageCommand = endUsageCommand ?? throw new ArgumentNullException(nameof(endUsageCommand));
            _getUsageHistoryCommand = getUsageHistoryCommand ?? throw new ArgumentNullException(nameof(getUsageHistoryCommand));
        }

        public Task<StartUsageResponseDto> StartUsageAsync(StartUsageRequestDto request)
        {
            return _startUsageCommand.ExecuteAsync(request);
        }

        public Task<EndUsageResponseDto> EndUsageAsync(EndUsageRequestDto request)
        {
            return _endUsageCommand.ExecuteAsync(request);
        }

        public Task<GetUsageHistoryResponseDto> GetUsageHistoryAsync(GetUsageHistoryReuqestDto request)
        {
            return _getUsageHistoryCommand.ExecuteAsync(request);
        }
    }
}
