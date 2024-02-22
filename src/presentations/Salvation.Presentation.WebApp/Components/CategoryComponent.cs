using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.ViewModels;

namespace Salvation.Presentation.WebApp.Components;

/// <summary>
/// CategoryComponent
/// </summary>
public class CategoryComponent : ViewComponent
{
    /// <summary>
    /// ICoreApiProvider
    /// </summary>
    private readonly ICoreApiProvider _coreApiProvider;

    /// <summary>
    /// ILogProvider
    /// </summary>
    private readonly ILogProvider _logProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="restProvider"></param>
    public CategoryComponent(ICoreApiProvider coreApiProvider, ILogProvider logProvider)
    {
        _coreApiProvider = coreApiProvider;
        _logProvider = logProvider;
    }

    /// <summary>
    /// Invoke
    /// </summary>
    /// <returns></returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
        try
        {
            var categoriesResult = await _coreApiProvider.GetCore<List<CategoryViewModel>>("https://localhost:7041/api/category/get-active-categories", isExactUrl: true);
            
            if (categoriesResult != null && categoriesResult.Code == 0 && categoriesResult.Data != null)
            {
                ViewBag.Categories = categoriesResult.Data;
            }
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
        }

        return View();
    }
}
