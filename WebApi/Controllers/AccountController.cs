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
                var key = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
                var balance = accountService.CheckBalance(key);
                return new AccountModel
                {
                    PublicKey = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value,
                    Balance = balance
                };
            }

            return null;
    }

    [HttpPut("UpdateName")]
    [Authorize]
    public IActionResult UpdateName(string? name) // Nu afiseaza Nickname u in OK
    {
        var currentAccount = GetCurrentAccount();
        if (currentAccount is not null)
        {
            accountService.ChangeNickname(name, currentAccount.PublicKey);
            return Ok($"your new name is {currentAccount.Nickname}");
        }

        return Unauthorized();
    }

    [HttpPost("DepositAthereum")]
    [Authorize]
    public IActionResult DepositAthereum(double amount)
    {
        var currentAccount = GetCurrentAccount();
        if (currentAccount is not null)
        {
            accountService.DepositBalance(amount, currentAccount.PublicKey);
            return Ok($"your new balance is {currentAccount.Balance}");
        }

        return Unauthorized();
    }
    [HttpPost("WithdrawUsd")]
    [Authorize]
    public IActionResult WithdrawUsd(double amount)
    {
        var currentAccount = GetCurrentAccount();
        if (currentAccount is not null)
        {
            accountService.WithdrawBalance(amount, currentAccount.PublicKey);
            return Ok($"your new balance is {currentAccount.Balance}");
        }   
        return Unauthorized();
    }
    
}