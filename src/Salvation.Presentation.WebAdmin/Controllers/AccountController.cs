using Salvation.Library.Common.Abstractions;
using Salvation.Library.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Request;
using Salvation.Library.Models.Response;

namespace Salvation.Presentation.WebAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICookieProvider _cookieProvider;

        private readonly IHashProvider _hashProvider;

        public AccountController(IUnitOfWork unitOfWork, ICookieProvider cookieProvider, IHashProvider hashProvider)
        {
            _unitOfWork = unitOfWork;
            _cookieProvider = cookieProvider;
            _hashProvider = hashProvider;
        }

        [Route("/tai-khoan/thong-tin-ca-nhan")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/dang-nhap")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/dang-ky")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/quen-mat-khau")]
        public IActionResult Forgot()
        {
            return View();
        }

        [Route("/dang-xuat")]
        public IActionResult LogOut()
        {
            _cookieProvider.Remove("AdminEmail");
            return RedirectToAction("Login");
        }

        [HttpPost("/do-login")]
        public async Task<IActionResult> DoLoginAsync(LoginRequest request)
        {
            var accountFind = await _unitOfWork.Account.GetOneByEmail(request.Email);

            if (accountFind != null)
            {
                if (_hashProvider.VerifyPassword(accountFind.Password, request.Password))
                {
                    _cookieProvider.Set("AdminEmail", request.Email, 3600 * 2);
                    return Ok(new ResponseObject<Account> { Code = 0, Message = "Login success!", Data = accountFind });
                }
            }

            return Ok(new ResponseObject { Code = -1, Message = "Email or password is not valid!" });
        }

        [HttpPost("/do-register")]
        public async Task<IActionResult> DoRegisterAsync(RegisterRequest request)
        {
            var accountFind = await _unitOfWork.Account.GetOneByEmail(request.Email);

            if (accountFind == null)
            {
                var account = new Account
                {
                    Fullname = request.Fullname,
                    Email = request.Email,
                    Password = _hashProvider.HashPassword(request.Password),
                    Address = request.Address,
                    IsActived = true,
                    IsDeleted = false,
                };

                var registerResult = await _unitOfWork.Account.CreateAsync(account);

                if (registerResult > 0)
                {
                    _cookieProvider.Set("AdminEmail", request.Email, 3600 * 2);
                    return Ok(new ResponseObject { Code = 0, Message = "Register success!", Data = registerResult });
                }

                return Ok(new ResponseObject { Code = -1, Message = "Register failed! Please try again!" });
            }

            return Ok(new ResponseObject { Code = -1, Message = "Email is already exist!" });
        }
    }
}
