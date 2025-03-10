using MongoDB.Bson;
using MongoRep.Models;

namespace MongoRep.Infrastructure
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product GetProduct()
        {
            return new Product() { Name = this.Name, Price = this.Price, Id = ObjectId.GenerateNewId().ToString() };
        }
    }
}
