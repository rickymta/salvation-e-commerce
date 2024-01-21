using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    internal class ProductDetailRepository : GenericRepository, IProductDetailRepository
    {
        public ProductDetailRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
        {
        }

        public Task<long> CreateAsync(ProductDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDetail>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetail?> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProductDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
