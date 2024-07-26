namespace CarSharing.Domain.Repository.CarCoordinates
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Base;

    public interface ICarCoordinatesRepository : IRepository<CarCoordinates>
    {
        Task UpsertAsync(CarCoordinates item, bool commit = false);
    }
}
