namespace CarSharing.Domain.Commands.Tariff.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Domain.RepositoryFactory.Tariff;

    internal class UpdateTariffCommandAsync : IUpdateTariffCommandAsync
    {
        private readonly ITariffRepositoryFactory _repoFactory;

        public UpdateTariffCommandAsync(ITariffRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<UpdateTariffResponseDto> ExecuteAsync(UpdateTariffRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (ITariffRepository repo = _repoFactory.CreateRepository())
            {
                Tariff tariff = await repo.GetByIdAsync(request.TariffId).ConfigureAwait(false);

                if (tariff == null)
                {
                    throw new ArgumentOutOfRangeException($"Tariff {request.TariffId} not found.");
                }

                tariff.PricePerHour = request.PricePerHour;

                await repo.UpdateAsync(tariff, true).ConfigureAwait(false);
            }

            return new UpdateTariffResponseDto()
            {
                Success = true
            };
        }
    }
}
