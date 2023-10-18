using Blockchain.Services.Service.Common.Auth;
using Service.Service.SmartContracts;

namespace Service.Service.Nfts;

public class NftDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SmartContractDto Collection { get; set; }
    public string CollectionKey { get; set; }
    public AccountDto? Owner { get; set; }
    public string? OwnerKey { get; set; }
}