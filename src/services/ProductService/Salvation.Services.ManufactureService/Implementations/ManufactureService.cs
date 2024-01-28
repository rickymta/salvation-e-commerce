using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Services.Manufactures.Abstractions;

namespace Salvation.Library.Services.Manufactures.Implementations;

/// <inheritdoc/>
internal class ManufactureService : IManufactureService
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
    public ManufactureService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAsync(Manufacture entity)
    {
        var createResult = await _unitOfWork.Manufacture.CreateAsync(entity);
        return createResult;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(string id)
    {
        var deleteResult = await _unitOfWork.Manufacture.DeleteAsync(id);
        return deleteResult;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Manufacture>?> GetAllAsync()
    {
        var getAllResult = await _unitOfWork.Manufacture.GetAllAsync();
        return getAllResult;
    }

    /// <inheritdoc/>
    public async Task<Manufacture?> GetAsync(string id)
    {
        var getOneResult = await _unitOfWork.Manufacture.GetAsync(id);
        return getOneResult;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(Manufacture entity)
    {
        var updateResult = await _unitOfWork.Manufacture.UpdateAsync(entity);
        return updateResult;
    }
}
