using Microsoft.AspNetCore.Mvc;

namespace Salvation.Presentation.WebAdmin.Controllers;

[Route("ung-dung")]
public class AppController : Controller
{
    [Route("su-kien")]
    public IActionResult Calendar()
    {
        return View();
    }

    [Route("tro-chuyen/{id}/{name?}")]
    public IActionResult Chat(string id, string? name)
    {
        ViewBag.Name = name;
        ViewBag.Id = id;
        return View();
    }
}
