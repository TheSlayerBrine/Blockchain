using Blockchain.WebApi.Models;
using Service.Service.Nfts;

namespace Blockchain.WebApi.Mappers;

public static class NftMapper
{
    public static NftModel ToApiModel(this NftDto dto)
    {
        if(dto == null)
        {
            return null;
        } 
        return new NftModel
        {
            Id = dto.Id,
            Name = dto.Name,
            CollectionKey = dto.CollectionKey,
            OwnerKey = dto.OwnerKey,
        };
    }
}