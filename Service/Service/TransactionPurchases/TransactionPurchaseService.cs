using BlockChain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Services.Mappers;

namespace Service.Service.Transactions;

public class TransactionPurchaseService : ITransactionPurchaseService
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionPurchaseService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void CreateTransaction(string smartKey, string buyerKey, int nftId)
    {
        var account = unitOfWork.Accounts.GetById(buyerKey);
        var smart = unitOfWork.SmartContracts.GetById(smartKey);
        if (account is not null && smart is not null)
        {
            var newTransaction = new TransactionPurchase
            {
                FromAddress = smart.PublicKey,
                ToAddress = account.PublicKey,
                AmountExchanged = smart.Price,
                CreatedAt = DateTime.Now,
                nftId = nftId
            };
        }
    }

    public TransactionPurchaseDto GetDetails(Guid transactionId)
    {
        var transaction = unitOfWork.TransactionPurchases.GetById(transactionId);
        if (transaction is not null)
        {
            return transaction.ToDto();
        }

        return null;
    }
    public IEnumerable<TransactionPurchaseDto> GetAllByAccount(string accountKey)
    {
        var transactions = unitOfWork.TransactionPurchases.GetAllByAccountKey(accountKey).ToList();
        if (transactions is not null)
        {
            var dto = new List <TransactionPurchaseDto>();
            foreach(var transaction in transactions)
            {
                dto.Add(transaction.ToDto());
            }
            return dto;
        }

        return null;
    }
}