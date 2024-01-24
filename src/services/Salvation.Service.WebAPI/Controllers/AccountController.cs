using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Request;
using Salvation.Library.Services.Abstractions;
using Salvation.Service.WebAPI.Controllers.Base;

namespace Salvation.Service.WebAPI.Controllers
{
    /// <summary>
    /// AccountController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        /// <summary>
        /// IAccountService
        /// </summary>
        private readonly IAccountService _accountService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(Account account)
        {
            var createResult = await _accountService.CreateAsync(account);
            
            if (createResult > 0)
            {
                return Ok(SuccessData(createResult));
            }
            
            return Ok(ErrorMessage("Tạo mới không thành công! Vui lòng check log và thử lại sau!"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var getOneResult = await _accountService.GetAsync(id);

            if (getOneResult != null)
            {
                return Ok(SuccessData(getOneResult));
            }

            return Ok(ErrorMessage("Id không hợp lệ hoặc có lỗi xảy ra"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllResult = await _accountService.GetAllAsync();

            if (getAllResult != null && getAllResult.Any())
            {
                return Ok(SuccessData(getAllResult));
            }

            return Ok(ErrorMessage("Không có dữ liệu hoặc có lỗi xảy ra"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Account account)
        {
            var updateResult = await _accountService.UpdateAsync(account);
            return Ok(SuccessData(updateResult));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var deleteResult = await _accountService.DeleteAsync(id);
            return Ok(SuccessData(deleteResult));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var registerResult = await _accountService.RegisterAsync(request);

            if (registerResult != null)
            {
                return Ok(SuccessData(registerResult));
            }

            return Ok(ErrorMessage("Đăng ký không thành công! Vui lòng thử lại sau!"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var loginResult = await _accountService.LoginAsync(request);

            if (loginResult != null)
            {
                return Ok(SuccessData(loginResult));
            }

            return Ok(ErrorMessage("Đăng nhập thất bại! Tài khoản hoặc mật khẩu không đúng!"));
        }
    }
}
