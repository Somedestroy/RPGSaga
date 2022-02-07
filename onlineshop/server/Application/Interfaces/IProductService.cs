namespace Application.Interfaces
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface IProductService
    {
        List<ProductDto> GetProducts();

        ProductDto InsetProduct(ProductCreateRequestDto product);
    }
}
