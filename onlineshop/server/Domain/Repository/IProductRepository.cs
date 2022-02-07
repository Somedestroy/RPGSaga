namespace Domain.Repository
{
    using System.Linq;
    using Domain.Models;

    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();

        Product InsertProduct(Product product);
    }
}
