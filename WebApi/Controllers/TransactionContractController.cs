using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service.TransactionContracts;

namespace WebApi.Controllers;
[AllowAnonymous]
[ApiController]
[Route("api/transactionC")]
public class TransactionContractController : BaseController
{
    private readonly TransactionContractService transactionContractService;
    public TransactionContractController(TransactionContractService transactionContractService) : base(transactionContractService)
    {
        this.transactionContractService = transactionContractService;
    }
    [HttpGet("GetDetails")]
    public IActionResult GetDetails(Guid key)
    {
        var transaction = transactionContractService.GetDetails(key);
        return Ok(transaction);
    }

    [HttpGet("GetAllCurrent")]
    [Authorize]
    public IActionResult GetAllTransactionsOfCurrentUser()
    {
         var currentAccount = GetCurrentAccount();
            if (currentAccount is not null)
            {
                var transactions = transactionContractService.GetAllByAccount(currentAccount.PublicKey);
                return Ok(transactions);
            }

            return Unauthorized();
    }
    
}