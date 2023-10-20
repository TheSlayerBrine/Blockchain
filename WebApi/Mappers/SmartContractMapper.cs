using Blockchain.WebApi.Models;
using Service.Service.SmartContracts;

namespace Blockchain.WebApi.Mappers;

public static class SmartContractMapper
{
    public static SmartContractModel ToApiModel(this SmartContractDto dto)
    {
        if (dto is null)
        {
            return null;
        }

        return new SmartContractModel()
        {
            PublicKey = dto.PublicKey,
            Name = dto.Name,
            Price = dto.Price,
            OwnerId = dto.OwnerId,
            Owner = dto.Owner.ToApiModel(),
            MaxSupply = dto.MaxSupply,
            SupplySold = dto.SupplySold,
            Funds = dto.Funds,
            FirstAvailableNftId = dto.FirstAvailableNftId
        };
    }
}