namespace CarSharing.Domain.Repository.Car
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Base;

    public interface ICarRepository : IRepository<Car>
    {
        Task<List<Car>> GetAsync(bool? isAvailable);
    }
}
