namespace Domain.Repository
{
    using System.Threading.Tasks;

    public interface IRepositoryWrapper
    {
        IProductRepository ProductRepository { get;  }

        Task<int> SaveAsync();
    }
}
