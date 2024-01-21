using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    internal class AccountRepository : GenericRepository, IAccountRepository
    {
        public AccountRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
        {
        }

        public Task<long> CreateAsync(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetOneByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
