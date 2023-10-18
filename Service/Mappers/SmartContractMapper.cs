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
            SupplySold = entity.SupplySold,
            Funds = entity.Funds,
            FirstAvailableNftId = entity.FirstAvailableNftId
        };
    }

    public static SmartContract ToEntity(this SmartContractDto dto)
    {
        if (dto is null)
        {
            return null;
        }

        return new SmartContract
        {
            PublicKey = dto.PublicKey,
            Name = dto.Name,
            Price = dto.Price,
            OwnerId = dto.OwnerId,
            Owner = dto.Owner.ToEntity(),
            MaxSupply = dto.MaxSupply,
            SupplySold = dto.SupplySold,
            Funds = dto.Funds,
            FirstAvailableNftId = dto.FirstAvailableNftId
        };  
    }
}