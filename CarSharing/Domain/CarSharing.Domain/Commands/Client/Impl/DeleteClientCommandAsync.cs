namespace CarSharing.Domain.Commands.Client.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;

    internal class DeleteClientCommandAsync : IDeleteClientCommandAsync
    {
        private readonly IClientRepositoryFactory _repoFactory;

        public DeleteClientCommandAsync(IClientRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<DeleteClientResponseDto> ExecuteAsync(DeleteClientRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (IClientRepository repo = _repoFactory.CreateRepository())
            {
                await repo.DeleteAsync(request.ClientId);
            }

            return new DeleteClientResponseDto()
            {
                Success = true
            };
        }
    }
}
