using BlockChain.Data.Entities;
using Service.Service.Transactions;

namespace Blockchain.Services.Mappers;

public static class TransactionPurchaseMapper
{
    public static TransactionPurchaseDto ToDto(this TransactionPurchase entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new TransactionPurchaseDto
        {
            Id = entity.Id,
            ToAccount = entity.ToAccount.ToDto(),
            FromAddress = entity.FromAddress,
            ToAddress = entity.ToAddress,
            FromSmartContract = entity.FromSmartContract.ToDto(),
            CreatedAt = entity.CreatedAt,
            nftId = entity.nftId,
            AmountExchanged = entity.AmountExchanged

        };
    }

    public static TransactionPurchase ToEntity(this TransactionPurchaseDto dto)
    {
        if (dto is null)
        {
            return null;
        }

        return new TransactionPurchase
        {
            Id = dto.Id,
            ToAccount = dto.ToAccount.ToEntity(),
            FromAddress = dto.FromAddress,
            ToAddress = dto.ToAddress,
            FromSmartContract = dto.FromSmartContract.ToEntity(),
            CreatedAt = dto.CreatedAt,
            nftId = dto.nftId,
            AmountExchanged = dto.AmountExchanged

        };
    }
}