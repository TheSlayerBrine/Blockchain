using Blockchain.Data.Entities;
using Service.Service.TransactionContracts;

namespace Blockchain.Services.Mappers;

public static class TransactionContractMapper
{
    public static TransactionContractDto ToDto(this TransactionContract entity)
    {
        if (entity is null)
        {
            return null;
        }

        return new TransactionContractDto
        {
            Id = entity.Id,
            FromAccount = entity.FromAccount.ToDto(),
            FromAddress = entity.FromAddress,
            ToAddress = entity.ToAddress,
            ToSmartContract = entity.ToSmartContract.ToDto(),
            Details = entity.Details,
            CreatedAt = entity.CreatedAt,

        };
    }

    public static TransactionContract ToEntity(this TransactionContractDto dto)
    {
        if (dto is null)
        {
            return null;
        }

        return new TransactionContract
        {
            Id = dto.Id,
            FromAccount = dto.FromAccount.ToEntity(),
            FromAddress = dto.FromAddress,
            ToAddress = dto.ToAddress,
            ToSmartContract = dto.ToSmartContract.ToEntity(),
            Details = dto.Details,
            CreatedAt = dto.CreatedAt

        };
    }
}