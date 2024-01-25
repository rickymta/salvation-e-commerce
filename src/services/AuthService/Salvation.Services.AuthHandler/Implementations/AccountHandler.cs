using Azure.Core;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Request;
using Salvation.Library.Models.Response;
using Salvation.Library.Services.Abstractions;
using Salvation.Services.AuthHandler.Abstractions;
using static Dapper.SqlMapper;
using static Slapper.AutoMapper;

namespace Salvation.Services.AuthHandler.Implementations;

/// <inheritdoc/>
internal class AccountHandler : IAccountHandler
{
    /// <summary>
    /// IAccountService
    /// </summary>
    private readonly IAccountService _accountService;

    /// <summary>
    /// ILogProvider
    /// </summary>
    private readonly ILogProvider _logProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="accountService"></param>
    /// <param name="logProvider"></param>
    public AccountHandler(IAccountService accountService, ILogProvider logProvider)
    {
        _accountService = accountService;
        _logProvider = logProvider;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAsync(Account entity)
    {
        try
        {
            return await _accountService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return 0;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            return await _accountService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Account>?> GetAllAsync()
    {
        try
        {
            return await _accountService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task<Account?> GetAsync(string id)
    {
        try
        {
            return await _accountService.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        try
        {
            return await _accountService.LoginAsync(request);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task<LoginResponse?> RegisterAsync(RegisterRequest request)
    {
        try
        {
            return await _accountService.RegisterAsync(request);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(Account entity)
    {
        try
        {
            return await _accountService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }
}
