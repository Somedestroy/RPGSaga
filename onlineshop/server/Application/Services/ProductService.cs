namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Repository;

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDto> GetProducts()
        {
            return _productRepository.GetProducts().Select(x => new ProductDto(x)).ToList();
        }

        public ProductDto InsetProduct(ProductCreateRequestDto product)
        {
            return new ProductDto(_productRepository.InsertProduct(product.ToModel()));
        }
    }
}
