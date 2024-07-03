namespace CarSharing.Domain.Commands.Client.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;

    internal class BlockClientCommandAsync : IBlockClientCommandAsync
    {
        private readonly IClientRepositoryFactory _repoFactory;

        public BlockClientCommandAsync(IClientRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<BlockClientResponseDto> ExecuteAsync(BlockClientRequestDto request)
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

                client.IsBlocked = true;

                await repo.UpdateAsync(client, true);
            }

            return new BlockClientResponseDto()
            {
                Success = true
            };
        }
    }
}
