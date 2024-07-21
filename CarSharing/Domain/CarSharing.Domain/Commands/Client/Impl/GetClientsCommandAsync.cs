namespace CarSharing.Domain.Commands.Client.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Client.Response;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Client;

    internal class GetClientsCommandAsync : IGetClientsCommandAsync
    {
        private readonly IClientRepositoryFactory _repoFactory;

        public GetClientsCommandAsync(IClientRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<GetClientsResponseDto> ExecuteAsync(GetClientsRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            
            using (IClientRepository repo = _repoFactory.CreateRepository())
            {
                List<Client> clients = await repo.GetAsync(x => x.Surname, true, request.Offset, request.Limit);

                return clients.ToGetClientsResponseDto();
            }
        }
    }
}
