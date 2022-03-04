namespace Domain.Models
{
    using System;

    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Producer { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int Width { get; set; }

        public int Profile { get; set; }

        public int Diameter { get; set; }

        public decimal Price { get; set; }
    }
}
