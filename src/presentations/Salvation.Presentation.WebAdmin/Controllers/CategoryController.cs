using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.Common;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Filter;
using Salvation.Library.Models.Request;
using Salvation.Library.Models.ViewModels;
using Salvation.Presentation.WebAdmin.Models;
using Salvation.Services.Models.Request;
using System.Linq;

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

    [HttpGet("/danh-muc/{page?}/{limit?}")]
    public async Task<IActionResult> Index(int? page, int? limit)
    {
        limit ??= 10;
        page ??= 1;
        var offset = (page - 1) * limit;

        var filter = new CategoryFilter
        {
            Limit = limit,
            Offset = offset,
            Page = page - 1
        };

        var data = await _coreApiProvider.PostCore<DataPaging<Category>>("https://localhost:7041/api/category/get-category-paging", filter, isExactUrl: true);

        if (data != null && data.Data != null)
        {
            var totalRecord = data.Data.PaginationCount;
            ViewBag.TotalRecord = totalRecord;
            var totalPage = totalRecord % limit == 0 ? totalRecord / limit : totalRecord / limit + 1;
            ViewBag.TotalPage = totalPage;
            ViewBag.Categories = data.Data.Data;
        }

        var activedCategories = await _coreApiProvider.GetCore<List<CategoryViewModel>>("https://localhost:7041/api/category/get-active-categories", isExactUrl: true);
        ViewBag.ActivedCategories = activedCategories.Data;
        ViewBag.CurrentPage = page;
        ViewBag.Limit = limit;
        return View();
    }

    [HttpGet("/danh-muc/chi-tiet/{id}")]
    public async Task<IActionResult> CategoryDetail(string id)
    {
        var data = await _coreApiProvider.GetCore<Category>("https://localhost:7041/api/category/get-category-by-id/" + id, isExactUrl: true);
        return Ok(data);
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
