namespace WebApi.Tests.ProductsController
{
    using System.Collections.Generic;
    using Application.ViewModels;
    using Infrastructure.EF;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebAPI.MockFactory.Tests.Data;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;
    using WebAPI.MockFactory.Tests.Utils;
    using Xunit;

    public class DemoTest : BaseTest
    {
        [Fact]
        public void TestCase()
        {
            // Arrange
            IDatabaseInitializer databaseInitializer = TestDataFactory.CreateDatabaseInitializer();
            databaseInitializer.InitializeDatabase((ILogger<DatabaseInitializer> logger, DatabaseContext databaseContext) =>
            {
                databaseContext.AddRange(TestProducts.AllProducts);
                databaseContext.SaveChanges();
            });

            IControllerFactory controllerFactory = TestDataFactory.CreateControllerFactory();
            Controllers.ProductsController productsController = controllerFactory.CreateProductsController();

            // Act
            var result = productsController.Get();
            var successResult = result.Result as OkObjectResult;
            var listOfProducts = successResult.Value as List<ProductDto>;

            // Assert
            Assert.Equal(TestProducts.AllProducts.Count, listOfProducts.Count);
        }
    }
}
