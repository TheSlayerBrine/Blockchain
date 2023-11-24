using Blockchain.Services.Service.Common.Auth;

namespace Service.Service.SmartContracts;

public class SmartContractDto
{
    public string PublicKey { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string CollectionImageUrl { get; set; }
    public double Funds { get; set; }
    public AccountDto Owner { get; set; }
    public int FirstAvailableNftId { get; set; }
    public string OwnerId { get; set; }
    public int MaxSupply { get; set; }
    public int SupplySold { get; set; }
}