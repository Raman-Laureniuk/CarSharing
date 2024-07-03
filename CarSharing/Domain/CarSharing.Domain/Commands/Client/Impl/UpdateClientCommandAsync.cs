namespace CarSharing.Domain.Commands.Client.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;

    internal class UpdateClientCommandAsync : IUpdateClientCommandAsync
    {
        private readonly IDeactivateClientCommandAsync _deactivateClientCommand;
        private readonly IClientRepositoryFactory _repoFactory;

        public UpdateClientCommandAsync(IDeactivateClientCommandAsync deactivateClientCommand,
            IClientRepositoryFactory repoFactory)
        {
            _deactivateClientCommand = deactivateClientCommand ?? throw new ArgumentNullException(nameof(deactivateClientCommand));
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<UpdateClientResponseDto> ExecuteAsync(UpdateClientRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (IClientRepository repo = _repoFactory.CreateRepository())
            {
                Client client = await repo.GetByIdAsync(request.ClientId);

                if (client == null)
                {
                    throw new ArgumentOutOfRangeException($"Client {request.ClientId} not found.");
                }

                client.Name = request.Name ?? client.Name;
                client.Surname = request.Surname ?? client.Surname;
                client.LicenseNumber = request.LicenseNumber ?? client.LicenseNumber;
                client.PhoneNumber = request.PhoneNumber ?? client.PhoneNumber;
                client.Email = request.Email ?? client.Email;

                await repo.UpdateAsync(client, true);
            }

            DeactivateClientRequestDto deactivateRequest = new DeactivateClientRequestDto()
            {
                ClientId = request.ClientId
            };

            await _deactivateClientCommand.ExecuteAsync(deactivateRequest);  // New client data must be confirmend by administrator.  TODO: move to decoorator

            return new UpdateClientResponseDto()
            {
                Success = true
            };
        }
    }
}
