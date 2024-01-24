using Salvation.Library.Common.Abstractions;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    /// <summary>
    /// GenericRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository
    {
        /// <summary>
        /// IDbTransaction
        /// </summary>
        protected IDbTransaction Transaction { get; }

        /// <summary>
        /// IDbConnection
        /// </summary>
        protected IDbConnection Connection { get; }

        /// <summary>
        /// ILogProvider
        /// </summary>
        protected readonly ILogProvider _logProvider;

        /// <summary>
        /// IObjectProvider
        /// </summary>
        protected readonly IObjectProvider _objectProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="connection"></param>
        /// <param name="logProvider"></param>
        /// <param name="objectProvider"></param>
        public GenericRepository(
            IDbTransaction transaction,
            IDbConnection connection,
            ILogProvider logProvider,
            IObjectProvider objectProvider)
        {
            Transaction = transaction;
            Connection = connection;
            _logProvider = logProvider;
            _objectProvider = objectProvider;
        }
    }
}
