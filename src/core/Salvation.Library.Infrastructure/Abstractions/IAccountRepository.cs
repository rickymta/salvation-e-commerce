using Salvation.Library.Models.Entities;

namespace Salvation.Library.Infrastructure.Abstractions
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account?> GetOneByEmail(string email);
    }
}
