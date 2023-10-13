using Blockchain.Data.Repositories;
using BlockChain.Data.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Blockchain.Data.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext dbContext;
        public UnitOfWork(
            IAppDbContext dbContext,
            IAccountRepository accountRepository,
            INftRepository nftRepository,
            ITransactionContractRepository transactionContractRepository,
            ISmartContractRepository smartContractRepository,
            ITransactionPurchaseRepository transactionPurchaseRepository)
        {
            this.dbContext = dbContext;
            Accounts = accountRepository;
            Nfts = nftRepository;
            SmartContracts = smartContractRepository;
            TransactionContracts = transactionContractRepository;
            TransactionPurchases = transactionPurchaseRepository;
        }
        public IAccountRepository Accounts { get; private set; }
        public INftRepository Nfts { get; private set; }
        public ISmartContractRepository SmartContracts { get; private set; }
        public ITransactionContractRepository TransactionContracts { get; private set; }
        public ITransactionPurchaseRepository TransactionPurchases { get; private set; }
        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
        public void Reload<T>(T entity) where T : class
        {
            dbContext.Entry(entity).Reload();
        }
        public bool IsModified<T>(T entity) where T : class
        {
            return dbContext.Entry(entity).State == EntityState.Modified;
        }
    }
}
