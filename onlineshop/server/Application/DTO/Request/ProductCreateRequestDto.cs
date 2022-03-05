namespace Application.DTO.Request
{
    using Application.Interfaces;
    using Domain.Models;

    public class ProductCreateRequestDto : IDtoMapper<Product>
    {
        public string Name { get; set; }

        public string Producer { get; set; }

        public string Category { get; set; }

        public int Width { get; set; }

        public int Profile { get; set; }

        public int Diameter { get; set; }

        public decimal Price { get; set; }

        public Product ToModel()
        {
            return new Product()
            {
                Name = this.Name,
                Producer = this.Producer,
                Category = this.Category,
                Width = this.Width,
                Profile = this.Profile,
                Diameter = this.Diameter,
                Price = this.Price,
            };
        }
    }
}
