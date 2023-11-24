using Blockchain.Data.Entities;
using Service.Service.Nfts;

namespace Blockchain.Services.Mappers;

public static class NftMapper
{
    public static NftDto ToDto(this Nft entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new NftDto
        {
            Id = entity.Id,
            Name = entity.Name,
            OwnerKey = entity.OwnerKey,
            CollectionKey = entity.CollectionKey,
        };
    }

    public static Nft ToEntity(this NftDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Nft
            {
                Id = dto.Id,
                Name = dto.Name,
                OwnerKey = dto.OwnerKey,
                CollectionKey = dto.CollectionKey,
            };
        }
    }
