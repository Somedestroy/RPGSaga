namespace WebAPI.MockFactory.Tests.Data
{
    using System.Collections.Generic;
    using Domain.Models;

    public static class TestProducts
    {
        public static Product ProductA => new () { Name = "ProductA" };

        public static Product ProductB => new () { Name = "ProductB" };

        public static Product ProductC => new () { Name = "ProductC" };

        public static List<Product> AllProducts => new () { ProductA, ProductB, ProductC };
    }
}
