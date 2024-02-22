using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.Common;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Filter;

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
    public IActionResult Index()
    {
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
}
