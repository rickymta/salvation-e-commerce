using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Salvation.Library.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly string ConnectionString = "ConnectionString";

        private IDbConnection _connection;

        private IDbTransaction _transaction;

        private readonly ILogProvider _logProvider;

        private readonly IObjectProvider _objectProvider;

        private bool _disposed;

        private IAccountRepository _account;

        private ICategoryRepository _category;

        private IManufactureRepository _manufacture;

        private IProductRepository _product;

        private IProductPropertyRepository _productProperty;

        private IProductDetailRepository _productDetail;

        private IProductImageRepository _productImage;

        public IAccountRepository Account
        {
            get { return _account ??= new AccountRepository(_transaction, _connection, _logProvider, _objectProvider); }
        }

        public ICategoryRepository Category
        {
            get { return _category ??= new CategoryRepository(_transaction, _connection, _logProvider, _objectProvider); }
        }

        public IManufactureRepository Manufacture
        {
            get { return _manufacture ??= new ManufactureRepository(_transaction, _connection, _logProvider, _objectProvider); }
        }

        public IProductRepository Product
        {
            get { return _product ??= new ProductRepository(_transaction, _connection, _logProvider, _objectProvider); }
        }

        public IProductPropertyRepository ProductProperty
        {
            get { return _productProperty ??= new ProductPropertyRepository(_transaction, _connection, _logProvider, _objectProvider); }
        }

        public IProductDetailRepository ProductDetail
        {
            get { return _productDetail ??= new ProductDetailRepository(_transaction, _connection, _logProvider, _objectProvider); }
        }

        public IProductImageRepository ProductImage
        {
            get { return _productImage ??= new ProductImageRepository(_transaction, _connection, _logProvider, _objectProvider); }
        }

        public UnitOfWork(IConfigProvider configProvider)
        {
            var connectionString = configProvider.GetConfigString(ConnectionString);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            //Begin();
        }

        private void ResetRepository()
        {
            _account = null;
            _category = null;
            _manufacture = null;
            _product = null;
            _productProperty = null;
            _productDetail = null;
            _productImage = null;
        }

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null) return;

            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                ResetRepository();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }

                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
