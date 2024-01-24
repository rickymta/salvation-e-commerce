using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Request;
using Salvation.Library.Models.Response;

namespace Salvation.Library.Services.Abstractions
{
    /// <summary>
    /// IAccountService
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync(Account entity);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Account?> GetAsync(string id);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Account>?> GetAllAsync();

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Account entity);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// Register account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginResponse?> RegisterAsync(RegisterRequest request);

        /// <summary>
        /// Login account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}
