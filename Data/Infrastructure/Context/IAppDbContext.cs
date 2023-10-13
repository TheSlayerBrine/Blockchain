using Blockchain.Data.Entities;
using BlockChain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Data.Infrastructure.Context
{
    public interface IAppDbContext : IEntityFrameworkContext
    {
        public DbSet<Account> Accounts { get; }
        public DbSet<Nft> Nfts { get; }  
        public DbSet<SmartContract> SmartContracts { get; }
        public DbSet<TransactionPurchase> TransactionPurchases { get; }
        public DbSet<TransactionContract> TransactionContracts { get; }
    }
}
