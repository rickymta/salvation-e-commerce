using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Request;
using Salvation.Service.WebAPI.Controllers.Base;
using Salvation.Services.AuthHandler.Abstractions;

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
        /// IaccountHandler
        /// </summary>
        private readonly IAccountHandler _accountHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountHandler"></param>
        public AccountController(IAccountHandler accountHandler)
        {
            _accountHandler = accountHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(Account account)
        {
            var createResult = await _accountHandler.CreateAsync(account);
            
            if (createResult > 0)
            {
                return Ok(SuccessData(createResult));
            }
            
            return Ok(ErrorMessage("Tạo mới không thành công! Vui lòng check log và thử lại sau!"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var getOneResult = await _accountHandler.GetAsync(id);

            if (getOneResult != null)
            {
                return Ok(SuccessData(getOneResult));
            }

            return Ok(ErrorMessage("Id không hợp lệ hoặc có lỗi xảy ra"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllResult = await _accountHandler.GetAllAsync();

            if (getAllResult != null && getAllResult.Any())
            {
                return Ok(SuccessData(getAllResult));
            }

            return Ok(ErrorMessage("Không có dữ liệu hoặc có lỗi xảy ra"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Account account)
        {
            var updateResult = await _accountHandler.UpdateAsync(account);
            return Ok(SuccessData(updateResult));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var deleteResult = await _accountHandler.DeleteAsync(id);
            return Ok(SuccessData(deleteResult));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var registerResult = await _accountHandler.RegisterAsync(request);

            if (registerResult != null)
            {
                return Ok(SuccessData(registerResult));
            }

            return Ok(ErrorMessage("Đăng ký không thành công! Vui lòng thử lại sau!"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var loginResult = await _accountHandler.LoginAsync(request);

            if (loginResult != null)
            {
                return Ok(SuccessData(loginResult));
            }

            return Ok(ErrorMessage("Đăng nhập thất bại! Tài khoản hoặc mật khẩu không đúng!"));
        }
    }
}
