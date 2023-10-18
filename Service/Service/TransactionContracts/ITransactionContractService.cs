using Service.Service.SmartContracts;

namespace Service.Service.TransactionContracts;

public interface ITransactionContractService
{
    void CreateTransaction(SmartContractDto smart);
    void ChangeContractTransaction(SmartContractDto smart);
}