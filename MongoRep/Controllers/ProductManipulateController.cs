using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoRep.Infrastructure;
using MongoRep.Models;
using MongoRep.Servises;

namespace MongoRep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductManipulateController : ControllerBase
    {
        private readonly ILogger<ProductManipulateController> _logger;
        private readonly ProductService _productService;

        public ProductManipulateController(ILogger<ProductManipulateController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "AllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var data = await _productService.GetAllProductsAsync();
                //await Task.Delay(10000,cancellationToken);
                return Ok(data);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(499, "Client Closed Request");
            }

        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDTO product, CancellationToken cancellationToken)
        {


            try
            {
                var insertProduct=product.GetProduct();
                await _productService.AddProductAsync(insertProduct);
                return Ok(insertProduct);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(499, "Client Closed Request");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
