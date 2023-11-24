using Blockchain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;
using Service.Service.SmartContracts;

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
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        name = smart.Name + " " + index;
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

    public NftDto GetDetails(Guid identificator)
    {
        var nft = unitOfWork.Nfts.GetById(identificator);
        if (nft == null)
        {
            return null;
        }
        return nft.ToDto();
    }
}