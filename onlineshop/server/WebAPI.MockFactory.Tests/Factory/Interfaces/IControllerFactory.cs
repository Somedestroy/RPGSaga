namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    using WebApi.Controllers;

    public interface IControllerFactory
    {
        ProductsController CreateProductsController();
    }
}