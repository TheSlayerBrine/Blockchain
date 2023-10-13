using System.Security.Claims;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;
using Blockchain.Services.Service.Common.Auth;
using Blockchain.Services.Service.Users;

namespace Blockchain.Services.Service.Accounts;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public AccountDetailsDto GetDetails(string key)
    {
        var account = unitOfWork.Accounts.GetById(key);
        if (account == null)
        {
            return null;
        }

        return account.ToDetailsDto();
    }

    public void ChangeNickname(string name)
    {
    }
    
}