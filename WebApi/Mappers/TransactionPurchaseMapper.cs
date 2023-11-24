using Blockchain.WebApi.Models;
using Service.Service.TransactionContracts;
using Service.Service.Transactions;

namespace Blockchain.WebApi.Mappers;

public static class TransactionPurchaseMapper
{
    public static TransactionPurchaseModel ToApiModel(this TransactionPurchaseDto dto)
    {
        if (dto == null)
        {
            return null;
        }
        return new TransactionPurchaseModel()
        {
            Id = dto.Id,
            FromAddress = dto.FromAddress,
            ToAddress = dto.ToAddress,
            AmountExchanged = dto.AmountExchanged,
            CreatedAt = dto.CreatedAt,
            nftId = dto.nftId,
        };
    }

}