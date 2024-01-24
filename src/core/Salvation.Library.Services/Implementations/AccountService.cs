using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Jwt.Enums;
using Salvation.Library.Models.Request;
using Salvation.Library.Models.Response;
using Salvation.Library.Services.Abstractions;

namespace Salvation.Library.Services.Implementations
{
    internal class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHashProvider _hashProvider;

        private readonly IJwtProvider _jwtProvider;

        public AccountService(IUnitOfWork unitOfWork, IHashProvider hashProvider, IJwtProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _hashProvider = hashProvider;
            _jwtProvider = jwtProvider;
        }

        public async Task<int> CreateAsync(Account entity)
        {
            var createResult = await _unitOfWork.Account.CreateAsync(entity);
            return createResult;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var deleteResult = await _unitOfWork.Account.DeleteAsync(id);
            return deleteResult;
        }

        public async Task<IEnumerable<Account>?> GetAllAsync()
        {
            var getAllResult = await _unitOfWork.Account.GetAllAsync();
            return getAllResult;
        }

        public async Task<Account?> GetAsync(string id)
        {
            var getOneResult = await _unitOfWork.Account.GetAsync(id);
            return getOneResult;
        }

        public async Task<bool> UpdateAsync(Account entity)
        {
            var updateResult = await _unitOfWork.Account.UpdateAsync(entity);
            return updateResult;
        }

        public async Task<LoginResponse?> RegisterAsync(RegisterRequest request)
        {
            var account = new Account
            {
                Address = request.Address,
                Avatar = null,
                Email = request.Email,
                Fullname = request.Fullname,
                IsActived = true,
                IsDeleted = false,
                Password = _hashProvider.HashPassword(request.Password),
                Id = Guid.NewGuid().ToString()
            };

            var registerResult = await _unitOfWork.Account.CreateAsync(account);

            if (registerResult > 0)
            {
                // tao ra jwt access token
                var accessToken = _jwtProvider.GenerateJwt(account, "Admin", "localhost", JwtType.AccessToken);
                // tao ra jwt refresh token
                var refreshToken = _jwtProvider.GenerateJwt(account, "Admin", "localhost", JwtType.RefreshToken);
                // gui thong tin tra ve
                var response = new LoginResponse
                {
                    Email = account.Email,
                    Fullname = account.Fullname,
                    Avatar = account.Avatar ??= "",
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };

                return response;
            }

            return null;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var accountFind = await _unitOfWork.Account.GetOneByEmail(request.Email);

            if (accountFind != null)
            {
                if (_hashProvider.VerifyPassword(accountFind.Password, request.Password))
                {
                    // tao ra jwt access token
                    var accessToken = _jwtProvider.GenerateJwt(accountFind, "Admin", "localhost", JwtType.AccessToken);
                    // tao ra jwt refresh token
                    var refreshToken = _jwtProvider.GenerateJwt(accountFind, "Admin", "localhost", JwtType.RefreshToken);
                    // gui thong tin tra ve
                    var response = new LoginResponse
                    {
                        Email = accountFind.Email,
                        Fullname = accountFind.Fullname,
                        Avatar = accountFind.Avatar ??= "",
                        AccessToken = accessToken,
                        RefreshToken = refreshToken
                    };

                    return response;
                }
            }

            return null;
        }
    }
}
