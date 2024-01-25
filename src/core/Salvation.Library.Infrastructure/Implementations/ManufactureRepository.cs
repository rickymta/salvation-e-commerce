using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations;

/// <inheritdoc/>
internal class ManufactureRepository : GenericRepository, IManufactureRepository
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="connection"></param>
    /// <param name="logProvider"></param>
    /// <param name="objectProvider"></param>
    public ManufactureRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
    {
    }

    /// <inheritdoc/>
    public Task<int> CreateAsync(Manufacture entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Manufacture>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<Manufacture?> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<bool> UpdateAsync(Manufacture entity)
    {
        throw new NotImplementedException();
    }
}
