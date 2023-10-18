using Blockchain.Services.Service.Common.Auth;
using Service.Service.SmartContracts;

namespace Service.Service.TransactionContracts;

public class TransactionContractDto
{
    public Guid Id { get; set; }
    public string FromAddress { get; set; }
    public AccountDto FromAccount { get; set; }
    public SmartContractDto ToSmartContract { get; set; }
    public string ToAddress { get; set; }  
    public string Details { get; set; }
    public DateTime CreatedAt { get; set; }
}