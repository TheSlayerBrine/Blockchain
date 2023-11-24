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

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpGet("GetKey")]
    public IActionResult GetCurrentKey()
    {
        ValidateAccountKey();
        return Ok($"your key is {AccountKey}");
    }

    [HttpPut("UpdateName")]
    public IActionResult UpdateName(string? name)
    {
        ValidateAccountKey();
        accountService.ChangeNickname(name, AccountKey);
        return Ok();
    }

    [HttpPost("DepositAthereum")]
    public IActionResult DepositAthereum(double amount)
    {
        ValidateAccountKey();
        accountService.DepositBalance(amount, AccountKey);
        return Ok();
    }

    [HttpPost("WithdrawUsd")]
    public IActionResult WithdrawUsd(double amount)
    {
        ValidateAccountKey();
        accountService.WithdrawBalance(amount, AccountKey);
        return Ok();
    }
}