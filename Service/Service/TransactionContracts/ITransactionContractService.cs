using Service.Service.SmartContracts;

namespace Service.Service.TransactionContracts;

public interface ITransactionContractService
{
    void CreateTransaction(string smartKey);
    void ChangeContractTransaction(string smartKey, string? name, int? maxSupply);
    TransactionContractDto GetDetails(Guid transactionId);
    IEnumerable<TransactionContractDto> GetAllByAccount(string accountKey);
    IEnumerable<TransactionContractDto> GetAllBySmart(string smartKey);
    
}