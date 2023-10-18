using Blockchain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;

namespace Service.Service.Nfts;

public class NftService : INftService 
{
    private readonly IUnitOfWork unitOfWork;

    public NftService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public void CreateNft(string smartKey, string newOwnerKey, string name, int index)
    {
        
        var newNft = new Nft
        {
            Id = index,
            Name = name,
            OwnerKey = newOwnerKey,
            CollectionKey = smartKey,
        };
        unitOfWork.Nfts.Add(newNft);
        unitOfWork.SaveChanges();
    }
}