namespace Service.Service.Transactions;

public interface ITransactionPurchaseService
{
    void CreateTransaction(string smartKey, string buyerKey);
}