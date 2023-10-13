using Blockchain.Data.Entities;
using Blockchain.Services.Service.Accounts;
using Blockchain.Services.Service.Common.Auth;

namespace Blockchain.Services.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToDto(this Account entity)
        {
            if (entity is null)
            {
                return null;
            }
            return new AccountDto
            {
                PublicKey = entity.PublicKey,
                PrivateKey = entity.PrivateKey,
                Nickname = entity.Nickname,
                Balance = entity.Balance,
            };
        }
        
        public static Account ToEntity(this AccountDto dto)
        {

            if (dto is null)
            {
                return null;
            }
            return new Account
            {
                PublicKey = dto.PublicKey,
                PrivateKey = dto.PrivateKey,
                Balance = dto.Balance,
                Nickname = dto.Nickname
            };
        }
    }
}
