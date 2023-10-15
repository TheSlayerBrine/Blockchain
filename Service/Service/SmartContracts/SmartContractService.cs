using BlockChain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;

namespace Service.Service.SmartContracts;

public class SmartContractService : ISmartContractService
{
    private readonly IUnitOfWork unitOfWork;

    public SmartContractService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public SmartContractDto GetDetails(string? key)
    {
        var smartContract = unitOfWork.SmartContracts.GetById(key);
        if (smartContract == null)
        {
            return null;
        }
        return smartContract.ToDto();
    }

    public void CreateSmartContract(string name, int maxSupply, double price, string? accountKey)
    {
        var account = unitOfWork.Accounts.GetById(accountKey);
        if (account is not null)
        {
            var newSmart = new SmartContract
            {
                Name = name,
                Price = price,
                OwnerId = account.PublicKey,
                MaxSupply = maxSupply
            };
            unitOfWork.SmartContracts.Add(newSmart);
            unitOfWork.SaveChanges();
        }
        return;
    }

    public void ChangeSmartContractName(string name, string smartKey, string? accountKey)
    {
        var account = unitOfWork.Accounts.GetById(accountKey);
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (account is not null && account.PublicKey == smart.OwnerId)
        {
            smart.Name = name;
            unitOfWork.SaveChanges();
        }
    }

    public void ChangeSmartContractMaxSupply(int maxSupply, string smartKey, string? accountKey)
    {
        var account = unitOfWork.Accounts.GetById(accountKey);
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (account is not null && account.PublicKey == smart.OwnerId && maxSupply > smart.SupplySold)
        {
            smart.MaxSupply = maxSupply;
            unitOfWork.SaveChanges();
        }
    }
}