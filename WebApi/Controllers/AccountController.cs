using System.Security.Claims;
using Blockchain.Services.Service.Accounts;
using Blockchain.Services.Service.Users;
using Blockchain.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.WebApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController :ControllerBase
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpGet("GetKey")]
    [Authorize]
    public IActionResult GetCurrentKey()
    {
        var currentAccount = GetCurrentAccount();
        return Ok($"your key is {currentAccount.PublicKey}");
    }
    private  AccountModel GetCurrentAccount()
    {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var userClaims = identity.Claims;
                return new AccountModel
                {
                    PublicKey = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }

            return null;
    }
    
    
}