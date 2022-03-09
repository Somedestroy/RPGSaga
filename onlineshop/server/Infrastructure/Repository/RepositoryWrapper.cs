namespace Infrastructure.Repository
{
    using System.Threading.Tasks;
    using CleanArchitecture.Infra.Data.Repositories;
    using Domain.Repository;
    using Infrastructure.EF;

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _context;

        private IProductRepository _product;

        public RepositoryWrapper(DatabaseContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_context);
                }

                return _product;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
