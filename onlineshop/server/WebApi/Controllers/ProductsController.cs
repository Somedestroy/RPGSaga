namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            this.logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpPost]
        public ActionResult<ProductDto> Insert([FromBody] ProductCreateRequestDto product)
        {
            return this.Ok(_productService.InsetProduct(product));
        }
    }
}
