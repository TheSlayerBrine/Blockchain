using BlockChain.Data.Entities;
using Service.Service.SmartContracts;

namespace Blockchain.Services.Mappers;

public static class SmartContractMapper
{
    public static SmartContractDto ToDto(this SmartContract entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new SmartContractDto
        {
            PublicKey = entity.PublicKey,
            Name = entity.Name,
            Price = entity.Price,
            Owner = entity.Owner.ToDto(),
            OwnerId = entity.OwnerId,
            MaxSupply = entity.MaxSupply,
            SupplySold = entity.SupplySold
        };
    }
}