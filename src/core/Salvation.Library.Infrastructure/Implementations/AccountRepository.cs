using Dapper;
using DapperExtensions;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    internal class AccountRepository : GenericRepository, IAccountRepository
    {
        public AccountRepository(IDbTransaction transaction, IDbConnection connection, ILogProvider logProvider, IObjectProvider objectProvider) : base(transaction, connection, logProvider, objectProvider)
        {
        }

        public async Task<int> CreateAsync(Account entity)
        {
            try
            {
                var sql = "INSERT INTO Account VALUES (@Id, @Email, @Fullname, @Password, @Address, @Avatar, @IsActived, @IsDeleted);";
                var result = await Connection.ExecuteAsync(sql, entity);
                return result;
            }
            catch (Exception ex)
            {
                _logProvider.Error(ex);
                return 0;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var sql = "SELECT * FROM Account WHERE Id = @Id";
                var find = await Connection.QueryFirstOrDefaultAsync<Account>(sql, param: new { Id = id }, transaction: Transaction);
                
                if (find != null)
                {
                    var result = await Connection.DeleteAsync(find, transaction: Transaction);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logProvider.Error(ex);
            }

            return false;
        }

        public async Task<IEnumerable<Account>?> GetAllAsync()
        {
            try
            {
                var sql = "SELECT * FROM Account";
                var result = await Connection.QueryAsync<Account>(sql, transaction: Transaction);
                return result;
            }
            catch (Exception ex)
            {
                _logProvider.Error(ex);
            }

            return null;
        }

        public async Task<Account?> GetAsync(string id)
        {
            try
            {
                var sql = "SELECT * FROM Account WHERE Id = @Id";
                var result = await Connection.QueryFirstOrDefaultAsync<Account>(sql, param: new { Id = id }, transaction: Transaction);
                return result;
            }
            catch (Exception ex)
            {
                _logProvider.Error(ex);
            }

            return null;
        }

        public async Task<Account?> GetOneByEmail(string email)
        {
            try
            {
                var sql = "SELECT * FROM Account WHERE Email = @Email";
                var result = await Connection.QueryFirstOrDefaultAsync<Account>(sql, param: new { Email = email }, transaction: Transaction);
                return result;
            }
            catch (Exception ex)
            {
                _logProvider.Error(ex);
            }

            return null;
        }

        public Task<bool> UpdateAsync(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
