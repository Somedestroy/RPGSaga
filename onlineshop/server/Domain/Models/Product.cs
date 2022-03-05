namespace Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Profile { get; set; }

        [Required]
        public int Diameter { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}
