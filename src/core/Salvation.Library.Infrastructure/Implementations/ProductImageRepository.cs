using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    internal class ProductImageRepository : GenericRepository, IProductImageRepository
    {
        public ProductImageRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
        {
        }

        public Task<int> CreateAsync(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductImage>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductImage?> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProductImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
