using Microsoft.AspNetCore.Mvc;

namespace Salvation.Presentation.WebApp.Controllers;

/// <summary>
/// ProductController
/// </summary>
[Route("san-pham")]
public class ProductController : Controller
{
    [Route("{displayMode?}")]
    public IActionResult Index(string? displayMode)
    {
        return View();
    }

    [Route("chi-tiet/{slug}")]
    public IActionResult Detail(string slug)
    {
        return View();
    }

    [Route("xay-dung-cau-hinh")]
    public IActionResult Build()
    {
        return View();
    }
}
