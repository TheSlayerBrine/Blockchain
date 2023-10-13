using Blockchain.Data.Entities;
using Blockchain.Services.Service.Accounts;

namespace Blockchain.Services.Mappers;

public static class AccountDetailsMapper
{
public static AccountDetailsDto ToDetailsDto(this Account entity)
{
    if (entity is null)
    {
        return null;
    }
    return new AccountDetailsDto()
    {
        PublicKey = entity.PublicKey,
        Nickname = entity.Nickname,
        Balance = entity.Balance,
    };
}
}