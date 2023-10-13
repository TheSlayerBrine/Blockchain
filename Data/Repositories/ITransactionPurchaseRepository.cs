using BlockChain.Data.Entities;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public interface ITransactionPurchaseRepository : IRepository<TransactionPurchase>
    {
        TransactionPurchase GetById(Guid id);
    }
}
