namespace CleanArchitecture.Infra.Data.Repositories
{
    using System.Linq;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : IProductRepository
    {
        private DatabaseContext context;

        public ProductRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Product InsertProduct(Product product)
        {
            var entity = context.Add(product);
            context.SaveChanges();
            return entity.Entity;
        }

        IQueryable<Product> IProductRepository.GetProducts()
        {
            return context.Products.AsNoTracking();
        }
    }
}
