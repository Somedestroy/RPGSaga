namespace Application.DTO.Request
{
    using Application.Interfaces;
    using Domain.Models;

    public class ProductCreateRequestDto : IDtoMapper<Product>
    {
        public string Name { get; set; }

        public Product ToModel()
        {
            return new Product()
            {
                Name = this.Name,
            };
        }
    }
}
