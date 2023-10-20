using Blockchain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;
using Service.Service.SmartContracts;

namespace Service.Service.TransactionContracts;

public class TransactionContractService : ITransactionContractService
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionContractService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void CreateTransaction(string smartKey)
    {
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (smart is not null)
        {
            var details = $"Created Smart contract with key: {smart.PublicKey} and MaxSupply: {smart.MaxSupply}";
            var newTransaction = new TransactionContract
            {
                FromAddress = smart.OwnerId,
                ToAddress = smart.PublicKey,
                Details = details,
                CreatedAt = DateTime.Now
            };
            unitOfWork.TransactionContracts.Add(newTransaction);
            unitOfWork.SaveChanges();
        }

        return;
    }

    public TransactionContractDto GetDetails(Guid transactionId)
    {
        var transaction = unitOfWork.TransactionContracts.GetById(transactionId);
        if (transaction is not null)
        {
            return transaction.ToDto();
        }

        return null;
    }
    public IEnumerable<TransactionContractDto> GetAllByAccount(string accountKey)
    {
        var transactions = unitOfWork.TransactionContracts.GetAllByAccountKey(accountKey).ToList();
        if (transactions is not null)
        {
            var dto = new List <TransactionContractDto>();
            foreach(var transaction in transactions)
            {
                dto.Add(transaction.ToDto());
            }

            return dto;
        }

        return null;
    }

    public IEnumerable<TransactionContractDto> GetAllBySmart(string smartKey)
    {
        var transactions = unitOfWork.TransactionContracts.GetAllBySmartKey(smartKey).ToList();
        if (transactions is not null)
        {
            var dto = new List <TransactionContractDto>();
            foreach(var transaction in transactions)
            {
                dto.Add(transaction.ToDto());
            }

            return dto;
        }

        return null;
    }

    public void ChangeContractTransaction(string smartKey, string? name, int? maxSupply)
    {
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (smart is not null)
        {
            if (name is not null)
            {
                string details = $"Changed name to {smart.Name} from smart with key {smart.PublicKey}";
            }

            if (maxSupply is not null)
            {
                string details = $"Changed max supply to {smart.MaxSupply} from smart with key {smart.PublicKey}";
            }
            
            var newTransaction = new TransactionContract
            {
                FromAddress = smart.OwnerId,
                ToAddress = smart.PublicKey,
                /*Details = details,*/ // crapa
                CreatedAt = DateTime.Now
            };
            unitOfWork.TransactionContracts.Add(newTransaction);
            unitOfWork.SaveChanges();
        }

        return;
    }
}