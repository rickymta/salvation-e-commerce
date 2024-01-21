namespace Salvation.Library.Infrastructure.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }

        ICategoryRepository Category { get; }

        IManufactureRepository Manufacture { get; }

        IProductRepository Product { get; }

        IProductPropertyRepository ProductProperty { get; }

        IProductDetailRepository ProductDetail { get; }

        IProductImageRepository ProductImage { get; }

        void Begin();

        void Commit();
    }
}
