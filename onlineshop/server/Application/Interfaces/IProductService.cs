namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetByIdAsync(Guid productId);

        Task<ProductDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto);

        Task UpdateAsync(Guid productId, ProductUpdateDto productUpdateDto);

        Task DeleteAsync(Guid productId);
    }
}
