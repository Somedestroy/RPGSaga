namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    using Domain.Repository;

    public interface IRepositoryFactory
    {
        IProductRepository CreateProductRepository();
    }
}