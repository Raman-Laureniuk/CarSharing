namespace CarSharing.Domain.Repository.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        Task CreateAsync(T item, bool commit = false);
        Task UpdateAsync(T item, bool commit = false);
        Task DeleteAsync(object id, bool commit = false);
        Task<List<T>> GetAllAsync();

        Task CommitAsync();
    }
}
