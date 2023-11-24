using Blockchain.WebApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Transactions;

namespace WebApi.Controllers;
[AllowAnonymous]
[ApiController]
[Route("api/transactionP")]
public class TransactionPurchaseController : BaseController
{
    private readonly ITransactionPurchaseService transactionPurchaseService;
    public TransactionPurchaseController(ITransactionPurchaseService transactionPurchaseService)
    {
        this.transactionPurchaseService = transactionPurchaseService;
    }

    [HttpGet("GetDetails")]
    public IActionResult GetDetails(Guid key)
    {
        var transaction = transactionPurchaseService.GetDetails(key);
        return Ok(transaction.ToApiModel());
    }

    [HttpGet("GetAllCurrent")]
    public IActionResult GetAllTransactionsOfCurrent()
    {
        ValidateAccountKey();
        var transactions = transactionPurchaseService.GetAllByAccount(AccountKey);
        return Ok(transactions.Select(x => x.ToApiModel()));
    }
}
