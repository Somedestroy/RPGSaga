namespace Application.ViewModels
{
    using Domain.Models;

    public class ProductDto
    {
        public ProductDto(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
        }

        public ProductDto()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}