using BlockChain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;
using Microsoft.AspNetCore.Http;
using Service.Service.Blob;
using Service.Service.Nfts;
using Service.Service.TransactionContracts;
using Service.Service.Transactions;

namespace Service.Service.SmartContracts;

public class SmartContractService : ISmartContractService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly INftService nftService;
    private readonly ITransactionContractService transactionContractService;
    private readonly ITransactionPurchaseService transactionPurchaseService;
    private readonly IBlobService blobService;
    private ISmartContractService smartContractServiceImplementation;

    public SmartContractService(
        IUnitOfWork unitOfWork,
        INftService nftService,
        ITransactionContractService transactionContractService,
        ITransactionPurchaseService transactionPurchaseService,
        IBlobService blobService
    )
    {
        this.unitOfWork = unitOfWork;
        this.nftService = nftService;
        this.transactionPurchaseService = transactionPurchaseService;
        this.transactionContractService = transactionContractService;
        this.blobService = blobService;
    }

    public SmartContractDetailsDto GetDetails(string? key)
    {
        var smartContract = unitOfWork.SmartContracts.GetById(key);
        if (smartContract == null)
        {
            return null;
        }

        return smartContract.ToDetailsDto();
    }

    public SmartContractDto CreateSmartContract(CreateSmartContractDto dto, string? accountKey)
    {
        var account = unitOfWork.Accounts.GetById(accountKey);
        if (account is not null)
        {
            var newSmart = new SmartContract
            {
                Name = dto.Name,
                Price = dto.Price,
                OwnerId = account.PublicKey,
                MaxSupply = dto.MaxSupply,
                FirstAvailableNftId = 0
            };

            transactionContractService.CreateTransaction(newSmart.PublicKey);
          
            UploadImages(newSmart, dto.CollectionImage);
            unitOfWork.SmartContracts.Add(newSmart);
            unitOfWork.SaveChanges();
            return newSmart.ToDto();
        }

        return null;
    }

    public void ChangeSmartContractDetails(string smartKey, SmartContractDto smartContractDto)
    {
        if (smartContractDto is null)
        {
            return;
        }

        var account = unitOfWork.Accounts.GetById(smartContractDto.OwnerId);
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (account.PublicKey == smart.OwnerId)
        {
            if (!string.IsNullOrEmpty(smartContractDto.Name))
            {
                smart.Name = smartContractDto.Name;
            }

            if (smartContractDto.MaxSupply != null && smartContractDto.MaxSupply > smart.SupplySold)
            {
                smart.MaxSupply = smartContractDto.MaxSupply;
            }

            unitOfWork.SaveChanges();
        }
    }

    public void PurchaseNft(string smartKey, string? accountKey)
    {
        var account = unitOfWork.Accounts.GetById(accountKey);
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (account is not null && smart is not null && account.Balance > smart.Price &&
            smart.FirstAvailableNftId <= smart.MaxSupply)
        {
            account.Balance -= smart.Price;
            smart.Funds += smart.Price;
            nftService.CreateNft(smartKey, accountKey, smart.Name, smart.FirstAvailableNftId);
            transactionPurchaseService.CreateTransaction(smart.PublicKey, account.PublicKey, smart.FirstAvailableNftId);
            smart.FirstAvailableNftId++;
        }
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

    private void UploadImages(SmartContract smart, IFormFile collectionImage)
    {
        string collectionImageUrl = blobService.UploadBlob("smart-contract-images", collectionImage);
        smart.CollectionImageUrl = collectionImageUrl;
    }
}