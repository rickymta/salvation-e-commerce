using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Services.Abstractions;
using Salvation.Service.WebAPI.Controllers.Base;

namespace Salvation.Service.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var getOneResult = await _categoryService.GetAsync(id);

            if (getOneResult != null)
            {
                return Ok(SuccessData(getOneResult));
            }

            return Ok(ErrorMessage("Id không hợp lệ hoặc có lỗi xảy ra"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllResult = await _categoryService.GetAllAsync();

            if (getAllResult != null && getAllResult.Any())
            {
                return Ok(SuccessData(getAllResult));
            }

            return Ok(ErrorMessage("Không có dữ liệu hoặc có lỗi xảy ra"));
        }
    }
}
