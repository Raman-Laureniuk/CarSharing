namespace CarSharing.Domain.Commands.CarUsage
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.CarUsage.Request;
    using CarSharing.Domain.Dto.CarUsage.Response;

    internal interface IEndUsageCommandAsync : ICommandAsync<EndUsageRequestDto, EndUsageResponseDto>
    {
    }
}
