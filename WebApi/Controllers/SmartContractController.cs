using Blockchain.WebApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service.SmartContracts;

namespace WebApi.Controllers;

[ApiController]
[Route("api/smart")]
public class SmartContractController : BaseController
{
    private readonly ISmartContractService smartContractService;

    public SmartContractController(ISmartContractService smartContractService)
    {
        this.smartContractService = this.smartContractService;
    }

    [HttpPost("CreateSmart")]
    [Authorize]
    public IActionResult CreateSmartContract([FromBody] string name, double price, int maxSupply)
    {
        ValidateAccountKey();
        var smart = smartContractService.CreateSmartContract(name, maxSupply, price, AccountKey);
        var model = smart.ToApiModel();
        return Ok($"You created a new smart with the name {model.Name}, price {model.Price} and supply of {model.MaxSupply}");
    }

    [HttpPost("PurchaseNft")]
    [Authorize]
    public IActionResult PurchaseNft([FromBody] string smartKey)
    {
        ValidateAccountKey();
        smartContractService.PurchaseNft(smartKey, AccountKey);
        return Ok();
    }
    
}