namespace Service.Service.Transactions;

public interface ITransactionPurchaseService
{
    void CreateTransaction(string smartKey, string buyerKey, int nftId);
    TransactionPurchaseDto GetDetails(Guid transactionId);
    IEnumerable<TransactionPurchaseDto> GetAllByAccount(string accountKey);
}