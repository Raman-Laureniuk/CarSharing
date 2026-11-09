namespace CarSharing.Domain.Commands.Tariff.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Domain.RepositoryFactory.Tariff;
    using CarSharing.Domain.Tools.Result;

    internal class DeleteTariffCommandAsync : IDeleteTariffCommandAsync
    {
        private readonly ITariffRepositoryFactory _repoFactory;

        public DeleteTariffCommandAsync(ITariffRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<Result> ExecuteAsync(DeleteTariffRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            
            using (ITariffRepository repo = _repoFactory.CreateRepository())
            {
                await repo.DeleteAsync(request.TariffId, true).ConfigureAwait(false);
            }

            return Result.Success();
        }
    }
}
