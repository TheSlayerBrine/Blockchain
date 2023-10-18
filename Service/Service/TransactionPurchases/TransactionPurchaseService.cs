using Blockchain.Data.Infrastructure.UnitOfWork;

namespace Service.Service.Transactions;

public class TransactionPurchaseService : ITransactionPurchaseService
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionPurchaseService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
}