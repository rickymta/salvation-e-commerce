using Microsoft.AspNetCore.Mvc;
using Salvation.Services.FileService.Handlers;
using Salvation.Services.Models.Request;

namespace Salvation.Services.FileService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileUploadController : ControllerBase
{
    private readonly string UploadDirectory = AppDomain.CurrentDomain.BaseDirectory + "Upload\\";

    [HttpGet]
    public IActionResult Index()
    {
        return Ok("FileService is running okela!");
    }

    [HttpPost("handle-upload-base64")]
    public IActionResult HandleUploadFileBase64(FileBase64Request request)
    {
        var uploadPath = UploadDirectory;

        if (!string.IsNullOrEmpty(request.FileString))
        {
            if (!string.IsNullOrEmpty(request.FileType))
            {
                var fileArr = request.FileType.Split('/');
                uploadPath += fileArr[0] + "\\" + fileArr[1] + "\\" + request.FileName;
                uploadPath = uploadPath.Replace("\\", "/");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                FileHandler.SaveBase64StringAsImage(request.FileString, uploadPath);
            }
        }

        return Ok();
    }
}
