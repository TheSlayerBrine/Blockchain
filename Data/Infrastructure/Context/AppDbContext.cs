using Blockchain.Data.Entities;
using BlockChain.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Data.Infrastructure.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(a => a.PublicKey);
            modelBuilder.Entity<Account>(e =>
            {
                e.Property(a => a.PublicKey).HasMaxLength(26).IsRequired();
                e.Property(a => a.PrivateKey).HasMaxLength(26).IsRequired();
            });
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Nfts)
                .WithOne(n => n.Owner)
                .HasForeignKey(n => n.OwnerKey);
            modelBuilder.Entity<Account>()
                .HasMany(a => a.SmartContracts)
                .WithOne(s => s.Owner)
                .HasForeignKey(s => s.OwnerId);           
            modelBuilder.Entity<Account>()
               .HasMany(a => a.TransactionContracts)
               .WithOne(t => t.FromAccount)
               .HasForeignKey(t => t.FromAddress)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Account>()
               .HasMany(a => a.TransactionPurchases)
               .WithOne(t => t.ToAccount)
               .HasForeignKey(t => t.ToAddress)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Nft>()
                .HasOne(n => n.Owner)
                .WithMany(a => a.Nfts)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nft>()
                .HasOne(n => n.Collection)
                .WithMany(c => c.Nfts)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<SmartContract>()
                .HasKey(a => a.PublicKey);
            modelBuilder.Entity<SmartContract>(e =>
                {
                    e.Property(a => a.PublicKey).HasMaxLength(26).IsRequired();
                });
            modelBuilder.Entity<SmartContract>()
                .HasMany(s => s.Nfts)
                .WithOne(n => n.Collection)
                .HasForeignKey(n => n.CollectionKey)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SmartContract>()
                .HasMany(s => s.TransactionPurchases)
                .WithOne(t => t.FromSmartContract)
                .HasForeignKey(t => t.FromAddress)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SmartContract>()
               .HasMany(s => s.TransactionContracts)
               .WithOne(t => t.ToSmartContract)
               .HasForeignKey(t => t.ToAddress)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Nft>()
                .HasKey(n => n.Identificator);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Nft> Nfts { get; set; }
        public DbSet<SmartContract> SmartContracts { get; set; }
        public DbSet<TransactionPurchase> TransactionPurchases { get; set; }
        public DbSet<TransactionContract> TransactionContracts { get; set; }
    }
}
