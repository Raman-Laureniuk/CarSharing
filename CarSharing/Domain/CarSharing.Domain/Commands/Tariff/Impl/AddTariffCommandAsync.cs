namespace CarSharing.Domain.Commands.Tariff.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Tariff.Request;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Domain.RepositoryFactory.Tariff;

    internal class AddTariffCommandAsync : IAddTariffCommandAsync
    {
        private readonly ITariffRepositoryFactory _repoFactory;

        public AddTariffCommandAsync(ITariffRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<AddTariffResponseDto> ExecuteAsync(AddTariffRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Tariff tariff = request.ToTariffEntity();

            using (ITariffRepository repo = _repoFactory.CreateRepository())
            {
                await repo.CreateAsync(tariff, true);
            }

            return new AddTariffResponseDto()
            {
                TariffId = tariff.TariffId
            };
        }
    }
}
