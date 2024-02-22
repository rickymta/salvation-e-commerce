using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.Common;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Filter;
using Salvation.Library.Models.Request;
using Salvation.Library.Models.ViewModels;

namespace Salvation.Presentation.WebAdmin.Controllers;

public class CategoryController : Controller
{
    private readonly ILogProvider _logProvider;

    private readonly ICoreApiProvider _coreApiProvider;

    public CategoryController(ILogProvider logProvider, ICoreApiProvider coreApiProvider)
    {
        _logProvider = logProvider;
        _coreApiProvider = coreApiProvider;
    }

    [HttpGet("/danh-muc")]
    public async Task<IActionResult> Index()
    {
        var data = await _coreApiProvider.GetCore<List<Category>>("https://localhost:7041/api/category/get-all-categories", isExactUrl: true);
        ViewBag.Categories = data.Data;
        return View();
    }

    [HttpGet("/danh-muc/thong-tin/{id?}")]
    public async Task<IActionResult> Information(string? id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var data = await _coreApiProvider.GetCore<Category>("https://localhost:7041/api/category/get-category-by-id/" + id, isExactUrl: true);
            ViewBag.Category = data.Data;
        }

        var activedCategories = await _coreApiProvider.GetCore<List<CategoryViewModel>>("https://localhost:7041/api/category/get-active-categories", isExactUrl: true);
        ViewBag.ActivedCategories = activedCategories.Data;
        return View();
    }

    [HttpPost("/danh-muc/get-data")]
    public async Task<IActionResult> GetDataAsync(CategoryFilter filter, string start, string length)
    {
        try
        {
            if (start != null)
            {
                var st = int.Parse(start);

                if (length != null)
                {
                    var limit = int.Parse(length);

                    if (limit != -1)
                    {
                        filter.Limit = limit;
                    }

                    filter.Page = st / limit;
                }
            }

            var data = await _coreApiProvider.PostCore<DataPaging<Category>>("https://localhost:7041/api/category/get-category-paging", filter, isExactUrl: true);
            return Ok(data.Data);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return Ok(ex.Message);
        }
    }

    [HttpPost("/danh-muc/tao-moi")]
    public async Task<IActionResult> CreateCategory(Category category)
    {
        category.CreatedAt = DateTime.Now;
        category.Id = Guid.NewGuid().ToString();
        var result = await _coreApiProvider.PostCore<string>("https://localhost:7041/api/category/create-category", category, isExactUrl: true);
        return Ok(result);
    }

    [HttpPost("/danh-muc/cap-nhat")]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        category.UpdatedAt = DateTime.Now;
        var result = await _coreApiProvider.PutCore<bool>("https://localhost:7041/api/category/update-category", category, isExactUrl: true);
        return Ok(result);
    }

    [HttpPost("/danh-muc/cap-nhat-trang-thai")]
    public async Task<IActionResult> UpdateStatusCategory(CategoryStatusUpdate category)
    {
        var result = await _coreApiProvider.PutCore<bool>("https://localhost:7041/api/category/update-category-status", category, isExactUrl: true);
        return Ok(result);
    }

    [HttpGet("/danh-muc/xoa-danh-muc/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        var result = await _coreApiProvider.GetCore<bool>("https://localhost:7041/api/category/delete-category-by-id/" + id, isExactUrl: true);
        return Ok(result);
    }
}
