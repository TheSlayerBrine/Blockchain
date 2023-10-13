namespace Blockchain.Services.Service.Common.Auth
{
    public interface IAuthService
    {
        public AccountDto CreateAccount();
        public string LoginAccount(string publicKey, string privateKey);
    }
}
