namespace CarSharing.Domain.Commands.Client.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;
    using CarSharing.Domain.Tools.Result;

    internal class DeactivateClientCommandAsync : IDeactivateClientCommandAsync
    {
        private readonly IClientRepositoryFactory _repoFactory;

        public DeactivateClientCommandAsync(IClientRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<Result> ExecuteAsync(DeactivateClientRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (IClientRepository repo = _repoFactory.CreateRepository())
            {
                Client client = await repo.GetByIdAsync(request.ClientId).ConfigureAwait(false);

                if (client == null)
                {
                    throw new ArgumentOutOfRangeException($"Client {request.ClientId} not found.");
                }

                client.IsActive = false;

                await repo.UpdateAsync(client, true).ConfigureAwait(false);
            }

            return Result.Success();
        }
    }
}
