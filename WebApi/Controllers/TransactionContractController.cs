using Blockchain.WebApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service.TransactionContracts;

namespace WebApi.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/transactionC")]
public class TransactionContractController : BaseController
{
    private readonly ITransactionContractService transactionContractService;

    public TransactionContractController(ITransactionContractService transactionContractService)
    {
        this.transactionContractService = transactionContractService;
    }

    [HttpGet("GetDetails")]
    public IActionResult GetDetails(Guid key)
    {
        var transaction = transactionContractService.GetDetails(key);
        return Ok(transaction.ToApiModel());
    }

    [HttpGet("GetAllCurrent")]
    public IActionResult GetAllTransactionsOfCurrentUser()
    {
        ValidateAccountKey();
        var transactions = transactionContractService.GetAllByAccount(AccountKey);
        return Ok(transactions.Select(x => x.ToApiModel()));
    }
}