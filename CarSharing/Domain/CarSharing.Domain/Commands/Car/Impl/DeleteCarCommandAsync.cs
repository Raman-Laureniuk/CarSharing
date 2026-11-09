namespace CarSharing.Domain.Commands.Car.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Domain.RepositoryFactory.Car;
    using CarSharing.Domain.Tools.Result;

    internal class DeleteCarCommandAsync : IDeleteCarCommandAsync
    {
        private readonly ICarRepositoryFactory _repoFactory;

        public DeleteCarCommandAsync(ICarRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<Result> ExecuteAsync(DeleteCarRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (ICarRepository repo = _repoFactory.CreateRepository())
            {
                await repo.DeleteAsync(request.CarId, true).ConfigureAwait(false);
            }

            return Result.Success();
        }
    }
}
