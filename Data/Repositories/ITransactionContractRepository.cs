using Blockchain.Data.Entities;
using BlockChain.Data.Entities;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public interface ITransactionContractRepository : IRepository<TransactionContract>
    {
        TransactionContract GetById(Guid id);
        IEnumerable<TransactionContract> GetAllByAccountKey(string accountKey);
        IEnumerable<TransactionContract> GetAllBySmartKey(string smartKey);
    }
}
