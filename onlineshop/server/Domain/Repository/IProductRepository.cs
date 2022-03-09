namespace Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(Guid productId);

        Task<Product> GetProductWithDetailsAsync(Guid productId);

        void InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
