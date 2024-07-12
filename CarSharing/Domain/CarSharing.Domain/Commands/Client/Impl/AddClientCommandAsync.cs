namespace CarSharing.Domain.Commands.Client.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Client.Request;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;

    internal class AddClientCommandAsync : IAddClientCommandAsync
    {
        private readonly IClientRepositoryFactory _repoFactory;

        public AddClientCommandAsync(IClientRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<AddClientResponseDto> ExecuteAsync(AddClientRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Client client = request.ToClientEntity();

            using (IClientRepository repo = _repoFactory.CreateRepository())
            {
                await repo.CreateAsync(client, true);
            }

            return new AddClientResponseDto()
            {
                ClientId = client.ClientId
            };
        }
    }
}
