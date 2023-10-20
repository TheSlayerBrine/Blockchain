using Blockchain.Services.Service.Common.Auth;
using Service.Service.SmartContracts;

namespace Service.Service.Transactions;

public class TransactionPurchaseDto
{
    public Guid Id { get; set; }
    public string FromAddress { get; set; }
    public SmartContractDto FromSmartContract { get; set; }
    public string ToAddress { get; set; }
    public AccountDto ToAccount { get; set; }
    public double AmountExchanged { get; set; }
    public DateTime CreatedAt { get; set; }
    public int nftId { get; set; }
}