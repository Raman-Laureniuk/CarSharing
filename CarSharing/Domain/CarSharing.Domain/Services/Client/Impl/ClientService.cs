namespace CarSharing.Domain.Services.Client.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Client;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;

    internal class ClientService : IClientService
    {
        private readonly IAddClientCommandAsync _addClientCommand;
        private readonly IActivateClientCommandAsync _activateClientCommand;
        private readonly IDeactivateClientCommandAsync _deactivateClientCommand;
        private readonly IDeleteClientCommandAsync _deleteClientCommand;
        private readonly IGetClientsCommandAsync _getClientsCommand;
        private readonly IUpdateClientCommandAsync _updateClientCommand;

        public ClientService(IAddClientCommandAsync addClientCommand,
            IActivateClientCommandAsync activateClientCommand,
            IDeactivateClientCommandAsync deactivateClientCommand,
            IDeleteClientCommandAsync deleteClientCommand,
            IGetClientsCommandAsync getClientsCommand,
            IUpdateClientCommandAsync updateClientCommand)
        {
            _addClientCommand = addClientCommand ?? throw new ArgumentNullException(nameof(addClientCommand));
            _activateClientCommand = activateClientCommand ?? throw new ArgumentNullException(nameof(activateClientCommand));
            _deactivateClientCommand = deactivateClientCommand ?? throw new ArgumentNullException(nameof(deactivateClientCommand));
            _deleteClientCommand = deleteClientCommand ?? throw new ArgumentNullException(nameof(deleteClientCommand));
            _getClientsCommand = getClientsCommand ?? throw new ArgumentNullException(nameof(getClientsCommand));
            _updateClientCommand = updateClientCommand ?? throw new ArgumentNullException(nameof(updateClientCommand));
        }

        public Task<AddClientResponseDto> AddClientAsync(AddClientRequestDto request)
        {
            return _addClientCommand.ExecuteAsync(request);
        }

        public Task<ActivateClientResponseDto> ActivateClientAsync(ActivateClientRequestDto request)
        {
            return _activateClientCommand.ExecuteAsync(request);
        }

        public Task<DeactivateClientResponseDto> DeactivateClientAsync(DeactivateClientRequestDto request)
        {
            return _deactivateClientCommand.ExecuteAsync(request);
        }

        public Task<DeleteClientResponseDto> DeleteClientAsync(DeleteClientRequestDto request)
        {
            return _deleteClientCommand.ExecuteAsync(request);
        }

        public Task<GetClientsResponseDto> GetClientsAsync(GetClientsRequestDto request)
        {
            return _getClientsCommand.ExecuteAsync(request);
        }

        public Task<UpdateClientResponseDto> UpdateClientAsync(UpdateClientRequestDto request)
        {
            return _updateClientCommand.ExecuteAsync(request);
        }
    }
}
