using MongoRep.DataAccess;
using MongoRep.Models;

namespace MongoRep.Servises
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(MongoDBContext mongoDBContext)
        {
            var dbContext = mongoDBContext; 
            _productRepository = new MongoRepository<Product>(dbContext.Database, "Products");
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // Implement other CRUD operations similarly...
    }
}
