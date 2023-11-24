namespace Blockchain.WebApi.Models;

public class NftModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CollectionKey { get; set; }
    public string? OwnerKey { get; set; }
}