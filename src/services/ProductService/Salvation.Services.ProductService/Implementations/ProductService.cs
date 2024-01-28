using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Services.Products.Abstractions;

namespace Salvation.Library.Services.Products.Implementations;

/// <inheritdoc/>
internal class ProductService : IProductService
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="hashProvider"></param>
    /// <param name="jwtProvider"></param>
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAsync(Product entity)
    {
        var createResult = await _unitOfWork.Product.CreateAsync(entity);
        return createResult;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(string id)
    {
        var deleteResult = await _unitOfWork.Product.DeleteAsync(id);
        return deleteResult;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Product>?> GetAllAsync()
    {
        var getAllResult = await _unitOfWork.Product.GetAllAsync();
        return getAllResult;
    }

    /// <inheritdoc/>
    public async Task<Product?> GetAsync(string id)
    {
        var getOneResult = await _unitOfWork.Product.GetAsync(id);
        return getOneResult;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(Product entity)
    {
        var updateResult = await _unitOfWork.Product.UpdateAsync(entity);
        return updateResult;
    }
}
