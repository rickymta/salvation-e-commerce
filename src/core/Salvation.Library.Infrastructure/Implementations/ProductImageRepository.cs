using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations;

/// <inheritdoc/>
internal class ProductImageRepository : GenericRepository, IProductImageRepository
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="connection"></param>
    /// <param name="logProvider"></param>
    /// <param name="objectProvider"></param>
    public ProductImageRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
    {
    }

    /// <inheritdoc/>
    public Task<int> CreateAsync(ProductImage entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<ProductImage>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<ProductImage?> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<bool> UpdateAsync(ProductImage entity)
    {
        throw new NotImplementedException();
    }
}
