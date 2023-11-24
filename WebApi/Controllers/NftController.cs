using Blockchain.WebApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Nfts;

namespace WebApi.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/nft")]
public class NftController : BaseController
{
    private readonly INftService nftService;
    public NftController(INftService nftService)
    {
        this.nftService = nftService;
    }
    [HttpGet("{identificator}")]
    public IActionResult GetDetails(Guid identificator)
    {
        var nft = nftService.GetDetails(identificator);
        if (nft == null)
        {
            return NotFound();
        }
        return Ok(nft.ToApiModel());
    }
    
}