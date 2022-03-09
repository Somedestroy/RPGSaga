namespace Application.Services
{
    using System;
    using Application.Interfaces;
    using Domain.Repository;

    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _lazyProductService;

        public ServiceManager(IRepositoryWrapper repositoryWrapper)
        {
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryWrapper));
        }

        public IProductService ProductService => _lazyProductService.Value;
    }
}
