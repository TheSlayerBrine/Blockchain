using BlockChain.Data.Entities;
using Blockchain.Data.Infrastructure.UnitOfWork;

namespace Service.Service.Transactions;

public class TransactionPurchaseService : ITransactionPurchaseService
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionPurchaseService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void CreateTransaction(string smartKey, string buyerKey)
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
                CreatedAt = DateTime.Now
            };
        }
    }
}