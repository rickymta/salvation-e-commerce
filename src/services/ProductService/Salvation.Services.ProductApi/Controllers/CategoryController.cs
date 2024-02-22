using Microsoft.AspNetCore.Mvc;
using Salvation.Handlers.Products.Abstractions;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Controller.Controllers;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Filter;
using Salvation.Library.Models.Request;

namespace Salvation.Services.ProductApi.Controllers;

/// <summary>
/// CategoryController
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    /// <summary>
    /// IProductHandler
    /// </summary>
    private readonly IProductHandler _productHandler;

    /// <summary>
    /// ILogProvider
    /// </summary>
    private readonly ILogProvider _logProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="productHandler"></param>
    /// <param name="logProvider"></param>
    public CategoryController(IProductHandler productHandler, ILogProvider logProvider)
    {
        _productHandler = productHandler;
        _logProvider = logProvider;
    }

    /// <summary>
    /// get-active-categories
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-active-categories")]
    public async Task<IActionResult> Index()
    {
        try
        {
            var categories = await _productHandler.GetActiveCategories();
            
            if (categories != null)
            {
                return Ok(SuccessData(categories));
            }

            return Ok(SuccessData());
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return Ok(ErrorMessage(ex.Message));
        }
    }

    [HttpPost("get-category-paging")]
    public async Task<IActionResult> GetDataPaging(CategoryFilter filter)
    {
        try
        {
            var result = await _productHandler.FilterCategoryDataPaging(filter);
            return Ok(SuccessData(result));
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return Ok(ErrorMessage(ex.Message));
        }
    }

    [HttpGet("get-category-by-id/{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var result = await _productHandler.GetCategoryAsync(id);
        return Ok(SuccessData(result));
    }

    [HttpGet("get-all-categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _productHandler.GetAllCategoryAsync();
        return Ok(SuccessData(result));
    }

    [HttpPost("create-category")]
    public async Task<IActionResult> CreateNewCategory(Category category)
    {
        var result = await _productHandler.CreateCategoryAsync(category);
        return Ok(SuccessData(result));
    }

    [HttpPut("update-category")]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        var result = await _productHandler.UpdateCategoryAsync(category);
        return Ok(SuccessData(result));
    }

    [HttpPut("update-category-status")]
    public async Task<IActionResult> UpdateCategoryStatus(CategoryStatusUpdate category)
    {
        var categoryFind = await _productHandler.GetCategoryAsync(category.Id);
        
        if (categoryFind != null)
        {
            categoryFind.IsActived = category.IsActived;
            categoryFind.IsDeleted = !category.IsActived;
            categoryFind.UpdatedAt = DateTime.Now;
            var result = await _productHandler.UpdateCategoryAsync(categoryFind);
            return Ok(SuccessData(result));
        }

        return Ok(ErrorMessage("Category is not found!"));
    }

    [HttpGet("delete-category-by-id/{id}")]
    public async Task<IActionResult> DeleteCategoryById(string id)
    {
        var result = await _productHandler.DeleteCategoryAsync(id);
        return Ok(SuccessData(result));
    }
}
