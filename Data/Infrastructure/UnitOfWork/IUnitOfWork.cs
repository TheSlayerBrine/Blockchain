using Blockchain.Data.Repositories;

namespace Blockchain.Data.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAccountRepository Accounts { get; }
        public INftRepository Nfts { get; }
        public ISmartContractRepository SmartContracts { get; }
        public ITransactionContractRepository TransactionContracts { get; }
        public ITransactionPurchaseRepository TransactionPurchases { get; }
        int SaveChanges();
        void Reload<T>(T entity) where T : class;
        bool IsModified<T>(T entity) where T : class;
        void Dispose();
    }
}
