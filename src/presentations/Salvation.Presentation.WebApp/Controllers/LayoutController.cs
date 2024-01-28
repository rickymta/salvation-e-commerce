using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Models.Entities;

namespace Salvation.Presentation.WebApp.Controllers;

public class LayoutController : Controller
{
    public IActionResult RenderMenu()
    {
        var categories = new List<Category>
        {

        };

        return PartialView("_MenuBarPartialView", categories);
    }
}
