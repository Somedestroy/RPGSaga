namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;
    using Application.Interfaces;
    using Domain.Models;

    public class ProductUpdateDto : IDtoMapper<Product>
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        [StringLength(60, ErrorMessage = "Producer can't be longer than 60 characters")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        [StringLength(60, ErrorMessage = "Producer can't be longer than 60 characters")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Width is required")]
        [Range(7, 325, ErrorMessage = "Witdh must be in range (12, 23)")]
        public int Width { get; set; }

        [Required(ErrorMessage = "Profile is required")]
        [Range(8, 85, ErrorMessage = "Profile must be in range (12, 23)")]
        public int Profile { get; set; }

        [Required(ErrorMessage = "Diameter is required")]
        [Range(12, 23, ErrorMessage = "Diameter must be in range (12, 23)")]
        public int Diameter { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price must be in range (0, 10000)")]
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
