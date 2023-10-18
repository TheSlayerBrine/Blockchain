using Blockchain.Data.Infrastructure.UnitOfWork;
using Service.Service.SmartContracts;

namespace Service.Service.TransactionContracts;

public class TransactionContractService : ITransactionContractService
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionContractService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void CreateTransaction(SmartContractDto smart)
    {
        throw new NotImplementedException();
    }

    public void ChangeContractTransaction(SmartContractDto smart)
    {
        throw new NotImplementedException();
    }
}