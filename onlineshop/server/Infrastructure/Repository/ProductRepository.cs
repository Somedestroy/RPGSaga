namespace CleanArchitecture.Infra.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Infrastructure.Repository;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await FindAll()
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await FindByCondition(product => product.Id.Equals(productId))
                .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductWithDetailsAsync(Guid productId)
        {
            return await FindByCondition(product => product.Id.Equals(productId))
                .FirstOrDefaultAsync();
        }

        public void InsertProduct(Product product)
        {
            Create(product);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }
    }
}
