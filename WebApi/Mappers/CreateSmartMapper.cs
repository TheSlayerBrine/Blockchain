using Blockchain.WebApi.Models;
using Service.Service.SmartContracts;

namespace Blockchain.WebApi.Mappers;

public static class CreateSmartMapper
{
    public static CreateSmartContractDto ToDto(this CreateSmartRequest request)
    {
        if (request is null)
        {
            return null;
        }

        return new CreateSmartContractDto()
        {
            Name = request.Name,
            Price = request.Price,
            CollectionImage = request.CollectionImage
            MaxSupply = request.MaxSupply
        };
    }
}