using Service.Service.SmartContracts;

namespace Service.Service.TransactionContracts;

public interface ITransactionContractService
{
    void CreateTransaction(string smartKey);
    void ChangeContractTransaction(string smartKey, string? name, int? maxSupply);
}