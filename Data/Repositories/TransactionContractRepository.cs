using Blockchain.Data.Entities;
using BlockChain.Data.Entities;
using BlockChain.Data.Infrastructure.Context;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public class TransactionContractRepository : Repository<TransactionContract>, ITransactionContractRepository
    {
            private readonly IAppDbContext dbContext;
            public TransactionContractRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
            {
                this.dbContext = dbContext;
            }
            public void Add(TransactionContract entity)
            {
                dbContext.TransactionContracts.Add(entity);
            }

            public void Delete(TransactionContract entity)
            {
                dbContext.TransactionContracts.Remove(entity);
            }
            public TransactionContract Find(Guid id)
            {
                return dbContext.TransactionContracts.Where(x => x.Id == id).FirstOrDefault();
            }
            public TransactionContract GetById(Guid id)
            {
                var TransactionContract = dbContext.TransactionContracts.FirstOrDefault(x => x.Id == id);
                return TransactionContract;
            }
            public IEnumerable<TransactionContract> GetAll()
            {
                return dbContext.TransactionContracts.ToList();
            }

            
    }
}
