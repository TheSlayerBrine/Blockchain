using Blockchain.Services.Service.Common.Auth;
using Blockchain.WebApi.Models;

namespace Blockchain.WebApi.Mappers
{
    public static class AccountMapper
    {
        public static AccountModel ToApiModel(this AccountDto dto)
        {
            if(dto == null)
            {
                return null;
            }
            return new AccountModel
            {
                PrivateKey = dto.PrivateKey,
                PublicKey = dto.PublicKey,
                Balance = dto.Balance,
                Nickname = dto.Nickname,
            };
        }
        public static AccountDto ToDto(this AccountModel model)
        {
            if(model == null)
            {
                return null;
            }
            return new AccountDto
            {
                PrivateKey = model.PrivateKey,
                PublicKey = model.PublicKey,
                Balance = model.Balance,
                Nickname = model.Nickname,
            };
        }
    }
}
