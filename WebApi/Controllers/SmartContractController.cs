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

    public SmartContractController(ISmartContractService smartContractService) : base(smartContractService)
    {
        this.smartContractService = this.smartContractService;
    }

    [HttpPost("CreateSmart")]
    [Authorize]
    public IActionResult CreateSmartContract([FromBody] string name, double price, int maxSupply)
    {
        var currentAccount = GetCurrentAccount();
        if (currentAccount is not null)
        {
           var smart =  smartContractService.CreateSmartContract(name,maxSupply,price,currentAccount.PublicKey);
           var model = smart.ToApiModel();
           return Ok($"You created a new smart with the name {model.Name}, price {model.Price} and supply of {model.MaxSupply}");
        }

        return Unauthorized();
    }

    [HttpPost("PurchaseNft")]
    [Authorize]
    public IActionResult PurchaseNft([FromBody] string smartKey)
    {
        var currentAccount = GetCurrentAccount();
        if (currentAccount is not null)
        {
            
        }

        return Ok();
    }
    
    
}