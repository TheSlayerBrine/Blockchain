using System.Security.Claims;
using Blockchain.Services.Service.Accounts;
using Blockchain.Services.Service.Users;
using Blockchain.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Blockchain.WebApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : BaseController
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService) : base(accountService)
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