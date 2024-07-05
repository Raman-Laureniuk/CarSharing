namespace CarSharing.Domain.Repository.CarUsage
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Base;

    public interface ICarUsageRepository : IRepository<CarUsage>
    {
        Task<List<CarUsage>> GetCarUsages(Guid carId, string statusNameKey);
    }
}
