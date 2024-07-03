namespace CarSharing.Domain.Commands.Client
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;

    internal interface IActivateClientCommandAsync : ICommandAsync<ActivateClientRequestDto, ActivateClientResponseDto>
    {
    }
}
