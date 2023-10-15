using System.Security.Claims;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;
using Blockchain.Services.Service.Common.Auth;
using Blockchain.Services.Service.Users;
using Service.Coin;

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

    public void ChangeNickname(string name, string? key)
    {
        var account = unitOfWork.Accounts.GetById(key);
        if (account is not null)
        {
            account.Nickname = name;
            unitOfWork.SaveChanges();
        }
        return;
    }

    public double DepositBalance(double amount, string? key)
    {
        var account = unitOfWork.Accounts.GetById(key);
        var convertedAmount = Athereum.ConvertUSDToAthereum(amount);
        Athereum.Value += convertedAmount * 0.01;
        account.Balance = convertedAmount;
        unitOfWork.SaveChanges();
        return account.Balance;
    }

    public double WithdrawBalance(double amount, string? key)
    {
        var account = unitOfWork.Accounts.GetById(key);
        var convertedAmount = Athereum.ConvertAthereumToUSD(amount);
        Athereum.Value -= amount * 0.01;
        account.Balance = convertedAmount;
        unitOfWork.SaveChanges();
        return account.Balance;
    }

    
}