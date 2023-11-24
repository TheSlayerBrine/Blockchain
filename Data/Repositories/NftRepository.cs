using Blockchain.Data.Entities;
using BlockChain.Data.Infrastructure.Context;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public class NftRepository : Repository<Nft>, INftRepository
    {
        private readonly IAppDbContext dbContext;
        public NftRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Nft entity)
        {
            dbContext.Nfts.Add(entity);
        }

        public void Delete(Nft entity)
        {
            dbContext.Nfts.Remove(entity);
        }
        public Nft Find(int id)
        {
            return dbContext.Nfts.Where(x => x.Id == id).FirstOrDefault();
        }
        public Nft GetById(Guid id)
        {
            var Nft = dbContext.Nfts.FirstOrDefault(x => x.Identificator == id);
            return Nft;
        }
        public IEnumerable<Nft> GetAll()
        {
            return dbContext.Nfts.ToList();
        }

        public Nft GetByName(string name)
        {
            return dbContext.Nfts.Where(x => x.Name  == name).FirstOrDefault();
        }
    }
}
