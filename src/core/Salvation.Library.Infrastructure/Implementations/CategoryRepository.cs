using Dapper;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations;

/// <inheritdoc/>
internal class CategoryRepository : GenericRepository, ICategoryRepository
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="connection"></param>
    /// <param name="logProvider"></param>
    /// <param name="objectProvider"></param>
    public CategoryRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
    {
    }

    /// <inheritdoc/>
    public Task<int> CreateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Category>?> GetAllAsync()
    {
        try
        {
            var sql = "SELECT * FROM Category";
            var result = await Connection.QueryAsync<Category>(sql);
            return result;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return null;
    }

    /// <inheritdoc/>
    public async Task<Category?> GetAsync(string id)
    {
        try
        {
            var sql = "SELECT * FROM Category WHERE Id = @Id";
            var result = await Connection.QueryFirstOrDefaultAsync<Category>(sql, param: new { Id = id }, transaction: Transaction);
            return result;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return null;
    }

    /// <inheritdoc/>
    public Task<bool> UpdateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Category>?> GetActiveParentCategories()
    {
        try
        {
            var sql = "SELECT * FROM Category WHERE IsActived = 1 AND ParentId IS NULL";
            var result = await Connection.QueryAsync<Category>(sql);
            return result;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return null;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Category>?> GetActiveChildrenCategoriesByParentId(string parentId)
    {
        try
        {
            var sql = "SELECT * FROM Category WHERE IsActived = 1 AND ParentId = @ParentId";
            var result = await Connection.QueryAsync<Category>(sql, new { ParentId = parentId });
            return result;
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return null;
    }
}
