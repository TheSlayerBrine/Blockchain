using Blockchain.WebApi.Models;
using Service.Service.TransactionContracts;

namespace Blockchain.WebApi.Mappers;

public static class TransactionContractMapper
{
    public static TransactionContractModel ToApiModel(this TransactionContractDto dto)
    {
        if (dto == null)
        {
            return null;
        }
        return new TransactionContractModel
        {
            Id = dto.Id,
            FromAddress = dto.FromAddress,
            ToAddress = dto.ToAddress,
            Details = dto.Details,
            CreatedAt = dto.CreatedAt
        };
    }
}