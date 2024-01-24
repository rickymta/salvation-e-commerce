using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    internal class ProductPropertyRepository : GenericRepository, IProductPropertyRepository
    {
        public ProductPropertyRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
        {
        }

        public Task<int> CreateAsync(ProductProperty entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductProperty>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductProperty?> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProductProperty entity)
        {
            throw new NotImplementedException();
        }
    }
}
