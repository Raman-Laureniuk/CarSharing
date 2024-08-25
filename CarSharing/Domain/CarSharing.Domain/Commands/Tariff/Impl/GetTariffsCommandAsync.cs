namespace CarSharing.Domain.Commands.Tariff.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Tariff.Response;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Domain.RepositoryFactory.Tariff;

    internal class GetTariffsCommandAsync : IGetTariffsCommandAsync
    {
        private readonly ITariffRepositoryFactory _repoFactory;

        public GetTariffsCommandAsync(ITariffRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<GetTariffsResponseDto> ExecuteAsync(GetTariffsRequestDto request)
        {
            using (ITariffRepository repo = _repoFactory.CreateRepository())
            {
                List<Tariff> tariffs = await repo.GetAllAsync().ConfigureAwait(false);

                return tariffs.ToGetTariffsResponseDto();
            }
        }
    }
}
