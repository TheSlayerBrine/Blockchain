using Blockchain.Data.Entities;
using BlockChain.Data.Entities;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public interface ITransactionContractRepository : IRepository<TransactionContract>
    {
        TransactionContract GetById(Guid id);
    }
}
