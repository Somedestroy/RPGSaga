namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    using Application.Interfaces;

    public interface IServiceFactory
    {
        IProductService CreateProductService();
    }
}