using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    internal class ManufactureRepository : GenericRepository, IManufactureRepository
    {
        public ManufactureRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
        {
        }

        public Task<int> CreateAsync(Manufacture entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Manufacture>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Manufacture?> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Manufacture entity)
        {
            throw new NotImplementedException();
        }
    }
}
