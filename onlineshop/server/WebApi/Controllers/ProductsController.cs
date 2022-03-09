namespace WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private IServiceManager _serviceManager;

        public ProductsController(ILogger<ProductsController> logger, IServiceManager serviceManager)
        {
            this.logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var product = await _serviceManager.ProductService.GetProductsAsync();
            return Ok(product);
        }

        [HttpGet("{productId:guid}")]
        public async Task<ActionResult> GetById(Guid productId)
        {
            var productDto = await _serviceManager.ProductService.GetByIdAsync(productId);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductCreateRequestDto product)
        {
            var productDto = await _serviceManager.ProductService.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { productId = productDto.Id }, productDto);
        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> Update(Guid productId, [FromBody] ProductUpdateDto product)
        {
            await _serviceManager.ProductService.UpdateAsync(productId, product);
            return NoContent();
        }

        [HttpDelete("{productId:guid}")]

        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            await _serviceManager.ProductService.DeleteAsync(productId);
            return NoContent();
        }
    }
}
