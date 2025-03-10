using MongoRep.Models;

namespace MongoRep.DataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
