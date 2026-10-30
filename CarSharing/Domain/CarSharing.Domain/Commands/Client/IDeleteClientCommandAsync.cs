namespace CarSharing.Domain.Commands.Client
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Client.Request;

    internal interface IDeleteClientCommandAsync : ICommandAsync<DeleteClientRequestDto>
    {
    }
}
