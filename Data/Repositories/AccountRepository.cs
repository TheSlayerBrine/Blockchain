using Blockchain.Data.Entities;
using BlockChain.Data.Infrastructure.Context;
using BlockChain.Data.Infrastructure.Repository;
using System.Security.Cryptography.X509Certificates;
using static Blockchain.Data.Repositories.AccountRepository;

namespace Blockchain.Data.Repositories
{
        public class AccountRepository : Repository<Account>, IAccountRepository
        {
            private readonly IAppDbContext dbContext;
            public AccountRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
            {
                this.dbContext = dbContext;
            }
            public void Add(Account entity)
            {
                dbContext.Accounts.Add(entity);
            }

            public void Delete(Account entity)
            {
                dbContext.Accounts.Remove(entity);
            }
        public Account Find(string publicKey)
        {
                return dbContext.Accounts.Where(x => x.PublicKey == publicKey).FirstOrDefault();
            }
            public Account GetById(string publicKey)
            {
                var Account = dbContext.Accounts.FirstOrDefault(x => x.PublicKey == publicKey);
                return Account;
            }
            public IEnumerable<Account> GetAll()
            {
                return dbContext.Accounts.ToList();
            }

            public Account GetByName(string name)
            {
                return dbContext.Accounts.Where(x => x.Nickname == name).FirstOrDefault();
            }
        }
    }

