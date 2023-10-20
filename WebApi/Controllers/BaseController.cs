using System.Security.Claims;
using Blockchain.Services.Service.Users;
using Blockchain.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Service.SmartContracts;
using Service.Service.TransactionContracts;

namespace WebApi.Controllers;

public abstract class BaseController : ControllerBase
{
    private readonly IAccountService accountService;
    private readonly ISmartContractService smartContractService;
    private readonly ITransactionContractService transactionContractService;
    

    public BaseController(IAccountService accountService)
    {
        this.accountService = accountService;
        
    }
    public BaseController(ISmartContractService smartContractService)
    {
        this.smartContractService = smartContractService;
    }
    public BaseController(ITransactionContractService transactionContractService)
    {
        this.transactionContractService = transactionContractService ;
    }
    
    
    public AccountModel GetCurrentAccount()
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
   
}