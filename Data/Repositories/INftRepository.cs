using Blockchain.Data.Entities;
using BlockChain.Data.Infrastructure.Repository;

namespace Blockchain.Data.Repositories
{
    public interface INftRepository : IRepository<Nft>
    {
        Nft GetById(int id);
       Nft GetByName(string name);
    }
}
