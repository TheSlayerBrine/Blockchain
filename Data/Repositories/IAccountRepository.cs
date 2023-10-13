using Blockchain.Data.Entities;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetById(string publicKey);
        Account GetByName(string nickname);
    }
}
