namespace CarSharing.Domain.Repository.Base
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T> : IDisposable
    {
        Task CreateAsync(T item, bool commit = false);
        Task UpdateAsync(T item, bool commit = false);
        Task DeleteAsync(object id, bool commit = false);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);

        Task CommitAsync();
    }
}
