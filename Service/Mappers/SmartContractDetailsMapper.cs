using BlockChain.Data.Entities;
using Service.Service.SmartContracts;

namespace Blockchain.Services.Mappers;

public static class SmartContractDetailsMapper
{
    public static SmartContractDetailsDto ToDetailsDto(this SmartContract entity)
    {
        if (entity is null)
        {
            return null;
        }
        return new SmartContractDetailsDto
        {
            PublicKey = entity.PublicKey,
            Name = entity.Name,
            Price = entity.Price,
            MaxSupply = entity.MaxSupply
        };
    }
}