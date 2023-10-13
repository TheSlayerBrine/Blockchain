using BlockChain.Data.Entities;
using BlockChain.Data.Infrastructure.Context;
using BlockChain.Data.Infrastructure.Repository;
using NuGet.Protocol.Core.Types;


namespace Blockchain.Data.Repositories;

public class TransactionPurchaseRepository : Repository<TransactionPurchase> , ITransactionPurchaseRepository
{
    private readonly IAppDbContext dbContext;
    public TransactionPurchaseRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Add(TransactionPurchase entity)
    {
        dbContext.TransactionPurchases.Add(entity);
    }

    public void Delete(TransactionPurchase entity)
    {
        dbContext.TransactionPurchases.Remove(entity);
    }
    public TransactionPurchase Find(Guid id)
    {
        return dbContext.TransactionPurchases.Where(x => x.Id == id).FirstOrDefault();
    }
    public TransactionPurchase GetById(Guid id)
    {
        var TransactionPurchase = dbContext.TransactionPurchases.FirstOrDefault(x => x.Id == id);
        return TransactionPurchase;
    }
    public IEnumerable<TransactionPurchase> GetAll()
    {
        return dbContext.TransactionPurchases.ToList();
    }
    
}