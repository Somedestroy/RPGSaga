namespace Application.ViewModels
{
    using System;
    using Domain.Models;

    public class ProductDto
    {
        public ProductDto(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Category = product.Category;
            this.Width = product.Width;
            this.Profile = product.Diameter;
            this.Price = product.Price;
        }

        public ProductDto()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Producer { get; set; }

        public string Category { get; set; }

        public int Width { get; set; }

        public int Profile { get; set; }

        public int Diameter { get; set; }

        public decimal Price { get; set; }
    }
}