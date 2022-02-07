namespace WebAPI.MockFactory.Tests.Factory
{
    using CleanArchitecture.Infra.Data.Repositories;

    using Domain.Repository;

    using WebAPI.MockFactory.Tests.Factory.Interfaces;

    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IRepositoryContextFactory _repositoryContextFactory;

        public RepositoryFactory(IRepositoryContextFactory repositoryContextFactory)
        {
            _repositoryContextFactory = repositoryContextFactory;
        }

        public IProductRepository CreateProductRepository()
        {
            return new ProductRepository(_repositoryContextFactory.CreateDatabaseContext());
        }
    }
}
