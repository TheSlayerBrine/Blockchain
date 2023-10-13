using Blockchain.Services.Service.Common.Auth;
using Blockchain.WebApi.Mappers;
using Blockchain.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class AuthController
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("register")]
        public ActionResult<AccountModel> CreateAccount()
        {
            var credentials = authService.CreateAccount();
            return credentials.ToApiModel();
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> LoginAccount( LoginRequest login)
        {
            var token = authService.LoginAccount(login.PublicKey, login.PrivateKey);
            return new LoginResponse(token);
        }
        
    }
}
