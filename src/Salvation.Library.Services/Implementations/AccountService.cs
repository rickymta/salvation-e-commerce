using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Services.Abstractions;

namespace Salvation.Library.Services.Implementations
{
    internal class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateAsync(Account entity)
        {
            var createResult = await _unitOfWork.Account.CreateAsync(entity);
            return createResult;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var deleteResult = await _unitOfWork.Account.DeleteAsync(id);
            return deleteResult;
        }

        public async Task<IEnumerable<Account>?> GetAllAsync()
        {
            var getAllResult = await _unitOfWork.Account.GetAllAsync();
            return getAllResult;
        }

        public async Task<Account?> GetAsync(long id)
        {
            var getOneResult = await _unitOfWork.Account.GetAsync(id);
            return getOneResult;
        }

        public async Task<bool> UpdateAsync(Account entity)
        {
            var updateResult = await _unitOfWork.Account.UpdateAsync(entity);
            return updateResult;
        }
    }
}
