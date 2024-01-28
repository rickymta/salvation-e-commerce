using Microsoft.AspNetCore.Mvc;
using Salvation.Handlers.Products.Abstractions;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Controller.Controllers;

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
}
