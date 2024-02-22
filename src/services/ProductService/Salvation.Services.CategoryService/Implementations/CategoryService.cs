using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Models.Common;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Filter;
using Salvation.Library.Models.ViewModels;
using Salvation.Library.Services.Categories.Abstractions;

namespace Salvation.Library.Services.Categories.Implementations;

/// <inheritdoc/>
internal class CategoryService : ICategoryService
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
    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc/>
    public async Task<string> CreateAsync(Category entity)
    {
        var createResult = await _unitOfWork.Category.CreateAsync(entity);

        if (createResult > 0)
        {
            return entity.Id;
        }

        return "";
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(string id)
    {
        var deleteResult = await _unitOfWork.Category.DeleteAsync(id);
        return deleteResult;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Category>?> GetAllAsync()
    {
        var getAllResult = await _unitOfWork.Category.GetAllAsync();
        return getAllResult;
    }

    /// <inheritdoc/>
    public async Task<Category?> GetAsync(string id)
    {
        var getOneResult = await _unitOfWork.Category.GetAsync(id);
        return getOneResult;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(Category entity)
    {
        var updateResult = await _unitOfWork.Category.UpdateAsync(entity);
        return updateResult;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CategoryViewModel>?> GetActiveCategories()
    {
        var result = new List<CategoryViewModel>();
        var categories = await _unitOfWork.Category.GetActiveParentCategories();

        if (categories != null && categories.Any())
        {
            foreach (var category in categories)
            {
                var categoryViewModel = new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Image = category.Image,
                    ParentId = category.ParentId,
                    Slug = category.Slug
                };

                var children = await _unitOfWork.Category.GetActiveChildrenCategoriesByParentId(category.Id);

                if (children != null && children.Any())
                {
                    var childrenViewModel = new List<CategoryViewModel>();

                    foreach (var child in children)
                    {
                        var childViewModel = new CategoryViewModel
                        {
                            Id = child.Id,
                            Name = child.Name,
                            Image = child.Image,
                            ParentId = child.ParentId,
                            Slug = child.Slug
                        };

                        childrenViewModel.Add(childViewModel);
                    }

                    categoryViewModel.Children = childrenViewModel;
                }

                result.Add(categoryViewModel);
            }
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<DataPaging<Category>?> FilterDataPaging(CategoryFilter filter)
    {
        var result = await _unitOfWork.Category.FilterDataPaging(filter);
        return result;
    }
}
