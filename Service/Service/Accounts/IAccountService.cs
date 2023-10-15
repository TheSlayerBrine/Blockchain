using Blockchain.Services.Service.Accounts;
using Blockchain.Services.Service.Common.Auth;

namespace Blockchain.Services.Service.Users;

public interface IAccountService
{
    AccountDetailsDto GetDetails(string? key);
    void ChangeNickname(string name, string? key);
    double DepositBalance(double amount, string? key);
    double WithdrawBalance(double amount, string? key);
    double CheckBalance(string? key);
}