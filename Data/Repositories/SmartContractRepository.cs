using BlockChain.Data.Entities;
using BlockChain.Data.Infrastructure.Context;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public class SmartContractRepository : Repository<SmartContract>, ISmartContractRepository
    {
        private readonly IAppDbContext dbContext;
        public SmartContractRepository (IAppDbContext dbContext) : base((AppDbContext)dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(SmartContract entity)
        {
            dbContext.SmartContracts.Add(entity);
        }

        public void Delete(SmartContract entity)
        {
            dbContext.SmartContracts.Remove(entity);
        }
        public SmartContract Find(string publicKey)
        {
            return dbContext.SmartContracts.Where(x => x.PublicKey == publicKey).FirstOrDefault();
        }
        public SmartContract GetById(string publicKey)
        {
            var SmartContract = dbContext.SmartContracts.FirstOrDefault(x => x.PublicKey == publicKey);
            return SmartContract;
        }
        public IEnumerable<SmartContract> GetAll()
        {
            return dbContext.SmartContracts.ToList();
        }

        public SmartContract GetByName(string name)
        {
            return dbContext.SmartContracts.Where(x => x.Name  == name).FirstOrDefault();
        }
    }
}
