using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoRep.Infrastructure;
using System.Runtime;

namespace MongoRep.DataAccess
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings>  mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.Connection);
            _database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        }

        public IMongoDatabase Database => _database;
    }
}
