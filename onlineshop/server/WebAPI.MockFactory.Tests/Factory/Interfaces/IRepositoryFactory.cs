namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    using Domain.Repository;

    public interface IRepositoryFactory
    {
        IRepositoryWrapper CreateRepositoryWrapper();

        IProductRepository CreateProductRepository();
    }
}