using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations;

internal class ProductRepository : GenericRepository, IProductRepository
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="connection"></param>
    /// <param name="logProvider"></param>
    /// <param name="objectProvider"></param>
    public ProductRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
    {
    }

    /// <inheritdoc/>
    public Task<int> CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Product>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<Product?> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<bool> UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
