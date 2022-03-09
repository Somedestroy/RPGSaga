namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.Exceptions;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Repository;

    public sealed class ProductService : IProductService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ProductDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto)
        {
            var product = productCreateRequestDto.ToModel();
            _repositoryWrapper.ProductRepository.InsertProduct(product);
            await _repositoryWrapper.SaveAsync();
            return new ProductDto(product);
        }

        public async Task DeleteAsync(Guid productId)
        {
            var product = await _repositoryWrapper.ProductRepository.GetProductByIdAsync(productId);
            if (product is null)
            {
                throw new ProductNotFoundException(productId);
            }

            _repositoryWrapper.ProductRepository.Delete(product);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<ProductDto> GetByIdAsync(Guid productId)
        {
            var product = await _repositoryWrapper.ProductRepository.GetProductByIdAsync(productId);
            if (product is null)
            {
                throw new ProductNotFoundException(productId);
            }

            return new ProductDto(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var products = await _repositoryWrapper.ProductRepository.GetProductsAsync();

            return products.Select(x => new ProductDto(x)).ToList();
        }

        public async Task UpdateAsync(Guid productId, ProductUpdateDto updateDto)
        {
            var product = await _repositoryWrapper.ProductRepository.GetProductByIdAsync(productId);

            if (product is null)
            {
                throw new ProductNotFoundException(productId);
            }

            product = updateDto.ToModel();
            product.Id = productId;
            _repositoryWrapper.ProductRepository.UpdateProduct(product);
            await _repositoryWrapper.SaveAsync();
        }
    }
}
