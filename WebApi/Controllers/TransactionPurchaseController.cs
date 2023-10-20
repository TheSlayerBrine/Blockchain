using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Transactions;

namespace WebApi.Controllers;
[AllowAnonymous]
[ApiController]
[Route("api/transactionC")]
public class TransactionPurchaseController : BaseController
{
    private readonly ITransactionPurchaseService transactionPurchaseService;
    public TransactionPurchaseController(ITransactionPurchaseService transactionPurchaseService)
    {
        this.transactionPurchaseService = transactionPurchaseService;
    }
}