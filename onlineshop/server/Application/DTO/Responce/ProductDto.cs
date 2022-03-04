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
        }

        public ProductDto()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}