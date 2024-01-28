using Microsoft.AspNetCore.Mvc;
using Salvation.Services.Models.Request;

namespace Salvation.Services.FileService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileUploadController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Everything is okela!");
    }

    [HttpPost("handle-upload")]
    public IActionResult HandleUploadFile(FileUploadRequest request)
    {
        return Ok();
    }

    [HttpPost("handle-upload-base64")]
    public IActionResult HandleUploadFileBase64(FileBase64Request request)
    {
        return Ok();
    }
}
