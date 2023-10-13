using BlockChain.Data.Entities;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public interface ISmartContractRepository : IRepository<SmartContract>
    {
        SmartContract GetById(string publicKey);
        SmartContract GetByName(string name);
        
    }
}
