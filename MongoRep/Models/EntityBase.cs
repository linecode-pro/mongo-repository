using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoRep.Models
{
    public abstract class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
