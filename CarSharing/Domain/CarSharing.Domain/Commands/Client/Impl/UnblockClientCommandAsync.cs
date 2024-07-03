namespace CarSharing.Domain.Commands.Client.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;

    internal class UnblockClientCommandAsync : IUnblockClientCommandAsync
    {
        private readonly IClientRepositoryFactory _repoFactory;

        public UnblockClientCommandAsync(IClientRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<UnblockClientResponseDto> ExecuteAsync(UnblockClientRequestDto request)
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

                client.IsBlocked = false;

                await repo.UpdateAsync(client, true);
            }

            return new UnblockClientResponseDto()
            {
                Success = true
            };
        }
    }
}
