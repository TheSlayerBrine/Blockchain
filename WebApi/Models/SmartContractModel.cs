namespace Blockchain.WebApi.Models;

public class SmartContractModel
{
    public string PublicKey { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public double Funds { get; set; }
    public AccountModel Owner { get; set; }
    public int FirstAvailableNftId { get; set; }
    public string OwnerId { get; set; }
    public int MaxSupply { get; set; }
    public int SupplySold { get; set; }
}