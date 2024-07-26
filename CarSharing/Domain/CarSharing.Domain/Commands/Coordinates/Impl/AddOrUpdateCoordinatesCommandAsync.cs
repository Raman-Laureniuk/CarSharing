namespace CarSharing.Domain.Commands.Coordinates.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Dto.Coordinates.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Coordinates.Request;
    using CarSharing.Domain.Repository.CarCoordinates;
    using CarSharing.Domain.RepositoryFactory.CarCoordinates;

    internal class AddOrUpdateCoordinatesCommandAsync : IAddOrUpdateCoordinatesCommandAsync
    {
        private readonly ICarCoordinatesRepositoryFactory _repoFactory;

        public AddOrUpdateCoordinatesCommandAsync(ICarCoordinatesRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<AddUpdateCoordinatesResponseDto> ExecuteAsync(AddOrUpdateCoordinatesRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            CarCoordinates carCoordinates = request.ToCarCoordinates();

            using (ICarCoordinatesRepository repo = _repoFactory.CreateRepository())
            {
                await repo.UpsertAsync(carCoordinates, true);
            }

            return new AddUpdateCoordinatesResponseDto()
            {
                Success = true
            };
        }
    }
}
