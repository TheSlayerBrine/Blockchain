using Microsoft.AspNetCore.Http;
using Service.Service.Blob;

namespace Service.Service.SmartContracts;

public class CreateSmartContractDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public IFormFile CollectionImage { get; set; }
    public int MaxSupply { get; set; }
}