using BlockChain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;
using Service.Service.Nfts;

namespace Service.Service.SmartContracts;

public class SmartContractService : ISmartContractService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly INftService nftService;
    public SmartContractService(IUnitOfWork unitOfWork, INftService nftService)
    {
        this.unitOfWork = unitOfWork;
        this.nftService = nftService;
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

    public void PurchaseNft( string smartKey, string? accountKey)
    {
        var account = unitOfWork.Accounts.GetById(accountKey);
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (account is not null && smart is not null && account.Balance > smart.Price && smart.FirstAvailableNftId <= smart.MaxSupply )
        {
            account.Balance -= smart.Price;
            smart.Funds += smart.Price;
            nftService.CreateNft(smartKey, accountKey, smart.Name,smart.FirstAvailableNftId);
            smart.FirstAvailableNftId++;
        }
        return;
    }

    public double WithdrawFunds(double amount, string smartKey, string? accountKey)
    {
        var account = unitOfWork.Accounts.GetById(accountKey);
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (smart.Funds > amount)
        {
            smart.Funds -= amount;
            account.Balance += amount;
            return amount;
        }

        return 0;
    }
}