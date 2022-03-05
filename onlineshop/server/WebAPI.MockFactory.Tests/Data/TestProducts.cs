namespace WebAPI.MockFactory.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using Domain.Models;

    public static class TestProducts
    {
        public static Product ProductA => new () { Name = "ProductA", Producer = "ProducerA", CategoryId = Guid.NewGuid(), Category = "CategoryA", Width = 12, Profile = 11,  Diameter = 34, Price = 23 };

        public static Product ProductB => new () { Name = "ProductB", Producer = "ProducerB", CategoryId = Guid.NewGuid(), Category = "CategoryB", Width = 12, Profile = 11, Diameter = 34, Price = 23 };

        public static Product ProductC => new () { Name = "ProductC", Producer = "ProducerC", CategoryId = Guid.NewGuid(), Category = "CategoryC", Width = 12, Profile = 11, Diameter = 34, Price = 23 };

        public static List<Product> AllProducts => new () { ProductA, ProductB, ProductC };
    }
}
