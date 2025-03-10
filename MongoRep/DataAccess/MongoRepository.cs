using MongoDB.Driver;
using MongoRep.Models;

namespace MongoRep.DataAccess
{
    public class MongoRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq(e => e.Id, id)).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq(e => e.Id, id), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq(e => e.Id, id));
        }
    }

}
