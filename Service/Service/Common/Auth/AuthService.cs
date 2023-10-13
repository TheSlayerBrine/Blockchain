using System.IdentityModel.Tokens.Jwt;
using Blockchain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Blockchain.Services.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blockchain.Services.Service.Common.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration config;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.config = config;
        }
        public AccountDto CreateAccount()
        {
            var publicKey = GenerateKey();
            var accounts = unitOfWork.Accounts.GetAll();
            while (accounts.Any(a => a.PublicKey == publicKey) == true)
            {
                publicKey = GenerateKey();
            }
            var privateKey = GenerateKey();
            var newAccount = new Account
            {
                PublicKey = publicKey,
                PrivateKey = privateKey,
                Balance = 0
            };
            unitOfWork.Accounts.Add(newAccount);
            unitOfWork.SaveChanges();
            return newAccount.ToDto();
        }

        public string LoginAccount(string publicKey, string privateKey)
        {
            var account = unitOfWork.Accounts.GetById(publicKey);
            if (account is null)
            {
                throw new LoginException("Key doesn't exist");
            }

            if (account.PrivateKey != privateKey)
            {
                throw new LoginException("Keys are not matching");
            }

            return GenerateJwt(account.ToDto());
        }

        private string GenerateJwt(AccountDto account)
        {
            var securityKey = new SymmetricSecurityKey((Encoding.UTF8.GetBytes(config["Jwt:Key"])));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.PublicKey)
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(2000),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static string GenerateKey()
        {
            string allowedCharacters = "0123456789abcdefABCDEF";         
            Random random = new Random();            
            char[] keyChars = new char[24];
            for (int i = 0; i < keyChars.Length; i++)
            {
                keyChars[i] = allowedCharacters[random.Next(allowedCharacters.Length)];
            }
            string key = "0x" + new string(keyChars);
            return key;
        }
    }
}
