using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Jwt.Enums;
using Salvation.Library.Models.Request;
using Salvation.Library.Models.Response;
using Salvation.Library.Services.Abstractions;

namespace Salvation.Library.Services.Implementations;

/// <inheritdoc/>
internal class AccountService : IAccountService
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// IHashProvider
    /// </summary>
    private readonly IHashProvider _hashProvider;

    /// <summary>
    /// IJwtProvider
    /// </summary>
    private readonly IJwtProvider _jwtProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="hashProvider"></param>
    /// <param name="jwtProvider"></param>
    public AccountService(IUnitOfWork unitOfWork, IHashProvider hashProvider, IJwtProvider jwtProvider)
    {
        _unitOfWork = unitOfWork;
        _hashProvider = hashProvider;
        _jwtProvider = jwtProvider;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAsync(Account entity)
    {
        var createResult = await _unitOfWork.Account.CreateAsync(entity);
        return createResult;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(string id)
    {
        var deleteResult = await _unitOfWork.Account.DeleteAsync(id);
        return deleteResult;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Account>?> GetAllAsync()
    {
        var getAllResult = await _unitOfWork.Account.GetAllAsync();
        return getAllResult;
    }

    /// <inheritdoc/>
    public async Task<Account?> GetAsync(string id)
    {
        var getOneResult = await _unitOfWork.Account.GetAsync(id);
        return getOneResult;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(Account entity)
    {
        var updateResult = await _unitOfWork.Account.UpdateAsync(entity);
        return updateResult;
    }

    /// <inheritdoc/>
    public async Task<LoginResponse?> RegisterAsync(RegisterRequest request)
    {
        var account = new Account
        {
            Id = Guid.NewGuid().ToString(),
            Email = request.Email,
            Fullname = request.Fullname,
            Address = request.Address,
            Avatar = null,
            Password = _hashProvider.HashPassword(request.Password),
            IsActived = true,
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
        };

        var registerResult = await _unitOfWork.Account.CreateAsync(account);

        if (registerResult > 0)
        {
            var accessToken = _jwtProvider.GenerateJwt(account, "Admin", "salvation-auth", "salvation-client", JwtType.AccessToken);
            var refreshToken = _jwtProvider.GenerateJwt(account, "Admin", "salvation-auth", "salvation-client", JwtType.RefreshToken);

            return new LoginResponse
            {
                Email = account.Email,
                Fullname = account.Fullname,
                Avatar = account.Avatar ??= "",
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        return null;
    }

    /// <inheritdoc/>
    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var accountFind = await _unitOfWork.Account.GetOneByEmail(request.Email);

        if (accountFind != null)
        {
            if (_hashProvider.VerifyPassword(accountFind.Password, request.Password))
            {
                if (accountFind.IsActived && !accountFind.IsDeleted)
                {
                    var accessToken = _jwtProvider.GenerateJwt(accountFind, "Admin", "salvation-auth", "salvation-client", JwtType.AccessToken);
                    var refreshToken = _jwtProvider.GenerateJwt(accountFind, "Admin", "salvation-auth", "salvation-client", JwtType.RefreshToken);

                    return new LoginResponse
                    {
                        Email = accountFind.Email,
                        Fullname = accountFind.Fullname,
                        Avatar = accountFind.Avatar ??= "",
                        AccessToken = accessToken,
                        RefreshToken = refreshToken
                    };
                }
            }
        }

        return null;
    }
}
